<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="ViewCatalogue.aspx.cs" Inherits="HobbyTracker.ViewCatalogue" Async="true" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MemberContent">
    <!DOCTYPE html>
    <html>
    <head>
        <title>View Hobby Catalogue</title>
        <style>
            .search-bar {
                display: flex;
                align-items: center;
                gap: 10px;
                margin-top: 30px;
            }

                .search-bar input[type="text"],
                .search-bar button {
                    height: 38px;
                }

            .container {
                margin-bottom: 10px;
            }

            table input[type="text"] {
                width: 100%;
                box-sizing: border-box;
            }

            table {
                table-layout: auto;
                word-wrap: break-word;
            }

            .card {
                overflow-x: auto;
            }
        </style>
    </head>
    <body>
        <h4 class="text-primary mb-3">Welcome <%= Session["UserName"] %></h4>
        <div class="container">
            <div class="search-bar">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by name..." />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-sm" OnClick="btnSearch_Click" />
            </div>
        </div>
        
        <div class="container mt-4">
            <div class="card shadow p-3">
                <asp:GridView ID="gvHobbies" runat="server"
                    CssClass="table table-bordered table-striped table-hover"
                    AutoGenerateColumns="False"
                    AllowPaging="true"
                    PageSize="5"
                    OnPageIndexChanging="gvHobbies_PageIndexChanging"
                    OnRowEditing="gvHobbies_RowEditing"
                    OnRowCancelingEdit="gvHobbies_RowCancelingEdit"
                    OnRowUpdating="gvHobbies_RowUpdating"
                    OnRowDeleting="gvHobbies_RowDeleting"
                    DataKeyNames="Id"
                    Width="100%">

                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="Price" HeaderText="Price ($)" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="PersonalValue" HeaderText="Personal Value" />
                        <asp:BoundField DataField="YearsToEstimate" HeaderText="Years To Estimate" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="DepreciationRate" HeaderText="Depreciation Rate" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="DepreciatedPrice" HeaderText="Depreciated Price" ReadOnly="True" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="ConvertedPrice" HeaderText="Price(₹)" ReadOnly="True" DataFormatString="{0:N2}" />

                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>

                    <EmptyDataTemplate>
                        <div class="text-center text-danger py-3">
                            <i class="fas fa-exclamation-circle"></i>No hobby catalogue found.
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>

    </body>
    </html>
</asp:Content>

