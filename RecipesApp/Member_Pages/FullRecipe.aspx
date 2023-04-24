<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullRecipe.aspx.cs" Inherits="RecipesApp.FullRecipe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="Back_Button2" runat="server" OnClick="Back_Click" Text="Back to Default Page" />

    <div class="jumbotron"">
        <div style="display:flex;flex-direction:column;align-items:center;">
            <h1>Recipe Information</h1>
            <div>
                <h2 id="RecipeName" runat="server"></h2>
                <asp:Image ID="RecipeImage" runat="server" />
                <br />
                <asp:Button ID="BtnSaveRecipe" runat="server" Text="Save Recipe" OnClick="BtnSaveRecipe_Click" />
                <p>Serves: <span id="ServingCount" runat="server"></span></p>
                <p>Ready in: <span id="ReadyInMinutes" runat="server"></span> minutes</p>

                <h3>Ingredients</h3>
                <asp:Repeater ID="IngredientRepeater" runat="server">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Original") %>' /><br />
                    </ItemTemplate>
                </asp:Repeater>

                <h3>Summary</h3>
                <p id="RecipeSummary" runat="server"></p>
                <br />
                <span>
                    <asp:Image ID="nutritionImage" Width="35%" ImageUrl="" runat="server"></asp:Image>
                    <asp:Image ID="nutritionWidgetImage" Width="64%" ImageUrl="" runat="server"></asp:Image>
                </span>
            </div>
  
        </div>
    </div>

    <div class="jumbotron"">
        <div style="display:flex;flex-direction:column;align-items:center;">
            <h1>Similar Recipes</h1>
            <asp:label ID="Result" runat="server" Text=""></asp:label>
  
        </div>
    </div>

</asp:Content>
