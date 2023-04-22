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
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    mealPlan = JsonConvert.DeserializeObject<MealPlan>(result);
                }
            }

            display += "<h3>Sunday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Sunday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Monday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Monday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Tuesday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Tuesday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Wednesday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Wednesday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Thursday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Thursday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Friday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Friday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            display += "<h3>Saturday</h3>";

            display += "<table><tr><th>Name</th><th>Ready In</th><th>Servings</th><th>Source</th></tr>";

            foreach (Meal meal in mealPlan.Saturday)
            {
                display += "<tr><td>" + meal.Name + "</td><td>" + meal.ReadyInMinutes + "</td><td>" + meal.Servings + "</td><td>" + meal.SourceUrl + "</td></tr>";
            }

            display += "</table>";

            Result.Text = display;
        }
    }
}