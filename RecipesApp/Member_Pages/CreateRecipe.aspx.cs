using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RecipesApp.CreateRecipeService;
using RecipesApp.SaveAndLoadRecipeService;

namespace RecipesApp
{
    public partial class CreateRecipe: Page
    {
        CreateRecipeServiceClient createRecipe = new CreateRecipeServiceClient();
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Gte the currently logged in user
            username = Session["username"] as string;
        }
        protected void SearchProductsButton_Click(object sender, EventArgs e)
        {
            string query = search.Text;

            //Get a list of products from the service
            List<Ingredient> ingredients = createRecipe.SearchIngredients(query).ToList();

            string display = "";

            int i = 1;

            //Add inline styles for the table
            string tableStyle = "style='border-collapse: collapse; width: 100%;'";
            string headerStyle = "style='border: 1px solid #ddd; padding: 8px; text-align: left; background-color: #f2f2f2;'";
            string cellStyle = "style='border: 1px solid #ddd; padding: 8px; text-align: left;'";

            display += $"<table {tableStyle}><tr><th {headerStyle}>Number</th><th {headerStyle}>Name</th><th {headerStyle}>ID</th><th {headerStyle}>Image</th></tr>";

            //Display the results from the service call
            foreach (Ingredient ingredient in ingredients)
            {
                string imageUrl = "https://spoonacular.com/cdn/ingredients_250x250/" + ingredient.Image;
                display += $"<tr><td {cellStyle}>{i}.</td><td {cellStyle}>{ingredient.Name}</td><td {cellStyle}>{ingredient.Id}</td><td {cellStyle}><img src='{imageUrl}' width='100' /></td></tr>";
                i++;
            }

            display += "</table>";

            Result.Text = display;
        }


        //Adds a product to a recipe file
        protected void AddToRecipe_Click(object sender, EventArgs e)
        {
            string file = username + "_created_recipes.xml";
            int productID = Int32.Parse(productId.Text);
            string recipeName = recipeNameTextBox.Text;

            createRecipe.AddToRecipe(file, productID, recipeName);
        }

    }
}