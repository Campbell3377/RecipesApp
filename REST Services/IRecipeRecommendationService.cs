using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace REST_Services
{
    [ServiceContract]
    public interface IRecipeRecommendationService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "similar?recipeID={recipeId}", ResponseFormat = WebMessageFormat.Json)]
        List<Recipe> GetSimilarRecipes(int recipeId);
    }

    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ReadyInMinutes { get; set; }

        [DataMember]
        public int Servings { get; set; }

        [DataMember]
        public string SourceUrl { get; set; }
    }
}
