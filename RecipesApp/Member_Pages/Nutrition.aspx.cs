using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp
{
    public partial class Nutrition : System.Web.UI.Page
    {
        public class NutritionInfo
        {
            public string WidgetUrl { get; set; }
            public string LabelUrl { get; set; }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            //Response.Redirect("http://webstrar192.fulton.asu.edu/index.html");    
        }

        protected void Nutrition_Click(object sender, EventArgs e)
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
                HttpResponseMessage response = httpClient.GetAsync($"api/nutrition/{id}").Result;

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
        }
    }
}