<%@ Page Title="PizzaStore-Login "Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginPage.aspx.cs" Inherits="PizzaStore_WebApp.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="Scripts/Css/pizzastyle.css" />   

    <div class="maindiv"> <br />
        <div class="auto-style3"><span class="newStyle1" style="color: #CC33FF"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="background-color: #FFFFCC; padding: 7px; margin-bottom: 50px;">&nbsp;Login to Pizza-Store </span></strong></span></div> <br />
        <br /><br />
        <div>
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

            <br />
            <div class="form-group row">
            <div class="col-sm-10 offset-sm-2">
                <asp:Button ID="btn_Login" class="btn btn-primary" runat="server" Text="Login" OnClick="btn_Login_Click" Height="42px" Width="102px"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_Signup" class="btn btn-primary" runat="server" Text="SignUp" OnClick="btn_Signup_Click" Height="42px" Width="103px"  />
            </div> 
            </div>
        </div>
    </div>
</asp:Content>
