<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="HobbyTracker.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StaffContent" runat="server">
        <h4 class="text-primary">Welcome <%=Session["StaffUsername"] %></h4>

    <div class="container mt-5">
        <div class="card p-4 shadow">
            <h3 class="text-primary">Dashboard</h3>
            <p>Welcome, <strong><%= Session["StaffUsername"] %></strong>. You have access to view below dashboard contents.</p>

            <div class="row mt-4">
                <div class="col-md-4">
                    <div class="border p-3 bg-light">
                        <h5>Total Users</h5>
                        <asp:Label ID="lblTotalUsers" runat="server" CssClass="h4 text-success"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="border p-3 bg-light">
                        <h5>Most Active User</h5>
                        <asp:Label ID="lblMostActiveUser" runat="server" CssClass="h4 text-info"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="border p-3 bg-light">
                        <h5>Total Hobby Items</h5>
                        <asp:Label ID="lblTotalHobbyItems" runat="server" CssClass="h4 text-warning"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

