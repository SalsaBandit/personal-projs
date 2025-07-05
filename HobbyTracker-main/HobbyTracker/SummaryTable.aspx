<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryTable.aspx.cs" Inherits="HobbyTracker.SummaryTable" %>

<!DOCTYPE html>

<head runat="server">
    <title>Application and Components Summary Table</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            margin-top: 40px;
        }

        .table th,
        .table td {
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card shadow">
                <div class="card-body">
                    <h4 class="text-primary">Application and Components Summary Table</h4>
                    <hr />
                    <div class="mb-3">
                        <strong>WebStrar Development main page link:</strong>
                        <a href="Default.aspx" class="ml-2">Go to Main Page</a>
                    </div>

                    <table class="table table-bordered table-striped table-hover">
                        <thead class="thead-dark">
                            <tr>
                                <th>Provider Name</th>
                                <th>Page/Component Type</th>
                                <th>Component Description</th>
                                <th>Implementation Details</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Batchu</td>
                                <td>aspx page and server controls</td>
                                <td>The public Default page that calls and links all other pages</td>
                                <td>GUI design and C# code behind GUI</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>User control</td>
                                <td>Submit Button </td>
                                <td>C# code behind GUI. Linked to the login, user enroll, staff pages</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Global.asax</td>
                                <td>Application start event handler</td>
                                <td>C# code as script in Global.asax file</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>DLL</td>
                                <td>Hashing function:<br />
                                    Input: String<br />
                                    Output: String</td>
                                <td>Use library class and local component. Used in saving data into XML file.</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Cookies</td>
                                <td>Stores user ID and password securely (for Remember Me)</td>
                                <td>Used in login GUI with cookie read/write logic</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Session</td>
                                <td>Stores user name Which can be used across all the pages</td>
                                <td>Used in member, staff pages</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Business Componen</td>
                                <td>Handles business logic and workflow coordination</td>
                                <td>Called by UI to perform logic before saving/fetching data</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Business Entity Component</td>
                                <td>Contains POCO classes (e.g., `User`, `HobbyItemModel`)</td>
                                <td>Shared across all layers for data modeling</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>DataAccess Component</td>
                                <td>Reads and writes to XML files (users.xml, HobbyItems.xml)</td>
                                <td>Used by BusinessComponent to interact with XML storage</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Security Component</td>
                                <td>Encrypts/decrypts and hashes passwords, handles cookies</td>
                                <td>Used in login and cookie "Remember Me" feature</td>
                            </tr>
                            <tr>
                                <td>Batchu</td>
                                <td>Service Component</td>
                                <td>Performs price depreciation or currency conversion</td>
                                <td>Called by UI or Business Layer via HTTP or internal helper</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

