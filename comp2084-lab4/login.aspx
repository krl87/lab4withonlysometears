<%@ Page Title="Login" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="comp2084_lab4.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>

    <div>
        <asp:label id="lblError" runat="server" cssclass="label label-danger"></asp:label>
    </div>
    <div class="form-group">
        <label for="txtUsertname" class="col-sm-2">Username:</label>
        <asp:textbox ID="txtUsername" runat="server" required maxlength="50"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:textbox ID="txtPassword" runat="server" TextMode="Password" required maxlength="50"></asp:textbox>
    </div>
    <div class="col-sm-2">
        <asp:button id="btnLogin" runat="server" text="Login" cssclass="btn btn-primary" OnClick="btnLogin_Click" />
    </div>

</asp:Content>
