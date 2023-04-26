<%@ Page Title="Create Recipe" Language="C#" MasterPageFile="~/SiteMember.Master" AutoEventWireup="true" CodeBehind="CreateRecipe.aspx.cs" Inherits="RecipesApp.CreateRecipe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MemberContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <div>http://webstrar192.fulton.asu.edu/page3/CreateRecipeService.svc</div>
        <br />
        <div>Create recipes by searching for grocery products as ingredients and adding them to an XML file as a recipe</div>
        <br />
        <div>Search: (Chicken, Olive Oil, Yogurt)</div>
        <asp:TextBox ID="search" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SearchProductsButton" runat="server" Text="Search Products" OnClick="SearchProductsButton_Click" />
        <br />
        <br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <div>Product ID from above</div>
        <asp:TextBox ID="productId" runat="server"></asp:TextBox>
        <br />
        <br />
        <div>Recipe name:</div>
        <asp:TextBox ID="recipeNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddToRecipe" runat="server" Text="Add to Recipe" OnClick="AddToRecipe_Click" />
        <br />
        <br />
        <asp:Label ID="LoadResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
