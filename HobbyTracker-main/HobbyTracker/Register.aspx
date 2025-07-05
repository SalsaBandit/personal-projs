<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HobbyTracker.Register" %>
<%@ Register Src="~/SubmitButton.ascx" TagPrefix="uc" TagName="SubmitButton" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
            <h2 class="text-primary text-left mb-4">User Enrollment</h2>

    <div class="container mt-5">

        <p class="text-danger text-center">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">
                <div class="card p-4 shadow-sm">
                    <section id="loginForm">
                        <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                            <p class="text-danger text-center">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-sm-4 col-form-label">User name</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="text-danger" ErrorMessage="The user name field is required." Display="Dynamic" />
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-sm-4 col-form-label">Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="text-danger" ErrorMessage="The password field is required." Display="Dynamic" />
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-sm-4 col-form-label">Confirm Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                    CssClass="text-danger" ErrorMessage="The confirmation password is required." Display="Dynamic" />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                    CssClass="text-danger" ErrorMessage="Passwords do not match." Display="Dynamic" />
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-8 offset-sm-4">
                                <uc:SubmitButton ID="btnSubmit" runat="server" Title="Register" OnSubmitClicked="SubmitButton_SubmitClicked" />
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
