<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.ascx.cs" Inherits="RecipesApp.CreateUser" %>
<style>
		body {
			font-family: Arial, sans-serif;
			font-size: 16px;
			background-color: #f2f2f2;
		}

		.login-container {
			background-color: #fff;
			padding: 20px;
			border-radius: 10px;
			box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
			width: 300px;
			margin: 0 auto;
			margin-top: 50px;
		}

		h2 {
			margin-top: 0;
			text-align: center;
		}

		input[type="text"], input[type="password"] {
			width: 100%;
			padding: 10px;
			margin-bottom: 15px;
			border: none;
			border-radius: 5px;
			box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.1);
			font-size: 16px;
			color: #555;
			background-color: #fff;
			box-sizing: border-box;
		}

		button[type="submit"] {
			background-color: #4CAF50;
			color: #fff;
			border: none;
			border-radius: 5px;
			padding: 10px;
			font-size: 16px;
			cursor: pointer;
			width: 100%;
			box-sizing: border-box;
			transition: background-color 0.2s ease;
		}

		button[type="submit"]:hover {
			background-color: #3e8e41;
		}
	</style>
<div class="login-container">
		<h2>Create User</h2>
		<form>
			<label for="textboxUser">Username:</label>
			<asp:TextBox ID="textboxUser" runat="server"></asp:TextBox>
			<label for="textboxPass">Password:</label>
			<asp:TextBox ID="textboxPass" runat="server" TextMode="Password"></asp:TextBox>
			<asp:Button ID="createButton" type="submit" runat="server" OnClick="Button1_Click" Text="Create"></asp:Button>
			<p><span id="createResult" runat="server"></span></p>
		</form>
</div>