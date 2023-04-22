using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp
{
    public partial class RecommendedRecipes : System.Web.UI.Page
    {
        public class Recipe
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int ReadyInMinutes { get; set; }
            public int Servings { get; set; }
            public string SourceUrl { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void getRecommendedRecipes_Click(object sender, EventArgs e)
        {
            string recipe = recipeID.Text;
            string url = "http://webstrar192.fulton.asu.edu/page4/RecipeRecommendationService.svc/similar?recipeID=" + recipe;
            List<Recipe> recipes = new List<Recipe>();
            string result = "";
            string display = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    recipes = JsonConvert.DeserializeObject<List<Recipe>>(result);
                }
            }

            int i = 1;

            display += "<table><tr><th>Name</th><th>ID</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Recipe r in recipes)
            {
                display += "</tr><td>" + i + "." + "</td><td>" + r.Name + "</td><td>" + r.Id + "</td><td>" + r.ReadyInMinutes + "</td><td>" + r.Servings + "</td><td>" + r.SourceUrl + "</td></tr>";
                i++;
            }

            display += "</table>";

            Result.Text = display;
        }
    }
}