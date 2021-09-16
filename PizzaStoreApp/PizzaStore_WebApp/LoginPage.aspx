<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PizzaStore_WebApp.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PizzaStore-Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <style>
        .maindiv{
            margin-left:auto;
            margin-right:auto;
            margin-top:10px;
            width:400px;
        }
        .header{
            width:400px;
            color:blueviolet;
            margin-left:auto;
            margin-right:auto;
            font-size:22px;
            text-transform:capitalize;
            margin-top:20px;
        }
    </style>
</head>
<body>
    <form id="LoginForm" runat="server">
        <div class="header">Login to Pizza-Store</div> <br />
        <div class="maindiv"> <br />
            <div class="form-group row">
              <asp:Label for="tbEmail" ID="lblUsername" runat="server" Text="Email" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Please enter the email"></asp:TextBox>
            </div>
            </div>
                
            <div class="form-group row">
              <asp:Label for="tbPassword" ID="lblPassword" runat="server" Text="Password" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbPassword" runat="server" class="form-control" placeholder="Please enter the Password"></asp:TextBox>
            </div>
            </div>

            <div class="form-group row">
            <div class="col-sm-10 offset-sm-2">
                <asp:Button ID="btn_Login" class="btn btn-primary" runat="server" Text="Login" OnClick="btn_Login_Click"  />
                <asp:Button ID="btn_Signup" class="btn btn-primary" runat="server" Text="SignUp" OnClick="btn_Signup_Click"  />
            </div> 
          </div>

        </div>
    </form>
</body>
</html>
