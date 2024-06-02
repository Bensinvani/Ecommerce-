<%@ Page Title="Products by Category" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductListByCategory.aspx.cs" Inherits="Ecommerce.ProductListByCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom CSS if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">Products in <asp:Literal ID="LitCategoryName" runat="server"></asp:Literal></h1>
        
        <div class="card shadow mb-4">
            <div class="card-body">
                <div class="row">
                    <asp:Repeater ID="RepeaterProducts" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                                <div class="card">
                                    <img src='<%# "/images/products/" + Eval("Picname") %>' alt='<%# Eval("Pname") %>' class="card-img-top" />
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Pname") %></h5>
                                        <p class="card-text">Price: <%# Eval("Price") %></p>
                                        <a href="ProductDetails.aspx?Pid=<%# Eval("Pid") %>" class="btn btn-primary">View Details</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        
        <a href="CategoryList.aspx" class="btn btn-secondary">Back to Categories</a>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <!-- Footer content if needed -->
</asp:Content>
