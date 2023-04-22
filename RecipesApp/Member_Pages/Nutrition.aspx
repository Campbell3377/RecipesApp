<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nutrition.aspx.cs" Inherits="RecipesApp.Nutrition" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <!-- <asp:Button ID="Back_Button" runat="server" OnClick="Back_Click" Text="Back to Service Index" /> -->
    <div class="jumbotron" width="100%">
        <h1>Get Nutrition Information</h1>
        <p class="lead">Using a recipe id, from browse/see full recipe (or default if none is selected), get nutrition information</p>

        <p>
            <asp:Button ID="nutriButton" runat="server" OnClick="Nutrition_Click" Text="Get Nutrition" />
            <br />
            <span>
                <asp:Image ID="nutritionImage" Width="35%" ImageUrl="" runat="server"></asp:Image>
                <asp:Image ID="nutritionWidgetImage" Width="64%" ImageUrl="" runat="server"></asp:Image>
            </span>
        </p>
    </div>

</asp:Content>
