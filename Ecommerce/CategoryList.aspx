<%@ Page Title="Category List" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="Ecommerce.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-category {
            transition: transform 0.2s ease-in-out;
            width: 100%;
            max-width: 300px; 
            margin: 0 auto; 
        }

        .card-category:hover {
            transform: scale(1.05);
        }

        .card-category img {
            width: 100%;
            height: 200px; 
            object-fit: contain; 
        }

        .card-category-body {
            text-align: center;
            padding: 10px;
        }

        .card-container {
            display: flex;
            justify-content: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <h1 class="h3 mb-4 text-gray-800">קטגוריות</h1>
        <div class="row">
            <asp:Repeater ID="RepeaterCategories" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6 mb-4 card-container">
                        <div class="card card-category">
                            <img src='<%# "/images/categories/" + Eval("Picname") %>' alt='<%# Eval("Cname") %>' class="card-img-top" />
                            <div class="card-category-body">
                                <h5 class="card-title"><%# Eval("Cname") %></h5>
                                <p class="card-text"><%# Eval("Cdesc") %></p>
                                <a href="ProductListByCategory.aspx?Cid=<%# Eval("Cid") %>" class="btn btn-primary">View Products</a>
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
