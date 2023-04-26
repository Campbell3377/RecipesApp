<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RecipesApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Recipe Management App</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="./ServiceDirectory" class="btn btn-primary btn-lg">Services & Components &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>The following functionalities are offered by the app:</h2>
            <h3>1. Browse/Search Recipes</h3>
            <p>Returns recipes based on given parameters. The recipe information is retrieved from the Spoonacular API. Users can click on recipes to see more information</p>

            <h3>2. View Recipe Information and Nutrition</h3>
            <p>Returns the full recipe and recipe info after the user selects a recipe from browse. It retrieves recipe information using recipe ID with the Spoonacular API.
                      These functionalities are separate for tryit pages, but will used in tangent for the normal app flow. 
            </p>

            <h3>3. Save/Load Recipes</h3>
            <p>Saves and restores user recipes to an XML file. It saves recipe information from the Spoonacular API to an XML file and retrieves it.</p>

            <h3>3. Meal Recommendation</h3>
            <p>Returns recipes related to the given ones. It gives a list of related recipes given a recipe ID from the Spoonacular API.</p>

            <h3>4. Meal Planning</h3>
            <p>Creates a weekly meal plan based on calories. It generates a meal plan for each day of the week using the Spoonacular API.</p>

            <h3>5. Create Recipe</h3>
            <p>Create recipes based on store-bought ingredients. It retrieves a list of recipes from Spoonacular.</p>
        </div>
        <div class="col-md-4">
            <h2>How end users can signup for the services ?</h2>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            <asp:Button ID="BtnCreate" runat="server" Text="Create Account" OnClick="BtnCreate_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Member Pages" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Staff Pages" OnClick="Button2_Click" />
        </div>
        <div class="col-md-4">
            <h2>Test Cases (Services)</h2>
            <h3>1. Browse/Search Recipes</h3>
            <p>Test Case: Search (string), +multiple dropdowns for filtered result, all fields are optional, simply search to populate responses</p>

            <h3>2. View Recipe Information and Nutrition</h3>
            <p>Test Case: No inputs: Uses a default recipe or uses a recipe selected from the Browse/Search view
            </p>

            <h3>3. Save/Load Recipes</h3>
            <p>Test Case: Valid recipe id (Int - 1-1000000) and plain string file name (test.xml).</p>

            <h3>3. Meal Recommendation</h3>
            <p>Test Case: Enter an integer recipeId. Ex(1-1000000)</p>

            <h3>4. Meal Planning</h3>
            <p>Test Case: Integer Calorie amount (Ex.10000).</p>

            <h3>5. Create Recipe</h3>
            <p>Test Case: Use search to find product id, then enter a valid product id and a file name (Ex. test.xml).</p>

            <h2>Test Cases (Local Components)</h2>
            <h3>Create User (user control)</h3>
            <p>Test Case: Username(plain string, no special characters), Password (plain string)</p>

            <h3>Password hashing and storing member information (DLL)</h3>
            <p>Test Case: This component is used by the user creation and login, enter the username you create in the section below the user creation to see the hashed password</p>

            <h3>Cookies</h3>
            <p>Test Case: Click save login login info and login to save username to cookies. Upon revisiting this page, login field will be populated from cookies.
                Test Case 2: Cookies are used for form security. On User Auth page, attempting to navigate to the protected page will allow the user through once they have acquired a auth ticket that is stored in cookies
            </p>

            <h3>XML file manipulation</h3>
            <p>Description: searches, adds, and deletes information from an XML file</p>
            <p>Test Case: The staff page utilizes the xmlManipulation component. You can also go to the service directory and test the xml file manipulation page</p>
            <p>Input: query and filename</p>

            <h3>Global.asax file</h3>
            <p>Description: Handles global error events</p>
            <p>Test Case: Enter the wrong data type for a textfield or leave a textfield empty</p>

        </div>
    </div>

</asp:Content>
