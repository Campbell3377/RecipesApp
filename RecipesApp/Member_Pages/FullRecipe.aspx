<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullRecipe.aspx.cs" Inherits="RecipesApp.FullRecipe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <!-- <asp:Button ID="Back_Button2" runat="server" OnClick="Back_Click" Text="Back to Service Index" /> -->
    <div class="jumbotron">
        <h1>Full Recipe</h1>
        <p class="lead">Using recipe id from Recipe Search/Browse (or default if one is not selected), get full recipe information</p>
        <asp:Button ID="ButtonDefault" runat="server" Text="See Full Recipe" OnClick="ButtonDefault_Click" />
        <br />
    </div>

    <div class="jumbotron"">
        <div style="display:flex;flex-direction:column;align-items:center;">
            <h1>Recipe Information</h1>
            <div>
                <h2 id="RecipeName" runat="server"></h2>
                <asp:Image ID="RecipeImage" runat="server" />
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
            </div>
  
        </div>
    </div>

</asp:Content>
