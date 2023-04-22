using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace RecipeRest.Controllers
{
    public class RecipeInfoController : ApiController
    {
        public RecipeInfo GetFullRecipe(string id)
        {
            int recipeid = Convert.ToInt32(id.ToString().Trim());
            string url = $"https://api.spoonacular.com/recipes/{recipeid}/information?apiKey=db4940e6e75e40de952dc6131941a7b5";
            string url2 = url;
            string json = new WebClient().DownloadString(url);

            dynamic data = JObject.Parse(json);

            RecipeInfo recipe = new RecipeInfo
            {
                Title = data.title,
                Image = data.image,
                Servings = data.servings,
                ReadyInMinutes = data.readyInMinutes,
                AggregateLikes = data.aggregateLikes,
                Ingredients = new List<Ingredient>(),
                Summary = data.summary
            };
            var ing = data.extendedIngredients;

            foreach (var ingredient in data.extendedIngredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredient.name,
                    Original = ingredient.original
                });
            }

            return recipe;
        }
    }

    public class RecipeInfo
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public int AggregateLikes { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Summary { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public string Original { get; set; }


    }
}
