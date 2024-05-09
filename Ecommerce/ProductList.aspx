<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Ecommerce.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container">
        <div class ="row">
            <!-- פקד רפיטר שחוזר על הקוד שבתוכו -->
            <asp:Repeater ID="RptProducts" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="card" style="width: 18rem;">
                          <img src="images/products/<%#Eval("Picname") %>" class="card-img-top" alt="...">
                          <div class="card-body">
                            <h5 class="card-title"><%#Eval("Pname")  %></h5>
                            <p class="card-text"><%#Eval("Price") %></p>
                            <a href="#" class="btn btn-primary">Add to cart</a>
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
