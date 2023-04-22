using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace RecipeSearch
{
    [XmlRoot(ElementName = "recipes")]
    public class Recipes
    {
        [XmlElement(ElementName = "offset")]
        public int Offset { get; set; }

        [XmlElement(ElementName = "number")]
        public int Number { get; set; }

        [XmlElement(ElementName = "results")]
        public List<Recipe> Results { get; set; }

        [XmlElement(ElementName = "totalResults")]
        public int TotalResults { get; set; }
    }

    public class Recipe
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }
        [XmlElement(ElementName = "imageType")]
        public string imageType { get; set; }
    }

    [XmlRoot(ElementName = "recipe")]
    public class FullRecipe
    {
        [XmlElement(ElementName = "id")]
        public int id { get; set; }

        [XmlElement(ElementName = "title")]
        public string title { get; set; }

        [XmlElement(ElementName = "image")]
        public string image { get; set; }

        [XmlElement(ElementName = "servings")]
        public int servings { get; set; }

        [XmlElement(ElementName = "readyInMinutes")]
        public int readyInMinutes { get; set; }

        [XmlElement(ElementName = "aggregateLikes")]
        public int aggregateLikes { get; set; }

        [XmlElement(ElementName = "extendedIngredients")]
        public List<Ingredient> ingredients { get; set; }

        [XmlElement(ElementName = "summary")]
        public string summary { get; set; }

        // Add other properties here as needed
    }

    public class Ingredient
    {
        [XmlElement(ElementName = "image")]
        public string image { get; set; }

        [XmlElement(ElementName = "original")]
        public string original { get; set; }
        // Add other properties here as needed
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Search(string query, string cuisine, string diet, string intolerances, int offset)
        {
            var client = new RestClient("https://api.spoonacular.com");
            var request = new RestRequest("recipes/search");
            request.AddQueryParameter("query", query);
            request.AddQueryParameter("number", 10);
            if (cuisine != "") request.AddQueryParameter("cuisine", cuisine);
            if (diet != "") request.AddQueryParameter("diet", diet);
            if (intolerances != "") request.AddQueryParameter("intolerances", intolerances);
            request.AddQueryParameter("offset", offset);
            request.AddQueryParameter("apiKey", "db4940e6e75e40de952dc6131941a7b5");
            var response = client.Execute<Recipes>(request);
            var serializer = new XmlSerializer(typeof(Recipes));
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, response.Data);
            return stringWriter.ToString();
        }

        public string SearchFullRecipe(int id)
        {
            var client = new RestClient("https://api.spoonacular.com");
            var request = new RestRequest("recipes");
            request.AddQueryParameter("id", id);
            request.AddQueryParameter("includeNutrition", false);
            var response = client.Execute<FullRecipe>(request);
            var serializer = new XmlSerializer(typeof(FullRecipe));
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, response.Data);
            return stringWriter.ToString();
        }
    }
}
