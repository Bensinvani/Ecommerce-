<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Ecommerce.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom fonts for this template -->
    <link href="AdminManeger/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="AdminManeger/css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Custom styles for this page -->
    <link href="AdminManeger/vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .small-gray-text {
            font-size: 12px;
            color: gray;
        }

        thead.thead-light th, tfoot.thead-light th {
            padding: 10px;
            font-size: 12px;
            color: gray;
            background-color: #f8f9fc;
        }

        .description-column {
            max-width: 200px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <div class="container-fluid">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">ניהול מוצרים</h1>
            <a href="/AdminManeger/ProductAddEdit.aspx" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-plus fa-sm text-white-50"></i> הוסף מוצר חדש</a>
        </div>
        <!-- DataTables Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">מאגר מוצרים במערכת</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="MainTbl" width="100%" cellspacing="0">
                        <thead class="thead-light">
                            <tr>
                                <th class="small-gray-text">קוד מוצר</th>
                                <th class="small-gray-text">שם מוצר</th>
                                <th class="small-gray-text">מחיר</th>
                                <th class="small-gray-text description-column">תיאור מוצר</th>
                                <th class="small-gray-text">תמונה</th>
                                <th class="small-gray-text">קטגוריה</th>
                                <th class="small-gray-text">ניהול</th>
                            </tr>
                        </thead>
                        <tfoot class="thead-light">
                            <tr>
                                <th class="small-gray-text">קוד מוצר</th>
                                <th class="small-gray-text">שם מוצר</th>
                                <th class="small-gray-text">מחיר</th>
                                <th class="small-gray-text description-column">תיאור מוצר</th>
                                <th class="small-gray-text">תמונה</th>
                                <th class="small-gray-text">קטגוריה</th>
                                <th class="small-gray-text">ניהול</th>
                            </tr>
                        </tfoot>
                        <tbody>
                            <asp:Repeater ID="RptProd" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Pid") %></td>
                                        <td><%# Eval("Pname") %></td>
                                        <td><%# Eval("Price") %></td>
                                        <td class="description-column"><%# Eval("Pdesc") %></td>
                                        <td><img src="/images/products/<%# Eval("Picname") %>" width="50" /></td>
                                        <td><%# Eval("CategoryName") %></td>
                                        <td><a href="/AdminManeger/ProductAddEdit.aspx?Pid=<%# Eval("Pid") %>">ערוך <span class="fa fa-pencil"></span></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterCnt" runat="server">
    <!-- Bootstrap core JavaScript-->
    <script src="AdminManeger/vendor/jquery/jquery.min.js"></script>
    <script src="AdminManeger/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="AdminManeger/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="AdminManeger/js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="AdminManeger/vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="AdminManeger/vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="AdminManeger/js/demo/datatables-demo.js"></script>
    <script>
        $(document).ready(function () {
            $('#MainTbl').DataTable({
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.0.7/i18n/he.json',
                },
            });
        });
    </script>
</asp:Content>
