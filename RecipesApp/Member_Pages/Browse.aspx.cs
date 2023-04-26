using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Serialization;
using RecipesApp.SaveAndLoadRecipeService;

namespace RecipesApp
{
    [XmlRoot(ElementName = "recipes")]
    public class RecipesDecode
    {
        [XmlElement(ElementName = "offset")]
        public int Offset { get; set; }

        [XmlElement(ElementName = "number")]
        public int Number { get; set; }

        [XmlElement(ElementName = "results")]
        public List<RecipeDecode> Results { get; set; }

        [XmlElement(ElementName = "totalResults")]
        public int TotalResults { get; set; }
    }

    public class RecipeDecode
    {
        [XmlElement(ElementName = "id")]
        public int id { get; set; }

        [XmlElement(ElementName = "title")]
        public string title { get; set; }

        [XmlElement(ElementName = "image")]
        public string image { get; set; }

        [XmlElement(ElementName = "imageType")]
        public string imageType { get; set; }

        // Add other properties here as needed
    }


    public partial class Browse : System.Web.UI.Page
    {
        protected void Back_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://webstrar192.fulton.asu.edu/index.html");    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RecipeSearchWeb.Service1Client recipeSearch = new RecipeSearchWeb.Service1Client();
            //RecipeSearch.Service1Client recipeSearch = new RecipeSearch.Service1Client();

            string q = query.Text;
            string cuisine = DropDownCuisine.Text;
            cuisine = cuisine.Replace("Cuisine", "");
            string diet = DropDownDiet.Text;
            diet = diet.Replace("Diet", "");
            string intolerances = "";
            bool first = true;
            foreach (ListItem li in CheckBoxIntolerance.Items)
            {
                if (li.Selected)
                {
                    if (!first) intolerances += ", ";
                    intolerances += li.Text;
                    first = false;
                }
            }

            string result = recipeSearch.Search(q, cuisine, diet, intolerances, 0);

            // Create an instance of XmlSerializer class for deserialization
            XmlSerializer serializer = new XmlSerializer(typeof(RecipesDecode));


            //Create Array List for adding to GUI
            ArrayList values = new ArrayList();


            // Create a StringReader instance to read the XML string returned from the service
            using (System.IO.StringReader reader = new System.IO.StringReader(result))
            {
                // Call Deserialize method of XmlSerializer class to deserialize the XML string
                RecipesDecode recipes = (RecipesDecode)serializer.Deserialize(reader);

                // Access the properties of the response object
                int i = 1;
                foreach (RecipeDecode r in recipes.Results)
                {
                    string imageType = Path.GetExtension(r.image).Substring(1);
                    values.Add(new RecipePreview(r.title, imageType, r.id));
                }
            }
            Repeater1.DataSource = values;
            Repeater1.DataBind();

            recipeSearch.Close();
        }

        protected void MyBtnHandler(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //RecipeSearch.Service1Client recipeSearch = new RecipeSearch.Service1Client();

            string id = btn.CommandArgument;

            Console.WriteLine(id);
            HttpContext.Current.Session["recipeId"] = id;
            Response.Redirect("FullRecipe.aspx");
        }
        protected void MyBtnHandler2(Object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            Button btn = (Button)sender;
            int id = Int32.Parse(btn.CommandArgument);
            if (Session["recipeId"] != null) { id = Int32.Parse((string)Session["recipeId"]); }

            string path = "" + user + ".xml";
            

            if (id != 0)
            {
                SaveAndLoadRecipeServiceClient saveAndLoadRecipe = new SaveAndLoadRecipeServiceClient();
                saveAndLoadRecipe.SaveRecipesToXml(id, path);
            }

        }
        private bool IsUsernameTaken(string username)
        {
            //string user = (string)Session["username"];
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/members.xml");

            if (!File.Exists(xmlFilePath))
            {
                return false;
            }

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement member = doc.Descendants("member").FirstOrDefault(m => m.Element("username").Value == username);

            if (member != null)
            {
                return true;
            }

            return false;
        }
    }
}