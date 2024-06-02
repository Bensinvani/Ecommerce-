<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/AdminManeger/BackAdmin.Master" AutoEventWireup="true" CodeBehind="CategoryAddEdit.aspx.cs" Inherits="Ecommerce.AdminManeger.CategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Category</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">ניהול קטגוריות</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-header">
                        <i class="fas fa-edit"></i> הוספה / עריכת קטגוריה
                    </div>
                    <asp:HiddenField ID="HidCid" runat="server" Value="-1" />
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="TxtCname">שם הקטגוריה</label>
                                    <asp:TextBox ID="TxtCname" CssClass="form-control" runat="server" placeholder="נא הזן שם קטגוריה" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtCdesc">תיאור הקטגוריה</label>
                                    <asp:TextBox ID="TxtCdesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5" placeholder="נא הזן תיאור" />
                                </div>
                                <div class="form-group">
                                    <label for="UploadPic">תמונת קטגוריה</label>
                                    <asp:FileUpload ID="UploadPic" runat="server" />
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
    <!-- Footer content if needed -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="UnderFooterCnt" runat="server">
    <!-- Custom JS if needed -->
</asp:Content>
