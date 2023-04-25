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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SearchProductsButton_Click(object sender, EventArgs e)
        {
            string query = search.Text;

            List<Ingredient> ingredients = createRecipe.SearchIngredients(query).ToList();

            string display = "";

            int i = 1;

            display += "<table><tr><th>Number</th><th>Name</th><th>ID</th></tr>";

            foreach (Ingredient ingredient in ingredients)
            {
                display += "<tr><td>" + i + "." + "</td><td>" + ingredient.Name + "</td><td>" + ingredient.Id + "</td>";
                i++;
            }

            display += "</table>";

            Result.Text = display;
        }

        protected void AddToRecipe_Click(object sender, EventArgs e)
        {
            string file = fileName.Text;
            int productID = Int32.Parse(productId.Text);
            string recipeName = recipeNameTextBox.Text;

            createRecipe.AddToRecipe(file, productID, recipeName);
        }

        protected void GetCreatedRecipe_Click(object sender, EventArgs e)
        {
            string file = loadFileName.Text;

            List<Recipe> recipes = createRecipe.GetCreatedRecipes(file).ToList();

            string display = "";

            int i = 1;

            display = "<table><tr><th>Number</th><th>Recipe</th><th>Ingredients</th></tr>";

            foreach (Recipe recipe in recipes)
            {
                display += "<tr><td>" + i + "." + "</td><td>" + recipe.Name + "</td><td>";

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    display += ingredient.Name + " (" + ingredient.Id + "), ";
                }

                display = display.TrimEnd(',', ' ') + "</td></tr>";
                i++;
            }

            display += "</table>";

            LoadResult.Text = display;
        }

    }
}