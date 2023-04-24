<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="RecipesApp.AccessDenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>
        Access Denied
    </h2>
    <div>
        Please login using a staff account
    </div>
    <asp:Button ID="Button1" runat="server" Text="Go Back To Home" OnClick="Button1_Click" />
</body>
</html>
