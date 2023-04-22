using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_Services
{
    [ServiceContract]
    public interface IMealPlanService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "mealplan?targetCalories={targetCalories}", ResponseFormat = WebMessageFormat.Json)]
        MealPlan GenerateMealPlan(int targetCalories);
    }

    [DataContract]
    public class MealPlan
    {
        [DataMember]
        public List<Meal> Monday { get; set; }

        [DataMember]
        public List<Meal> Tuesday { get; set; }

        [DataMember]
        public List<Meal> Wednesday { get; set; }

        [DataMember]
        public List<Meal> Thursday { get; set; }

        [DataMember]
        public List<Meal> Friday { get; set; }

        [DataMember]
        public List<Meal> Saturday { get; set; }

        [DataMember]
        public List<Meal> Sunday { get; set; }
    }

    [DataContract]
    public class Meal
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ReadyInMinutes { get; set; }

        [DataMember]
        public int Servings { get; set; }

        [DataMember]
        public string SourceUrl { get; set; }
    }
}
