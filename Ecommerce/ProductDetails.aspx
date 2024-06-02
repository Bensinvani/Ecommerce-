<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Ecommerce.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom CSS if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">Product Details</h1>
        
        <div class="card shadow mb-4">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Image ID="ImgProduct" runat="server" CssClass="img-fluid" AlternateText="Product Image" />
                    </div>
                    <div class="col-lg-6">
                        <h2 id="LblPname" runat="server"></h2>
                        <p id="LblPdesc" runat="server"></p>
                        <p>Price: <span id="LblPrice" runat="server"></span></p>
                    </div>
                </div>
            </div>
        </div>
        
        <a href="javascript:history.back()" class="btn btn-secondary">Back</a>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <!-- Footer content if needed -->
</asp:Content>
