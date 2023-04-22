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
    public partial class FullRecipe : System.Web.UI.Page
    {
        protected void Back_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://webstrar192.fulton.asu.edu/index.html");    
        }

        protected void ButtonDefault_Click(object sender, EventArgs e)
        {
            //RecipeSearch.Service1Client recipeSearch = new RecipeSearch.Service1Client();

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

        }
    }
}