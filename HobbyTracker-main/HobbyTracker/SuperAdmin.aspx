<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="SuperAdmin.aspx.cs" Inherits="HobbyTracker.SuperAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StaffContent" runat="server">
    <h4 class="text-primary">Welcome <%=Session["StaffUsername"] %> </h4>
    <div class="container mt-5">
        <div class="card p-4 shadow">
            <h3 class="text-primary">High-Value Hobby Catalogues</h3>

            <div class="form-inline mb-3">
                <label for="txtMinValue" class="mr-2">Minimum Value</label>
                <asp:TextBox ID="txtMinValue" runat="server" CssClass="form-control mr-2" Width="150px" />
                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary btn-sm mr-2" OnClick="btnFilter_Click" />
                <asp:Button ID="btnExportXml" runat="server" Text="Export XML" CssClass="btn btn-secondary btn-sm mr-2" OnClick="btnExportXml_Click" />
                <asp:Button ID="btnExportCsv" runat="server" Text="Export CSV" CssClass="btn btn-secondary btn-sm" OnClick="btnExportCsv_Click" />
            </div>

            <asp:GridView ID="gvHighValueItems" runat="server" CssClass="table table-bordered table-hover"
                AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="Name" />
                    <asp:BoundField HeaderText="Category" DataField="Category" />
                    <asp:BoundField HeaderText="Price (₹)" DataField="Price" DataFormatString="{0:N2}" />
                    <asp:BoundField HeaderText="User" DataField="User" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="text-danger text-center">No high-value items found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
