using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace WSDL_Services
{
    [ServiceContract]
    public interface ICreateRecipeService
    {

        [OperationContract]
        List<Ingredient> SearchIngredients(string query);

        [OperationContract]
        void AddToRecipe(string fileName, int ingredientId, string recipeName);

        [OperationContract]
        List<Recipe> GetCreatedRecipes(string fileName);
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
