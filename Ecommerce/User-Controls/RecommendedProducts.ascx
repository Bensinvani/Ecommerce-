<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendedProducts.ascx.cs" Inherits="Ecommerce.User_Controls.RecommendedProducts" %>

<div id="recommendedProductsCarousel" class="carousel slide" data-bs-ride="carousel">
    <div class="carousel-inner">
        <asp:Repeater ID="rptRecommendedProducts" runat="server">
            <ItemTemplate>
                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                    <div class="card" style="width: 18rem;">
                        <img src="/images/products/<%# Eval("Picname") %>" class="card-img-top" alt="<%# Eval("Pname") %>">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Pname") %></h5>
                            <p class="card-text"><%# Eval("Pdesc") %></p>
                            <p class="card-text">Price: <%# Eval("Price") %></p>
                            <a href="/ProductDetails.aspx?Pid=<%# Eval("Pid") %>" class="btn btn-primary">View Product</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#recommendedProductsCarousel" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#recommendedProductsCarousel" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>
