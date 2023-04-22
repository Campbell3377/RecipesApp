using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace WSDL_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CreateRecipeService : ICreateRecipeService
    {
        private string APIKey = "35742efe533b41d683a0fa8d8cb82f85";

        /*The Search Producs function will call the Spoonacular API to search for products given a query*/
        public List<Ingredient> SearchProducts(string query)
        {

            //Get the product list from Spoonacular
            string apiUrl = "https://api.spoonacular.com/food/products/search?apiKey=" + APIKey + "&number=10&query=" + query;
            string responseJson = new WebClient().DownloadString(apiUrl);

            //Add the products to a list to be written
            dynamic response = JsonConvert.DeserializeObject(responseJson);
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (var product in response.products)
            {
                ingredients.Add(new Ingredient
                {
                    Title = product.title,
                    Id = product.id,
                });
            }

            return ingredients;
        }

        /*The AddToRecipe function will add the created recipe to its own XML file*/
        public void AddToRecipe(string fileName, int productId)
        {
            //Get the product information from Spoonacular
            var url = "https://api.spoonacular.com/food/products/" + productId + "?apiKey=" + APIKey;
            var client = new WebClient();
            var json = client.DownloadString(url);
            var recipeInfo = JsonConvert.DeserializeObject<Ingredient>(json);

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            //Get the previous ingredients from the created recipe file
            List<Ingredient> recipes = GetCreatedRecipes(fileName);
            recipes.Add(recipeInfo);

            //Add the new updated recipes list to the file
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ingredient>));
            using (FileStream file = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(file, recipes);
            }
        }

        /*The GetCreatedRecipes function will retrieve all the ingredients form the created recipe*/
        public List<Ingredient> GetCreatedRecipes(string fileName)
        {
            //Open an xml file to write to
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ingredient>));
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                //Read from the file if it exists and if not return an empty list
                try
                {
                    return (List<Ingredient>)serializer.Deserialize(file);
                }
                catch (InvalidOperationException)
                {
                    return new List<Ingredient>();
                }
            }
        }
    }
}
