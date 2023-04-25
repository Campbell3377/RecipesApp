<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="RecipesApp.Member_Pages.Account" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Saved Recipes</h2>
        <div style="display: flex; flex-wrap: wrap;">
            <asp:Repeater ID="RepeaterSavedRecipes" runat="server">
                <ItemTemplate>
                    <div class="recipe-item" style="box-sizing: border-box; margin: 10px; width: calc(33.333% - 20px); text-align: center;">
                        <h3><%# Eval("Title") %></h3>
                        <asp:Image ID="RecipeImage" runat="server" ImageUrl='<%# Eval("Image") %>' Width="300" />
                        <p>
                            <asp:HyperLink ID="SourceUrlLink" runat="server" NavigateUrl='<%# Eval("SourceUrl") %>' Target="_blank">View Recipe</asp:HyperLink>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Label ID="SavedInfo" runat="server"></asp:Label>
        <h2>Created Recipes</h2>
        <div style="display: flex; flex-wrap: wrap;">
            <asp:Repeater ID="RepeaterCreatedRecipes" runat="server">
                <ItemTemplate>
                    <div class="recipe-item" style="display: inline-block; margin: 10px; text-align: center; vertical-align: top;">
                        <h3><%# Eval("Name") %></h3>
                        <p>
                            Ingredients:
                            <asp:Repeater ID="RepeaterIngredients" runat="server" DataSource='<%# Eval("Ingredients") %>'>
                                <ItemTemplate>
                                    <div style="display: block;">
                                        <%# Eval("Name") %> (<%# Eval("Id") %>)
                                        <asp:Image ID="IngredientImage" runat="server" ImageUrl='<%# "https://spoonacular.com/cdn/ingredients_250x250/" + Eval("Image") %>' Width="50" />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Label ID="CreatedInfo" runat="server"></asp:Label>
    </asp:Content>
