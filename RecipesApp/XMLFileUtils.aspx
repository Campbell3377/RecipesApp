<%@ Page Title="XML File Manipulation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XMLFileUtils.aspx.cs" Inherits="RecipesApp.XMLFileUtils" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <div>Add, Delete, or Search an XML file</div>
        <br />
        <div>XML file path</div>
        <asp:TextBox ID="XmlFileName" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <div>---Search---</div>
        <br />
        <div>XML Path Expression</div>
        <asp:TextBox ID="xmlPathExpression" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SearchElementsButton" runat="server" Text="Search for Element" OnClick="SearchElementsButton_Click" />
        <br />
        <br />
        <asp:Label ID="SearchResult" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <div>---Add---</div>
        <br />
        <div>Parent Element Name</div>
        <asp:TextBox ID="parentElementName" runat="server"></asp:TextBox>
        <br />
        <br />
        <div>Element Name</div>
        <asp:TextBox ID="addElementName" runat="server"></asp:TextBox>
        <br />
        <br />
        <div>Element Value</div>
        <asp:TextBox ID="addElementValue" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddElementButton" runat="server" Text="Add Element" OnClick="AddElementButton_Click" />
        <br />
        <br />
        <asp:Label ID="AddResult" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <div>---Delete---</div>
        <br />
        <div>Element Name</div>
        <asp:TextBox ID="delElementName" runat="server"></asp:TextBox>
        <br />
        <br />
        <div>Element Value</div>
        <asp:TextBox ID="delElementValue" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="DelElementButton" runat="server" Text="Delete Element" OnClick="DelElementButton_Click" />
        <br />
        <br />
        <asp:Label ID="DelResult" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
