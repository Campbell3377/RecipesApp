using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace REST_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RecipeRecommendationService : IRecipeRecommendationService
    {
        private string APIKey = "35742efe533b41d683a0fa8d8cb82f85";

        /*The GetSimilarRecipes function returns a list of related recipes given a recipeID from Spoonacular */

        public List<Recipe> GetSimilarRecipes(int recipeId)
        {
            //Get the related recipes from the Spoonacular API
            string apiUrl = "https://api.spoonacular.com/recipes/" + recipeId + "/similar?apiKey=" + APIKey;
            string responseJson = new WebClient().DownloadString(apiUrl);

            //Add that information to a list to be returned
            dynamic response = JsonConvert.DeserializeObject(responseJson);
            List<Recipe> recipes = new List<Recipe>();

            //Iterate through the response and update the object to be added
            foreach (var recipe in response)
            {
                recipes.Add(new Recipe
                {
                    Name = recipe.title,
                    Id = recipe.id,
                    ReadyInMinutes = recipe.readyInMinutes,
                    Servings = recipe.servings,
                    SourceUrl = recipe.sourceUrl
                });
            }

            return recipes;
        }
    }
}
