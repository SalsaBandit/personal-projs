<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="HobbyTracker.TestPage"   Async="true"%>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Utility Test Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .card {
            margin-bottom: 20px;
        }

        .section-title {
            font-size: 1.25rem;
            font-weight: bold;
            color: #2c699e;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-primary text-center">Utility Test Page</h2>
            <div class="mb-3">
                <strong>WebStrar Development main page link:</strong>
                <a href="Default.aspx" class="ml-2">Go to Main Page</a>
            </div>

            <!-- Currency Conversion -->
            <div class="card p-4 shadow">
                <div class="section-title">Currency Conversion</div>
                <div class="form-row">
                    <div class="col">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Amount" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" placeholder="From (e.g., USD)" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" placeholder="To (e.g., INR)" />
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnConvert" runat="server" Text="Convert" CssClass="btn btn-primary" OnClick="btnConvert_Click" />
                    </div>
                </div>
                <asp:Label ID="lblResult" runat="server" CssClass="mt-2 text-success font-weight-bold" />
            </div>

            <!-- Password Encryption / Decryption -->
            <div class="card p-4 shadow">
                <div class="section-title">Password Encryption / Decryption</div>
                <div class="form-row">
                    <div class="col">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" />
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" CssClass="btn btn-warning" OnClick="btnEncrypt_Click" />
                        <asp:Button ID="btnDecrypt" runat="server" Text="Decrypt" CssClass="btn btn-info ml-2" OnClick="btnDecrypt_Click" />
                    </div>
                </div>
                <asp:Label ID="lblEncrypted" runat="server" CssClass="mt-2 text-dark d-block" />
            </div>

            <!-- Depreciated Price Calculation -->
            <div class="card p-4 shadow">
                <div class="section-title">Depreciated Price Calculator</div>
                <div class="form-row">
                    <div class="col">
                        <asp:TextBox ID="txtOriginalPrice" runat="server" CssClass="form-control" placeholder="Original Price" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtYears" runat="server" CssClass="form-control" placeholder="Years" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" placeholder="Depreciation Rate (e.g., 0.1)" />
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnDepreciate" runat="server" Text="Calculate" CssClass="btn btn-success" OnClick="btnDepreciate_Click" />
                    </div>
                </div>
                <asp:Label ID="lblDepreciated" runat="server" CssClass="mt-2 text-primary font-weight-bold" />
            </div>
        </div>
    </form>
</body>
</html>
