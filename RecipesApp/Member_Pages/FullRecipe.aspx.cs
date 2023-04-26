using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Net.Http;
using RecipesApp.SaveAndLoadRecipeService;


namespace RecipesApp
{
    public class RecipeInfoDecode
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public int AggregateLikes { get; set; }
        public List<IngredientDecode> Ingredients { get; set; }
        public string Summary { get; set; }
    }


    public class IngredientDecode
    {
        private string name;        //Naming convention comes from api, original is the one to use
        private string original;
        public IngredientDecode(string name, string original)
        {
            this.name = name;
            this.original = original;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Original
        {
            get
            {
                return original;
            }
        }
    }

    public class NutritionInfo
    {
        public string WidgetUrl { get; set; }
        public string LabelUrl { get; set; }
    }

    public partial class FullRecipe : System.Web.UI.Page
    {
        public class Recipe
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int ReadyInMinutes { get; set; }
            public int Servings { get; set; }
            public string SourceUrl { get; set; }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default");    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "716429";    //default id for TryIt
            if (Session["recipeId"] != null) id = (string)Session["recipeId"];


            using (HttpClient httpClient = new HttpClient())
            {
                // Set the base address of the service
                httpClient.BaseAddress = new Uri("http://webstrar192.fulton.asu.edu/page1/");
                //httpClient.BaseAddress = new Uri("https://localhost:44385/");

                // Make an HTTP GET request to the service endpoint and get the response
                HttpResponseMessage response = httpClient.GetAsync($"api/recipeinfo/{id}").Result;

                // If the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON response to a Recipe object
                    RecipeInfoDecode recipe = JsonConvert.DeserializeObject<RecipeInfoDecode>(jsonResponse);

                    // Access the recipe properties and do something with them


                    RecipeName.InnerText = recipe.Title;
                    RecipeImage.ImageUrl = recipe.Image;
                    ServingCount.InnerText = recipe.Servings.ToString();
                    ReadyInMinutes.InnerText = recipe.ReadyInMinutes.ToString();
                    RecipeSummary.InnerHtml = recipe.Summary.ToString();

                    IngredientRepeater.DataSource = recipe.Ingredients;
                    IngredientRepeater.DataBind();

                }
                else
                {
                    // If the response is not successful, log the error
                    string errorResponse = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Error calling the service: " + errorResponse);
                }

                
            }
            //RecipeSearch.Service1Client recipeSearch = new RecipeSearch.Service1Client();

            string stringId = "716429";    //default id for TryIt
            if (Session["recipeId"] != null) stringId = (string)Session["recipeId"];


            using (HttpClient httpClient = new HttpClient())
            {

                // Set the base address of the service
                httpClient.BaseAddress = new Uri("http://webstrar192.fulton.asu.edu/page1/");
                //httpClient.BaseAddress = new Uri("https://localhost:44385/");

                // Make an HTTP GET request to the service endpoint and get the response
                HttpResponseMessage response = httpClient.GetAsync($"api/nutrition/{stringId}").Result;

                // If the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the JSON response to a Recipe object
                    NutritionInfo info = JsonConvert.DeserializeObject<NutritionInfo>(jsonResponse);

                    nutritionImage.ImageUrl = info.LabelUrl.Replace("\"", "");
                    nutritionWidgetImage.ImageUrl = info.WidgetUrl.Replace("\"", "");

                    // Access the recipe properties and do something with them


                }
                else
                {
                    // If the response is not successful, log the error
                    string errorResponse = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Error calling the service: " + errorResponse);
                }
            }

            getRecommendations(id);
        }

        protected void getRecommendations(string id)
        {
            string url = "http://webstrar192.fulton.asu.edu/page4/RecipeRecommendationService.svc/similar?recipeID=" + id;
            List<Recipe> recipes = new List<Recipe>();
            string result = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    recipes = JsonConvert.DeserializeObject<List<Recipe>>(result);
                }
            }

            string display = "<table><tr><th>No.</th><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";
            int i = 1;

            foreach (Recipe r in recipes)
            {
                display += "</tr><td>" + i + "." + "</td><td>" + r.Name + "</td><td>" + r.ReadyInMinutes + "</td><td>" + r.Servings + "</td><td><a href=\"" + r.SourceUrl + "\">" + r.SourceUrl + "</a></td></tr>";
                i++;
            }

            display += "</table>";

            Result.Text = display;

        }

        protected void BtnSaveRecipe_Click(object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            int id = 0;
            if (Session["recipeId"] != null) { id = Convert.ToInt32(Session["recipeId"]); }

            string path = "" + user + ".xml";

            if (id != 0)
            {
                SaveAndLoadRecipeServiceClient saveAndLoadRecipe = new SaveAndLoadRecipeServiceClient();
                saveAndLoadRecipe.SaveRecipesToXml(id, path);
            }
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
    }
}