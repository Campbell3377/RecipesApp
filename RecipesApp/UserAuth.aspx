<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserAuth.aspx.cs" Inherits="RecipesApp.UserAuth" %>
<%@ Register TagPrefix="uc" TagName="CreateUser" 
    Src="~/CreateUser.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <br />
    <!-- <asp:Button ID="Back_Button4" runat="server" OnClick="Back_Click" Text="Back to Service Index" /> -->
    <div class="jumbotron">
        <h1>User Authentication</h1>
        <p class="lead">Create a user and store user information and verify login information
        </p>
        <br />

        <h2>Create Account:</h2>
        <p class="lead">User control for user creation. Uses Hash class from DLL library which handles password encryption and storage into members.xml.
                        Returns true if user is added and false if the username is taken
        </p>

        <uc:CreateUser runat="server" />

        <h3>Check hashed password:</h3>
        <p class="lead">Enter username used to create account to see hashed pashword
        </p>
        <span><label>Enter Username or Email:</label><asp:TextBox ID="TextBoxCheckUser" runat="server" Width="264px"></asp:TextBox> </span> <br />
        <span><asp:Button ID="BtncheckHash" runat="server" OnClick="CheckHash_Click" Text="Get Password" /><label ID="hashLabel" runat="server">Result:</label></span>
        <br />

        <h2>Login Verification:</h2>
        <p class="lead">Verify user information using email/username and password
        </p>
        <span><label>Enter Username or Email:</label><asp:TextBox ID="userVerify" runat="server" Width="264px"></asp:TextBox></span>
        <br />
        <span><label>Enter Password:</label>
        <asp:TextBox ID="passwordVerify" TextMode="Password" runat="server" Width="264px"></asp:TextBox>
        <br />
        <asp:CheckBox ID="CheckBoxSaveLogin" runat="server" Text="Save Login Information"/>
        <br />
        </span>
        <p>
            <asp:Button ID="loginButton" runat="server" OnClick="Login_Click" Text="Login" />
            <br />
            <h3>Result: </h3>
            <p><span ID="loginResult" runat="server" Width="753px"></span></p>
            <!-- <p><span ID="CookieLabel" runat="server" Width="753px"></span></p> -->
        </p>
    </div>
</asp:Content>
