<%@ Page Title="Meal Planner" Language="C#" MasterPageFile="~/SiteMember.Master" AutoEventWireup="true" CodeBehind="MealPlanner.aspx.cs" Inherits="RecipesApp.MealPlanner" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MemberContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <div>http://webstrar192.fulton.asu.edu/page4/MealPlanService.svc/mealplan?targetCalories={targetCalories}</div>
        <br />
        <div>Get meal plans for every day of the week including breakfast, lunch, and dinner from the spoonacular API</div>
        <br />
        <div>Target calories:</div>
        <asp:TextBox ID="targetCalories" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="generateMealPlan" runat="server" Text="Generate Meal Plan" OnClick="generateMealPlan_Click" />
        <br />
        <br />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>