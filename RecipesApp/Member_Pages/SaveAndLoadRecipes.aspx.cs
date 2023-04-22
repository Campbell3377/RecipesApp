using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RecipesApp.SaveAndLoadRecipeService;

namespace RecipesApp
{

    public partial class SaveAndLoadRecipes : System.Web.UI.Page
    {

        SaveAndLoadRecipeServiceClient saveAndLoadRecipe = new SaveAndLoadRecipeServiceClient();
        //.SaveAndLoadRecipeServiceClient saveAndLoadRecipe = new SaveAndLoadRecipeService.SaveAndLoadRecipeServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SaveRecipeButton_Click(object sender, EventArgs e)
        {
            int recipeId = Int32.Parse(recipeID.Text);
            string file = fileName.Text;

            saveAndLoadRecipe.SaveRecipesToXml(recipeId, file);
        }
        protected void LoadRecipeButton_Click(object sender, EventArgs e)
        {
            string file = receiverFileName.Text;
            List<RecipeInfo> recipes = saveAndLoadRecipe.ReadRecipesFromXml(file).ToList();

            string display = "";

            int i = 1;

            display += "<table><tr><th>Name</th><th>ID</th><th>Image</th><th>Id</th><th>Source</th></tr>";

            foreach (RecipeInfo r in recipes)
            {
                display += "</tr><td>" + i + "." + "</td><td>" + r.Title + "</td><td>" + r.Image + "</td><td>" + r.Id + "</td><td>" + r.SourceUrl + "</td><tr>";
                i++;
            }

            display += "</table>";

            Result.Text = display;
        }
    }

}