<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/SiteMember.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="RecipesApp.Browse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MemberContent" runat="server">
    <br />
    <!-- <asp:Button ID="Back_Button3" runat="server" OnClick="Back_Click" Text="Back to Service Index" /> -->
    <div class="jumbotron">
        <h1>Browse Recipes</h1>
        <p class="lead">Search for recipes from Spoonacular API with an optional search and filters.</p>
        <asp:TextBox ID="query" runat="server" Width="264px"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter Search" />
        </p>
        <p>
            <asp:DropDownList ID="DropDownCuisine" runat="server">
                <asp:ListItem>Cuisine</asp:ListItem>
                <asp:ListItem>African</asp:ListItem>
                <asp:ListItem>British</asp:ListItem>
                <asp:ListItem>Cajun</asp:ListItem>
                <asp:ListItem>Caribbean</asp:ListItem>
                <asp:ListItem>Chinese</asp:ListItem>
                <asp:ListItem>Eastern European</asp:ListItem>
                <asp:ListItem>European</asp:ListItem>
                <asp:ListItem>French</asp:ListItem>
                <asp:ListItem>German</asp:ListItem>
                <asp:ListItem>Greek</asp:ListItem>
                <asp:ListItem>Indian</asp:ListItem>
                <asp:ListItem>Irish</asp:ListItem>
                <asp:ListItem>Italian</asp:ListItem>
                <asp:ListItem>Japanese</asp:ListItem>
                <asp:ListItem>Jewish</asp:ListItem>
                <asp:ListItem>Korean</asp:ListItem>
                <asp:ListItem>Latin American</asp:ListItem>
                <asp:ListItem>Mediterranean</asp:ListItem>
                <asp:ListItem>Mexican</asp:ListItem>
                <asp:ListItem>Middle Eastern</asp:ListItem>
                <asp:ListItem>Nordic</asp:ListItem>
                <asp:ListItem>Southern</asp:ListItem>
                <asp:ListItem>Spanish</asp:ListItem>
                <asp:ListItem>Thai</asp:ListItem>
                <asp:ListItem>Vietnamese</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownDiet" runat="server">
                <asp:ListItem>Diet</asp:ListItem>
                <asp:ListItem>Gluten Free</asp:ListItem>
                <asp:ListItem>Ketogenic</asp:ListItem>
                <asp:ListItem>Vegetarian</asp:ListItem>
                <asp:ListItem>Lacto-Vegetarian</asp:ListItem>
                <asp:ListItem>Ovo-Vegetarian</asp:ListItem>
                <asp:ListItem>Vegan</asp:ListItem>
                <asp:ListItem>Pescetarian</asp:ListItem>
                <asp:ListItem>Paleo</asp:ListItem>
                <asp:ListItem>Primal</asp:ListItem>
                <asp:ListItem>Low FODMAP</asp:ListItem>
                <asp:ListItem>Whole30</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>Intolerances:<asp:CheckBoxList ID="CheckBoxIntolerance" runat="server" CellSpacing="10" RepeatDirection="Horizontal">
            <asp:ListItem>Dairy</asp:ListItem>
            <asp:ListItem>Egg</asp:ListItem>
            <asp:ListItem>Gluten</asp:ListItem>
            <asp:ListItem>Grain</asp:ListItem>
            <asp:ListItem>Peanut</asp:ListItem>
            <asp:ListItem>Seafood</asp:ListItem>
            <asp:ListItem>Sesame</asp:ListItem>
            <asp:ListItem>Shellfish</asp:ListItem>
            <asp:ListItem>Soy</asp:ListItem>
            <asp:ListItem>Sulfite</asp:ListItem>
            <asp:ListItem>Tree Nut</asp:ListItem>
            <asp:ListItem>Wheat</asp:ListItem>
            </asp:CheckBoxList>
        </p>
    </div>

    <div class="jumbotron"">
        <div style="display:flex;flex-direction:column;align-items:center;">
  
            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <div style="margin-bottom:50px;text-align:center;background-color=white;border-radius=25%">
                        <h3> <%# DataBinder.Eval(Container.DataItem, "Title") %> </h3>  
                        <!-- <div Width="300px" Height="0" padding-bottom="100%" Position="relative"></div> -->
                        <asp:Image ID="Image1" Width ="500px" object-fit="cover" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>' />
                        <br />
                        <asp:Button ID="btn" runat="server" Text="See Full Recipe!" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>'  OnClick="MyBtnHandler" />
                        <asp:Button ID="btn2" runat="server" Text="Save Recipe" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "Id")%>'  OnClick="MyBtnHandler2" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
  
        </div>
    </div>

</asp:Content>
