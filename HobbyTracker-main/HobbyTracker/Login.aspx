<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HobbyTracker.Login" %>

<%@ Register Src="~/SubmitButton.ascx" TagPrefix="uc" TagName="SubmitButton" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2 class="text-primary text-left mb-4">Login To Your Account</h2>

    <div class="container mt-5">

        <asp:Label ID="lblMessage" runat="server" CssClass="text-center text-danger d-block mb-3" />

        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">
                <div class="card p-4 shadow-sm">
                    <section id="loginForm">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger text-center">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>

                        <!-- Username -->
                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-sm-4 col-form-label">User Name</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="text-danger" ErrorMessage="The user name field is required." Display="Dynamic" />
                            </div>
                        </div>

                        <!-- Password -->
                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-sm-4 col-form-label">Password</asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="text-danger" ErrorMessage="The password field is required." Display="Dynamic" />
                            </div>
                        </div>

                        <!-- User Type -->
                        <div class="form-group row">
                            <asp:Label runat="server" AssociatedControlID="UserType" CssClass="col-sm-4 col-form-label">User Type</asp:Label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="UserType" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select User Type" Value="" />
                                    <asp:ListItem Text="Staff" Value="Admin" />
                                    <asp:ListItem Text="Member" Value="Member" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserType" InitialValue=""
                                    CssClass="text-danger" ErrorMessage="Please select a user type." Display="Dynamic" />
                            </div>
                        </div>

                        <!-- Remember Me -->
                        <div class="form-group row">
                            <div class="col-sm-8 offset-sm-4">
                                <div class="form-check">
                                    <asp:CheckBox runat="server" ID="RememberMe" CssClass="form-check-input" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="form-check-label">Remember me?</asp:Label>
                                </div>
                            </div>
                        </div>

                        <!-- Submit Button -->
                        <div class="form-group row">
                            <div class="col-sm-8 offset-sm-4">
                                <uc:SubmitButton ID="btnSubmit" runat="server" Title="Login" OnSubmitClicked="SubmitButton_SubmitClicked" />
                            </div>
                        </div>

                        <div class="text-center mt-3">
                            <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl="~/Register">Register</asp:HyperLink>
                            if you don't have a local account.
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

