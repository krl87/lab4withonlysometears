<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="comp2084_lab4.student_details" %>

<%@ Register Src="~/auth.ascx" TagPrefix="uc1" TagName="auth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:auth runat="server" id="auth" />
    <h1>Student Details</h1>
    <h5>All fields are required</h5>
    <div class="form-group">
        <label for="txtLast" class="cal-sm-2">Last Name: *</label>
        <asp:TextBox ID="txtLast" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtFirst" class="cal-sm-2">First Name: *</label>
        <asp:TextBox ID="txtFirst" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtEnroll" class="cal-sm-2">Enrollment Date: *</label>
        <asp:TextBox ID="txtEnroll" runat="server" required TextMode="Date" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a Date"
            ControlToValidate="txtEnroll" CssClass="alert alert-danger"
            Type="Date" MinimumValue="2000-01-01" MaximumValue="12/31/2999"></asp:RangeValidator>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
    <asp:panel runat="server" ID="pnlCourses">
    <h2>Courses</h2>
        <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="false" DataKeyNames="EnrollmentID" OnRowDeleting="grdCourses_RowDeleting" CssClass="table table-striped table-hover">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Department" />
                <asp:BoundField DataField="Title" HeaderText="Course" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
            </Columns>
        </asp:GridView>
        </asp:panel>
</asp:Content>
