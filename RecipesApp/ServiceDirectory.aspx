<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceDirectory.aspx.cs" Inherits="RecipesApp.ServiceDirectory" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        table {
            width: 75%;
            margin: 0 auto;
        }

        .tg {
            border-collapse: collapse;
            border-color: #ccc;
            border-spacing: 0;
        }

        .tg td {
            background-color: #fff;
            border-color: #ccc;
            border-style: solid;
            border-width: 1px;
            color: #333;
            font-family: Arial, sans-serif;
            font-size: 14px;
            overflow: hidden;
            padding: 10px 5px;
            word-break: normal;
        }

        .tg th {
            background-color: #f0f0f0;
            border-color: #ccc;
            border-style: solid;
            border-width: 1px;
            color: #333;
            font-family: Arial, sans-serif;
            font-size: 14px;
            font-weight: normal;
            overflow: hidden;
            padding: 10px 5px;
            word-break: normal;
        }

        .tg .tg-hq1h {
            border-color: inherit;
            color: #00E;
            text-align: center;
            text-decoration: underline;
            vertical-align: top
        }

        .tg .tg-c3ow {
            border-color: inherit;
            text-align: center;
            vertical-align: top
        }

        .tg .tg-3xi5 {
            background-color: #ffffff;
            border-color: inherit;
            text-align: center;
            vertical-align: top
        }
    </style>
    <div class="jumbotron">
        <h1>Services & Components</h1>
    </div>
    <table>
        <tr>
            <th class="tg-c3ow" colspan="5"><span style="font-weight:bold">Service Directory:</span> The team has completed the following services.</th>
        </tr>
        <tbody>
            <tr>
                <td class="tg-3xi5" colspan="5">This page is at:
                <a href="./ServiceDirectory.aspx"  rel="noopener noreferrer">http://webstrar192.fulton.asu.edu/ServiceDirectory.aspx</a> <!-- target="_blank" -->
                </td>
            </tr>
            <tr>
                <td class="tg-3xi5" colspan="5">This project is developed by: Sean Campbell and Blake Moler</td>
            </tr>
            <tr>
                <td class="tg-c3ow"><b>Provider Name</b></td>
                <td class="tg-c3ow"><b>Service Name, with input and output</b></td>
                <td class="tg-c3ow"><b>TryIt link</b></td>
                <td class="tg-c3ow"><b>Service Description</b></td>
                <td class="tg-c3ow"><b>Actual Resources used to implement service</b></td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Create User (User Control)</td>
                <td class="tg-c3ow"><a href="./UserAuth.aspx">TryIt</a></td>
                <td class="tg-c3ow">Assigns a user to an account when they sign in, which they can then use to login</td>
                <td class="tg-c3ow">Account information will be stored to and retrieved from xml file</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">DLL Class</td>
                <td class="tg-c3ow"><a href="./UserAuth.aspx">TryIt</a></td>
                <td class="tg-c3ow">Handles password hashing and storage to xml for creating user and login</td>
                <td class="tg-c3ow">Account information will be stored to and retrieved from members xml file</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Cookies</td>
                <td class="tg-c3ow"><a href="./UserAuth.aspx">TryIt</a></td>
                <td class="tg-c3ow">Handles password hashing and storage to xml for creating user and login</td>
                <td class="tg-c3ow">Account information will be stored to and retrieved from members xml file</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Create User (User Control)</td>
                <td class="tg-c3ow"><a href="./UserAuth.aspx">TryIt</a></td>
                <td class="tg-c3ow">Assigns a user to an account when they sign in, which they can then use to login</td>
                <td class="tg-c3ow">Account information will be stored to and retrieved from xml file</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Browse Recipes</td>
                <td class="tg-c3ow"><a href="./Member_Pages/RecipeBrowse.aspx">TryIt</a></td>
                <td class="tg-c3ow">Returns recipes based on given parameters</td>
                <td class="tg-c3ow">Recipe Information retrieved from spoonacular API</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Nutritional Analysis</td>
                <td class="tg-c3ow"><a href="./Member_Pages/Nutrition.aspx">TryIt</a></td>
                <td class="tg-c3ow">Returns nutrition information based on a given recipe</td>
                <td class="tg-c3ow">Retrieves nutritional breakdown of spoonacular recipe</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Sean</td>
                <td class="tg-c3ow">Get full recipe</td>
                <td class="tg-c3ow"><a href="./Member_Pages/FullRecipe.aspx">TryIt</a></td>
                <td class="tg-c3ow">Returns the full recipe after the user selects a recipe from browse</td>
                <td class="tg-c3ow">Retrieves recipe information using recipe id with spoonacular</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">XML file manipulation</td>
                <td class="tg-hq1h"><a href="./XMLFileUtils.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Searches, adds, and deletes information from an XML file</td>
                <td class="tg-c3ow">XML file</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">Global ASAX</td>
                <td class="tg-hq1h"><a href="./Error.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Handles events that happen within the application</td>
                <td class="tg-c3ow">An event handler to handle errors/exceptions that might happen</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">Meal Planning</td>
                <td class="tg-hq1h"><a href="./Member_Pages/MealPlanner.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Creates a weekly meal plan based on calories</td>
                <td class="tg-c3ow">Generates a meal plan for each day of the week using spoonacular API</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">Meal Recommendation</td>
                <td class="tg-hq1h"><a href="./Member_Pages/RecommendedRecipes.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Returns recipes related to on given ones</td>
                <td class="tg-c3ow">Gives a list of related recipes given a recipeID from the spoonacular API</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">Save/Load Recipes</td>
                <td class="tg-hq1h"><a href="./Member_Pages/SaveAndLoadRecipes.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Saves &amp; restores user recipes to an XML file</td>
                <td class="tg-c3ow">Saves recipe information from the spoonacular</td>
            </tr>
            <tr>
                <td class="tg-c3ow">Blake</td>
                <td class="tg-c3ow">Create Recipe</td>
                <td class="tg-hq1h"><a href="./Member_Pages/CreateRecipe.aspx"
                        rel="noopener noreferrer">TryIt</a></td>
                <!--target="_blank" add this to change to open new tab -->
                <td class="tg-c3ow">Create recipes based on store bought ingredients</td>
                <td class="tg-c3ow">Retrieves a list of recipes from Spoonacular</td>
            </tr>
        </tbody>
    </table>   
    
</asp:Content>
