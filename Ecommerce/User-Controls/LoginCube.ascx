﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginCube.ascx.cs" Inherits="Ecommerce.User_Controls.WebUserControl1" %>
<style>
    .divider:after,
    .divider:before {
        content: "";
        flex: 1;
        height: 1px;
        background: #eee;
    }
    .h-custom {
        height: calc(100% - 73px);
    }
    @media (max-width: 450px) {
        .h-custom {
            height: 100%;
        }
    }
</style>
<div id="LoginContainer" runat="server">
   <!-- Page Heading -->
   <div class="d-sm-flex align-items-center justify-content-between mb-4">
       <h1 class="h3 mb-0 text-gray-800">כניסה</h1>
   </div>
   <section class="vh-100">
      <div class="container-fluid h-custom">
         <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-md-9 col-lg-6 col-xl-5">
               <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
                 class="img-fluid" alt="Sample image">
            </div>
            <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
               <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                  <p class="lead fw-normal mb-0 me-3">Sign in with</p>
                  <button type="button" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary btn-floating mx-1">
                    <i class="fab fa-facebook-f"></i>
                  </button>
                  <button type="button" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary btn-floating mx-1">
                    <i class="fab fa-twitter"></i>
                  </button>
                  <button type="button" data-mdb-button-init data-mdb-ripple-init class="btn btn-primary btn-floating mx-1">
                    <i class="fab fa-linkedin-in"></i>
                  </button>
               </div>
               <div class="divider d-flex align-items-center my-4">
                  <p class="text-center fw-bold mx-3 mb-0">Or</p>
               </div>
               <!-- Email input -->
               <div data-mdb-input-init class="form-outline mb-4">
                  <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control form-control-lg" 
                     Placeholder="Enter a valid email address" TextMode="Email" />
                  <label class="form-label" for="TxtEmail">Email address</label>
               </div>
               <!-- Message display -->
               <asp:Literal ID="LtlMsg" runat="server" EnableViewState="False" />
               <!-- Password input -->
               <div data-mdb-input-init class="form-outline mb-3">
                  <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control form-control-lg" 
                     Placeholder="Enter password" TextMode="Password" />
                  <label class="form-label" for="TxtPass">Password</label>
               </div>
               <div class="d-flex justify-content-between align-items-center">
                  <!-- Checkbox -->
                  <div class="form-check mb-0">
                     <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
                     <label class="form-check-label" for="form2Example3">
                     Remember me
                     </label>
                  </div>
                  <a href="#!" class="text-body">Forgot password?</a>
               </div>
               <div class="text-center text-lg-start mt-4 pt-2">
                  <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-lg" 
                     OnClick="btnLogin_Click" OnClientClick="data-mdb-button-init; data-mdb-ripple-init;" 
                     Style="padding-left: 2.5rem; padding-right: 2.5rem;" />
                  <p class="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="/Register.aspx"
                     class="link-danger">Register</a></p>
               </div>
            </div>
         </div>
      </div>
      <div
         class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">
         <!-- Copyright -->
         <div class="text-white mb-3 mb-md-0">
            Copyright © 2020. All rights reserved.
         </div>
         <!-- Copyright -->
         <!-- Right -->
         <div>
            <a href="#!" class="text-white me-4">
            <i class="fab fa-facebook-f"></i>
            </a>
            <a href="#!" class="text-white me-4">
            <i class="fab fa-twitter"></i>
            </a>
            <a href="#!" class="text-white me-4">
            <i class="fab fa-google"></i>
            </a>
            <a href="#!" class="text-white">
            <i class="fab fa-linkedin-in"></i>
            </a>
         </div>
         <!-- Right -->
      </div>
   </section>
</div>

<!-- Message display -->
<asp:Literal ID="LtlLoggedUser" runat="server" EnableViewState="False" />