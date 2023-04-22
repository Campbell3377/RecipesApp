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

            List<Ingredient> products = createRecipe.SearchProducts(query).ToList();

            string display = "";

            int i = 1;

            display += "<table><tr><th>Number</th><th>Name</th><th>ID</th></tr>";

            foreach (Ingredient product in products)
            {
                display += "<tr><td>" + i + "." + "</td><td>" + product.Title + "</td><td>" + product.Id + "</td>";
                i++;
            }

            display += "</table>";

            Result.Text = display;
        }

        protected void AddToRecipe_Click(object sender, EventArgs e)
        {
            string file = fileName.Text;
            int productID = Int32.Parse(productId.Text);

            createRecipe.AddToRecipe(file, productID);
        }

        protected void GetCreatedRecipe_Click(object sender, EventArgs e)
        {
            string file = loadFileName.Text;

            List<Ingredient> ingredients = createRecipe.GetCreatedRecipes(file).ToList();

            string display = "";

            int i = 1;

            display = "<table><tr><th>Number</th><th>Name</th><th>ID</th></tr>";

            foreach (Ingredient ingredient in ingredients)
            {
                display += "<tr><td>" + i + "." + "</td><td>" + ingredient.Title + "</td><td>" + ingredient.Id + "</td></tr>";
                i++;
            }

            display += "</table>";

            LoadResult.Text = display;
        }
    }
}