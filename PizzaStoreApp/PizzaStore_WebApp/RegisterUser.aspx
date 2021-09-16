<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="PizzaStore_WebApp.RegisterUser" %>

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
    <form id="RegisterForm" runat="server">

     <div class="maindiv"> <br />
            <div class="form-group row">
              <asp:Label for="tbName" ID="lblName" runat="server" Text="Name" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbName" runat="server" class="form-control" placeholder="Please enter the name"></asp:TextBox>
            </div>
            </div>
                
            <div class="form-group row">
              <asp:Label for="tbEmail" ID="lblEmail" runat="server" Text="Email" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Please enter the email"></asp:TextBox>
            </div>
            </div>

             <div class="form-group row">
              <asp:Label for="tbZipcode" ID="lblZipcode" runat="server" Text="Zipcode" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbZipcode" runat="server" class="form-control" placeholder="Please enter the zipcode"></asp:TextBox>
            </div>
            </div>
                
             <div class="form-group row">
              <asp:Label  ID="lblGender" runat="server" Text="Gender" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
                <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            </div>
             </div>
           
             <div class="form-group row">
              <asp:Label for="tbPassword" ID="lblPassword" runat="server" Text="Password" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbPassword" runat="server" class="form-control" placeholder="Please enter the password"></asp:TextBox>
            </div>
             </div>

          <div class="form-group row">
              <asp:Label for="tbCPassword" ID="lblCPassword" runat="server" Text="Confirm Password" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbCPassword" runat="server" class="form-control" placeholder="Please enter the password again" ></asp:TextBox>
                <span id="PswdError"></span>
                </div>
             </div>

         <div class="form-group row">
            <div class="col-sm-10 offset-sm-2">
                <asp:Button ID="btn_Add" class="btn btn-primary" runat="server" Text="Register" OnClick="btn_Add_Click"   />
            </div>
              
          </div>

    </div>
        </form>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#tbCPassword").blur(function () {
                var pswd = $("#tbPassword").val();
                console.log(pswd);
                var cpswd = $("#tbCPassword").val();
                if (pswd != cpswd) {
                    $("#PswdError").html("Both value must be same");
                    $("#PswdError").css({ "color": "Red" });
                }
            }); 
        });
    </script>
</body>
</html>
