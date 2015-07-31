<%@ Page Title="Instructor Registration" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="instructors.aspx.cs" Inherits="comp2084_lab4.instructors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Instructor Registration</h1>
    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-2">First Name:</label>
        <asp:textbox ID="txtFirstName" runat="server" required maxlength="50"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtLastName" class="col-sm-2">Last Name:</label>
        <asp:textbox ID="txtLastName" runat="server" required maxlength="50"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtUsertname" class="col-sm-2">Username:</label>
        <asp:textbox ID="txtUsername" runat="server" required maxlength="50"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtPassword" class="col-sm-2">Password:</label>
        <asp:textbox ID="txtPassword" runat="server" TextMode="Password" required maxlength="50"></asp:textbox>
    </div>
    <div class="form-group">
        <label for="txtConfirm" class="col-sm-2">Confirm Password:</label>
        <asp:textbox ID="txtConfirm" runat="server" TextMode="Password" required maxlength="50"></asp:textbox>
       <asp:comparevalidator runat="server" ControlToValidate="txtPassword" ControlToCompare="txtConfirm" errormessage="Passwords Must Match" Operator="Equal" CssClass="label label-danger"></asp:comparevalidator>
    </div>
    <div>
        <label for="ddlDepartment" class="col-sm-2">Department:</label>
        <asp:dropdownlist ID="ddlDepartment" datatextfield="Name" datavaluefield="DepartmentID" runat="server"></asp:dropdownlist>
    </div>
    <div class="col-sm-2-offset">
    <asp:button id="btnRegister" runat="server" text="Register" cssclass="btn btn-primary" OnClick="btnRegister_Click" />
    </div>

</asp:Content>
