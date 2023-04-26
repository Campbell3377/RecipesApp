using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp
{
    public class MealPlan
    {
        public List<Meal> Monday { get; set; }
        public List<Meal> Tuesday { get; set; }
        public List<Meal> Wednesday { get; set; }
        public List<Meal> Thursday { get; set; }
        public List<Meal> Friday { get; set; }
        public List<Meal> Saturday { get; set; }
        public List<Meal> Sunday { get; set; }
    }

    public class Meal
    {
        public string Name { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string SourceUrl { get; set; }
    }
    public partial class MealPlanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void generateMealPlan_Click(object sender, EventArgs e)
        {
            string calories = targetCalories.Text;
            string url = "http://webstrar192.fulton.asu.edu/page4/MealPlanService.svc/mealplan?targetCalories=" + calories;
            MealPlan mealPlan = new MealPlan();
            string result = "";
            string display = "";

            //Call the mealplanner service and set the mealPlan object
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    mealPlan = JsonConvert.DeserializeObject<MealPlan>(result);
                }
            }

            //Add inline styles for the table
            string tableStyle = "style='border-collapse: collapse; width: 100%;'";
            string headerStyle = "style='border: 1px solid #ddd; padding: 8px; text-align: left; background-color: #f2f2f2;'";
            string cellStyle = "style='border: 1px solid #ddd; padding: 8px; text-align: left;'";

            //Go through each day of the week and display the results to the table
            foreach (string day in new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" })
            {
                display += $"<h3>{day}</h3>";
                display += $"<table {tableStyle}><tr><th {headerStyle}>Name</th><th {headerStyle}>Ready In</th><th {headerStyle}>Servings</th><th {headerStyle}>Source</th></tr>";

                //Get the meals for the current day of the week
                List<Meal> meals = mealPlan.GetType().GetProperty(day).GetValue(mealPlan) as List<Meal>;

                //Display the meals to the frontend
                foreach (Meal meal in meals)
                {
                    display += $"<tr><td {cellStyle}>{meal.Name}</td><td {cellStyle}>{meal.ReadyInMinutes}</td><td {cellStyle}>{meal.Servings}</td><td {cellStyle}><a href='{meal.SourceUrl}' target='_blank'>View Recipe</a></td></tr>";
                }

                display += "</table>";
            }

            Result.Text = display;
        }
    }
}