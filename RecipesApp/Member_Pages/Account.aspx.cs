using RecipesApp.CreateRecipeService;
using RecipesApp.SaveAndLoadRecipeService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecipesApp.Member_Pages
{
    public partial class Account : System.Web.UI.Page
    {
        SaveAndLoadRecipeServiceClient saveAndLoadRecipe = new SaveAndLoadRecipeServiceClient();
        CreateRecipeServiceClient createRecipes = new CreateRecipeServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["username"] as string;
            if (username == null)
            {
                SavedInfo.Text = "Not signed in";
                return;
            }

            string saveFile = $"{username}.xml";
            string createdFile = $"{username}_created_recipes.xml";

            List<RecipeInfo> savedRecipes = saveAndLoadRecipe.ReadRecipesFromXml(saveFile).ToList();
            List<Recipe> createdRecipes = createRecipes.GetCreatedRecipes(createdFile).ToList();

            if (savedRecipes.Count == 0)
            {
                SavedInfo.Text = "No recipes Yet";
                return;
            }

            // Set the correct image URLs with the proper file extensions.
            foreach (RecipeInfo r in savedRecipes)
            {
                string imageType = Path.GetExtension(r.Image).Substring(1);
                r.Image = r.Image.Replace("." + imageType, "." + imageType.ToLower());
            }

            RepeaterSavedRecipes.DataSource = savedRecipes;
            RepeaterSavedRecipes.DataBind();

            RepeaterCreatedRecipes.DataSource = createdRecipes;
            RepeaterCreatedRecipes.DataBind();
        }

    }
}