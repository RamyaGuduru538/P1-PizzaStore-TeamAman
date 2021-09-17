<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PizzaOrder.aspx.cs" Inherits="PizzaStore_WebApp.PizzaOrder" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Fill the Details to place the order</h2>
    
    <div>
        <div class="form-group row">
                <div class="col-sm-10">
                <asp:Label for="dd_PizzaName" ID="lbl_PizzaName"  runat="server" Text="Select Pizza Name" class="col-sm-2 col-form-label"></asp:Label>
                    <asp:DropDownList ID="dd_PizzaName"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
        </div>
        <div class="form-group row">
                <div class="col-sm-10">
                <asp:Label for="Gender" ID="lbl_PizzaSize" runat="server" Text="Select Pizza Size" class="col-sm-2 col-form-label"></asp:Label>
                    <asp:DropDownList ID="dd_PizzaSize" class="form-control" runat="server" >
                    </asp:DropDownList>
                </div>
        </div>
        <div class="form-group row">
                <div class="col-sm-10">
                <asp:Label for="Gender" ID="lbl_Toppings" runat="server" Text="Select Pizza Toppings" class="col-sm-2 col-form-label"></asp:Label>
                   <asp:CheckBoxList ID="chkToppings" class="mr-1" runat="server">
                    </asp:CheckBoxList>
                </div>
        </div>
        <div class="form-group row">
            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
            <br />
            <br />
            <asp:GridView ID="gvPizzaRecord" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="217px">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </div>
 
    
</asp:Content>

