using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WSDL_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class SaveAndLoadRecipeService : ISaveAndLoadRecipeService
    {
        private string APIKey = "35742efe533b41d683a0fa8d8cb82f85";

        /*The SaveRecipesToXML function saves a recipe from the spoonacular API to an XML file*/
        public void SaveRecipesToXml(int recipeId, string fileName)
        {
            //Get the recipe based on the ID
            var url = "https://api.spoonacular.com/recipes/" + recipeId + "/information?apiKey=" + APIKey;
            var client = new WebClient();
            var json = client.DownloadString(url);
            var recipeInfo = JsonConvert.DeserializeObject<RecipeInfo>(json);

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            //Add the recipe info to a list to be written
            List<RecipeInfo> recipes = ReadRecipesFromXml(fileName);
            recipes.Add(recipeInfo);

            XmlSerializer serializer = new XmlSerializer(typeof(List<RecipeInfo>));
            using (FileStream file = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(file, recipes);
            }
        }

        /*The ReadRecipesFromXml returns a list of recipe info from an XML File*/
        public List<RecipeInfo> ReadRecipesFromXml(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(List<RecipeInfo>));
            //If the file exists, return the file contents and if not return an empty list
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<RecipeInfo>)serializer.Deserialize(file);
                }
                catch (InvalidOperationException)
                {
                    return new List<RecipeInfo>();
                }
            }
        }
    }
}
