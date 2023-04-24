<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="RecipesApp.Staff" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Add Staff Member</h1>
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="AddStaffButton" runat="server" Text="Add Staff" OnClick="AddStaffButton_Click" />
        <asp:Label ID="ResultLabel" runat="server" EnableViewState="false" />
    </div>
    <div>
        <h1>Staff List</h1>
        <asp:Repeater ID="StaffRepeater" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>Username</th>
                        <th>Password</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ((XElement)Container.DataItem).Element("username").Value %></td>
                    <td><%# ((XElement)Container.DataItem).Element("password").Value %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <h1>Members List</h1>
        <asp:Repeater ID="MembersRepeater" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>Username</th>
                        <th>Hash</th>
                        <th>Salt</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# ((XElement)Container.DataItem).Element("username").Value %></td>
                    <td><%# ((XElement)Container.DataItem).Element("hash").Value %></td>
                    <td><%# ((XElement)Container.DataItem).Element("salt").Value %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
