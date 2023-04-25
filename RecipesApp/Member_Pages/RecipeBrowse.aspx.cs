using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace RecipesApp
{
    

    public class RecipePreview
    {
        private string title;
        private string imageUrl;
        private string id;    //Will be used for 'See full recipe'
        public RecipePreview(string title, string imageType, int id)
        {
            this.title = title;
            this.imageUrl = "https://spoonacular.com/recipeImages/" + id + "-636x393." + imageType;
            this.id = id.ToString();
        }
        public string Title
        {
            get
            {
                return title;
            }
        }
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
        }
    }

    public partial class RecipeBrowse : System.Web.UI.Page
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
                    values.Add(new RecipePreview(r.title, r.imageType, r.id));
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
            Response.Redirect("TryItFullRecipe.aspx");
        }
        protected void MyBtnHandler2(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //RecipeSearch.Service1Client recipeSearch = new RecipeSearch.Service1Client();

            string id = btn.CommandArgument;

            Console.WriteLine(id);
            HttpContext.Current.Session["recipeId"] = id;
            Response.Redirect("TryItNutrition.aspx");
        }
    }
}