<%@ Page Title="" Language="C#" MasterPageFile="~/Member.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="HobbyTracker.Member1" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MemberContent">

    <h4 class="text-primary mb-4 text-left">Welcome <%= Session["UserName"] %></h4>

    <div class="container my-2"> <!-- my-5 = top & bottom margin -->
        <div class="row justify-content-center">
            <div class="col-lg-9">
                <div class="card p-4 shadow rounded-3" style="height:380px;">
                    
                    <asp:Label class="text-danger mb-3 d-block text-center" ID="lblmsg" runat="server" />

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtName">Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtcat">Category</label>
                            <asp:TextBox ID="txtcat" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtcat"
                                ErrorMessage="Category is required." CssClass="text-danger" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtPrice">Price ($)</label>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                ErrorMessage="Price is required." CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtValue">Personal Value (1–10)</label>
                            <asp:TextBox ID="txtValue" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
                                ErrorMessage="Value is required." CssClass="text-danger" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtYears">Years to Estimate</label>
                            <asp:TextBox ID="txtYears" runat="server" CssClass="form-control" Text="1" />
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtDepRate">Depreciation Rate (e.g., 0.10)</label>
                            <asp:TextBox ID="txtDepRate" runat="server" CssClass="form-control" Text="0.15" />
                        </div>
                    </div>

                    <div class="text-right mt-4">
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary px-4" Text="Add" OnClick="btnAdd_Click" />
                    </div>

                    <asp:Label ID="lblEstimatedValue" runat="server" CssClass="text-success font-weight-bold mt-4 d-block text-center" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

