<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Public.aspx.cs" Inherits="HobbyTracker.Public" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card shadow p-4">
            <h2 class="text-center text-primary mb-4">Welcome to Hobby Tracker Catalogue</h2>

            <p>
                <strong>Application Overview</strong>
                <br />
                This web-based platform is designed to help individuals discover, organize, and categorize their hobbies and interests. Users can create personal accounts, record their hobby-related activities, and generate insightful summaries to understand their engagement patterns more effectively.           
            </p>

            <p>
                <strong>How to Create an Account</strong><br />
                New users can register by clicking the Register link on the login page. Complete the required information, including username, password, and email address, to establish a new account.           
            </p>

            <p>
                <strong>Guidance for Test Analysts (TAs)</strong><br />
                Test Analysts can evaluate the system by using provided test credentials or registering a new user. Please ensure the following scenarios are thoroughly validated:               
                <ul>
                    <li>Verifying successful and unsuccessful login attempts</li>
                    <li>Creating a new hobby record</li>
                    <li>Editing and removing existing hobby entries</li>
                    <li>Generating summary reports of activities</li>
                    <li>Testing session timeout and logout features</li>
                    <li>Click <a href="TestPage.aspx" target="_blank"><strong>here</strong></a> to test internal components</li>

                </ul>
            </p>

            <h4 class="text-secondary mt-2 mb-3">Application and Component Overview Table</h4>
            <p>
                The Application and Component Overview Table provides a clear summary of the major components used in the Hobby Tracker system.
                Each component is categorized based on 
                its type (e.g., ASPX page, DLL, Service), its specific function within the application, and how it integrates with other layers.
               
            </p>
            <p>
            Click <a href="SummaryTable.aspx" target="_blank"><strong>here</strong></a> to view the  summary table details
            </p>
            <p class="mt-2">
                For any questions or technical assistance, please contact the development team.
            </p>
        </div>
    </div>
</asp:Content>
