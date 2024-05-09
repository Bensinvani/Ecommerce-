<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManeger/BackAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecommerce.AdminManeger.AdminPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container">
        <div class ="row">
            <!-- פקד רפיטר שחוזר על הקוד שבתוכו -->
            <asp:Repeater ID="RptClients" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card" style="width: 18rem;">
                          <img src="../images/Clients/<%#Eval("ClientPic") %>" class="card-img-top" alt="..." >
                          <div class="card-body">
                            <h5 class="card-title"><%#Eval("ClientFirstName")  %></h5>
                            <p class="card-text"><%#Eval("ClientPhone") %></p>
                            <p class="card-text"><%#Eval("ClientEmail") %></p>
                            <p class="card-text"><%#Eval("ClientId") %></p>
                            <p class="card-text"><%#Eval("ClientAddress") %></p>
                            <a href="#" class="btn btn-success"><%#Eval("ClientStatus") %></a>
                          </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
