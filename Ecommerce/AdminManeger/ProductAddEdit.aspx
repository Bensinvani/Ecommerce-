<%@ Page Title="Edit Product" Language="C#" MasterPageFile="~/AdminManeger/BackAdmin.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ProductAddEdit.aspx.cs" Inherits="Ecommerce.AdminManeger.prodAddEdit" %>
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
                                    <asp:RequiredFieldValidator ID="ReqPname" runat="server" ControlToValidate="TxtPname" ErrorMessage="נא הזן שם מוצר" CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtPrice">מחיר</label>
                                    <asp:TextBox ID="TxtPrice" CssClass="form-control" runat="server" placeholder="נא הזן מחיר מוצר" />
                                    <asp:RequiredFieldValidator ID="ReqPrice" runat="server" ControlToValidate="TxtPrice" ErrorMessage="נא הזן מחיר מוצר" CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <div class="form-group">
                                    <label for="TxtPdesc">תיאור המוצר</label>
                                    <asp:TextBox ID="TxtPdesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="10" Columns="40" placeholder="נא הזן תיאור" />
                                    <asp:RequiredFieldValidator ID="ReqPdesc" runat="server" ControlToValidate="TxtPdesc" ErrorMessage="נא הזן תיאור מוצר" CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <div class="form-group">
                                    <label for="DdlCategory">קטגוריה</label>
                                    <asp:DropDownList ID="DdlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqCategory" runat="server" ControlToValidate="DdlCategory" InitialValue="" ErrorMessage="נא בחר קטגוריה" CssClass="text-danger" Display="Dynamic" />
                                </div>
                                <div class="form-group">
                                    <label for="ImgPicname">שם תמונה</label>
                                    <asp:Image ID="ImgPicname" CssClass="form-control" Style="width: 100%; height: auto;" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="UploadPic">תמונת מוצר</label>
                                    <asp:FileUpload ID="UploadPic" runat="server" />
                                </div>
                                <asp:Button ID="BtnSave" CssClass="btn btn-primary" runat="server" Text="שמירה" OnClick="BtnSave_Click" />
                                <asp:Button ID="BtnDelete" CssClass="btn btn-danger" runat="server" Text="מחק מוצר" OnClick="BtnDelete_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <!-- Ensure jQuery is loaded first -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
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
    <script src="https://cdn.ckeditor.com/ckeditor5/41.4.2/classic/ckeditor.js"></script> <!-- קישור לספריית CKeditor-->
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            ClassicEditor
                .create(document.querySelector('#<%= TxtPdesc.ClientID %>'), {
                    toolbar: [
                        'undo', 'redo', 'bold', 'italic', 'underline', 'strikethrough',
                        'subscript', 'superscript', 'numberedList', 'bulletedList', 'link',
                        'blockQuote', 'insertTable', 'mediaEmbed', 'alignment', 'fontColor',
                        'fontBackgroundColor', 'highlight', 'fontSize', 'fontFamily',
                        'horizontalLine', 'pageBreak', 'removeFormat', 'specialCharacters',
                        'codeBlock', 'heading', 'indent', 'outdent', 'htmlEmbed'
                    ],
                    language: 'he', // Hebrew language support
                    fontFamily: {
                        options: [
                            'default',
                            'Arial, Helvetica, sans-serif',
                            'Courier New, Courier, monospace',
                            'Georgia, serif',
                            'Lucida Sans Unicode, Lucida Grande, sans-serif',
                            'Tahoma, Geneva, sans-serif',
                            'Times New Roman, Times, serif',
                            'Trebuchet MS, Helvetica, sans-serif',
                            'Verdana, Geneva, sans-serif'
                        ]
                    },
                    fontSize: {
                        options: [
                            'tiny',
                            'small',
                            'default',
                            'big',
                            'huge'
                        ]
                    },
                    highlight: {
                        options: [
                            { model: 'yellowMarker', class: 'marker-yellow', title: 'Yellow marker', color: 'var(--ck-highlight-marker-yellow)' },
                            { model: 'greenMarker', class: 'marker-green', title: 'Green marker', color: 'var(--ck-highlight-marker-green)' },
                            { model: 'pinkMarker', class: 'marker-pink', title: 'Pink marker', color: 'var(--ck-highlight-marker-pink)' },
                            { model: 'blueMarker', class: 'marker-blue', title: 'Blue marker', color: 'var(--ck-highlight-marker-blue)' },
                            { model: 'redPen', class: 'pen-red', title: 'Red pen', color: 'var(--ck-highlight-pen-red)' },
                            { model: 'greenPen', class: 'pen-green', title: 'Green pen', color: 'var(--ck-highlight-pen-green)' }
                        ]
                    },
                    mediaEmbed: {
                        previewsInData: true
                    },
                    table: {
                        contentToolbar: [
                            'tableColumn', 'tableRow', 'mergeTableCells', 'tableCellProperties', 'tableProperties'
                        ]
                    },
                    htmlEmbed: {
                        showPreviews: true
                    },
                    removePlugins: [
                        'Title'
                    ]
                })
                .catch(error => {
                    console.error(error);
                });
        });
    </script>
</asp:Content>
