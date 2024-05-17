<%@ Page Title="Edit Product" Language="C#" MasterPageFile="~/AdminManeger/BackAdmin.Master" AutoEventWireup="true" CodeBehind="ProductAddEdit.aspx.cs" Inherits="Ecommerce.AdminManeger.prodAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Edit Product</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">ניהול מוצרים</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-header">
                        <i class="fas fa-edit"></i> הוספה / עריכת מוצר
                    </div>
                    <asp:HiddenField ID="HidPid" runat="server" Value="-1" />
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="TxtPname">שם המוצר</label>
                                    <asp:TextBox ID="TxtPname" CssClass="form-control" runat="server" placeholder="נא הזן שם מוצר" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtPrice">מחיר</label>
                                    <asp:TextBox ID="TxtPrice" CssClass="form-control" runat="server" placeholder="נא הזן מחיר מוצר" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtPdesc">תיאור המוצר</label>
                                    <asp:TextBox ID="TxtPdesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן תיאור" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtPicname">שם תמונה</label>
                                    <asp:TextBox ID="TxtPicname" CssClass="form-control" runat="server" placeholder="נא הזן שם לתמונה" />
                                </div>
                                <asp:Button ID="BtnSave" CssClass="btn btn-primary" runat="server" Text="שמירה" OnClick="BtnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <!-- jQuery Version 1.11.0 -->
    <script src="js/jquery-1.11.0.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="js/metisMenu/metisMenu.min.js"></script>
    <!-- Custom Theme JavaScript -->
    <script src="js/sb-admin-2.min.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
</asp:Content>
