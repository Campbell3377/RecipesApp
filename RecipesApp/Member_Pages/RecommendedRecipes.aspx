<%@ Page Title="Recommended Recipes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecommendedRecipes.aspx.cs" Inherits="RecipesApp.RecommendedRecipes" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <div>http://webstrar192.fulton.asu.edu/page4/RecipeRecommendationService.svc/similar?recipeID={recipeId}</div>
        <br />
        <div>Get recommended recipes based on a given recipeID from the Spoonacular API</div>
        <br />
        <div>Recipe ID:</div>
        <asp:TextBox ID="recipeID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="getRecommendedRecipes" runat="server" Text="Recommend Me Recipes!" OnClick="getRecommendedRecipes_Click" />
        <br />
        <br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
