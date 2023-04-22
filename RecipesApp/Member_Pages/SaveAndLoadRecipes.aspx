<%@ Page Title="Save And Load Recipes" Language="C#" MasterPageFile="../Site.Master" AutoEventWireup="true" CodeBehind="SaveAndLoadRecipes.aspx.cs" Inherits="RecipesApp.SaveAndLoadRecipes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2><%: Title %>.</h2>

    <div>
        <div>http://webstrar192.fulton.asu.edu/page3/SaveAndLoadRecipeService.svc</div>
        <div>Save and retrieve recipes to and from an XML file</div>
        <br />
        <div>Recipe ID:</div>
        <asp:TextBox ID="recipeID" runat="server"></asp:TextBox>
        <br />
        <br />
        <div>File name: (must have .xml file extention)</div>
        <asp:TextBox ID="fileName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SaveRecipeButton" runat="server" Text="Save Recipe" OnClick="SaveRecipeButton_Click" />
        <br />
        <br />
        <div>File name: (must have .xml file extention)</div>
        <asp:TextBox ID="receiverFileName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="LoadRecipeButton" runat="server" Text="Load Recipes" OnClick="LoadRecipeButton_Click" />
        <br />
        <br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
