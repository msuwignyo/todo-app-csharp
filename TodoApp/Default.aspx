<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="lib/axios/axios.min.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mt-2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="TodoListRepeater" runat="server">
                    <HeaderTemplate>
                        <ul class="list-group">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="list-group-item d-flex justify-content-between" id="todo-<%# DataBinder.Eval(Container.DataItem, "Id") %>">
                            <div>
                                <%# DataBinder.Eval(Container.DataItem, "Id") %>.&nbsp;
                                <%# DataBinder.Eval(Container.DataItem, "Title") %>
                            </div>
                            <div>
                                <asp:Button runat="server" OnClick="DeleteTodo" CssClass="btn btn-danger" Text="DELETE" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "Id") %> />
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</asp:Content>
