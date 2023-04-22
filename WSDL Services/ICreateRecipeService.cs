using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSDL_Services
{
    [ServiceContract]
    public interface ICreateRecipeService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "search-products?query={query}", ResponseFormat = WebMessageFormat.Json)]
        List<Ingredient> SearchProducts(string query);

        [OperationContract]
        void AddToRecipe(string fileName, int productId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get-recipe?fileName={fileName}", ResponseFormat = WebMessageFormat.Json)]
        List<Ingredient> GetCreatedRecipes(string fileName);
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
