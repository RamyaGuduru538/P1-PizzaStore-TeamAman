<%@ Page Title="PizzaStore-Register" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegisterUser.aspx.cs" Inherits="PizzaStore_WebApp.RegisterUser" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="Scripts/Css/pizzastyle.css" />

    <div class="maindiv"> 
        <div class="auto-style3"><span class="newStyle1" style="color: #CC33FF"><strong>&nbsp;&nbsp;&nbsp;<span style="background-color: #FFFFCC; padding: 7px; margin-bottom: 50px;">Register to Pizza-Store </span></strong></span></div> <br />
        <br /><br />

        <div class="form-group row">
            <asp:Label for="tbName" ID="lblName" runat="server" Text="Name" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbName" runat="server" class="form-control" placeholder="Please enter the name"></asp:TextBox>
                <span id="nameError"></span>
            </div>
        </div>

        <div class="form-group row">
            <asp:Label for="tbEmail" ID="lblEmail" runat="server" Text="Email" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbEmail" runat="server" class="form-control" placeholder="Please enter the email"></asp:TextBox>
                <span id="emailError"></span>
            </div>
        </div>
                
        <div class="form-group row">
            <asp:Label for="tbZipcode" ID="lblZipcode" runat="server" Text="Zipcode" class="col-sm-2 col-form-label"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="tbZipcode" runat="server" class="form-control" placeholder="Please enter the zipcode"></asp:TextBox>
                <span id="zipcodeError"></span>
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
                <asp:TextBox ID="tbCPassword" runat="server" class="form-control" placeholder="Confirm your Password" ></asp:TextBox>
                <span id="PswdError"></span>
            </div>
        </div><br />

        <div class="form-group row">
            <div class="col-sm-10 offset-sm-2">
            <asp:Button ID="btn_Add" class="btn btn-primary" runat="server" Text="Register" OnClick="btn_Add_Click" Height="44px" Width="124px"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_Login" class="btn btn-primary" runat="server" Text="Already a User" OnClick="btn_Login_Click" Height="44px" Width="182px"  />
            </div>      
        </div>
   </div>


</asp:Content>
