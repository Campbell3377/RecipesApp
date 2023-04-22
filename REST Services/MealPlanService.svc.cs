using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST_Services
{
    public class MealPlanService : IMealPlanService
    {
        private string APIKey = "35742efe533b41d683a0fa8d8cb82f85";

        public MealPlan GenerateMealPlan(int targetCalories)
        {
            MealPlan mealPlan = new MealPlan
            {
                Monday = GetMeals(targetCalories),
                Tuesday = GetMeals(targetCalories),
                Wednesday = GetMeals(targetCalories),
                Thursday = GetMeals(targetCalories),
                Friday = GetMeals(targetCalories),
                Saturday = GetMeals(targetCalories),
                Sunday = GetMeals(targetCalories)
            };

            return mealPlan;
        }

        /*The GetMeals function is a utility function that calls the Spoonacular API to return a meal plan for a day*/

        private List<Meal> GetMeals(int targetCalories)
        {
            //Get breakfast, lunch, and dinner meals
            string apiUrl = "https://api.spoonacular.com/mealplanner/generate?apiKey=" + APIKey + "&timeFrame=day&targetCalories=" + targetCalories;
            string responseJson = new WebClient().DownloadString(apiUrl);

            //Add this information to a list and return it
            dynamic response = JsonConvert.DeserializeObject(responseJson);
            List<Meal> meals = new List<Meal>();

            foreach (var meal in response.meals)
            {
                meals.Add(new Meal
                {
                    Name = meal.title,
                    ReadyInMinutes = meal.readyInMinutes,
                    Servings = meal.servings,
                    SourceUrl = meal.sourceUrl
                });
            }

            return meals;
        }
    }
}
