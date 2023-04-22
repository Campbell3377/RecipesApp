using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WSDL_Services
{
    [ServiceContract]
    public interface ISaveAndLoadRecipeService
    {
        [OperationContract]
        void SaveRecipesToXml(int recipeId, string fileName);

        [OperationContract]
        List<RecipeInfo> ReadRecipesFromXml(string fileName);

    }

    [DataContract]
    public class RecipeInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public string SourceUrl { get; set; }
    }
}
