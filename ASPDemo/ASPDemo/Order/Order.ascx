<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Order.ascx.cs" Inherits="ASPDemo.Order.Order1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
        height: 405px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td rowspan="5">
            <asp:GridView ID="gvOrderLines" runat="server" Width="391px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  Height="10px" style="text-align: center" OnRowCommand="gvOrderLines_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:ButtonField CommandName="deleteOrderLine" Text="Delete" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Customer"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboCustomer" runat="server" Width="156px">
                <asp:ListItem>Please Select an item</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Order Date"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpOrderDate" runat="server" Width="150px" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Shipping Date"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpShipDate" runat="server" Width="150px" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Label ID="Label4" runat="server" Text="Shipping Address"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtShipAddress" runat="server" Width="243px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px"></td>
        <td style="margin-left: 160px"></td>
    </tr>
    <tr>
        <td rowspan="5">
            &nbsp;</td>
        <td style="margin-left: 320px">
            <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:DropDownList ID="cboProduct" runat="server" Width="156px" OnSelectedIndexChanged="cboProduct_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Label ID="Label6" runat="server" Text="Price"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtPrice" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Label ID="Label7" runat="server" Text="Quantity"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtQuantity" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Label ID="Label8" runat="server" Text="Line Total"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtLineTotal" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">&nbsp;</td>
        <td style="margin-left: 160px">&nbsp;</td>
    </tr>
    <tr>
        <td rowspan="6">
            &nbsp;</td>
        <td style="margin-left: 320px">
            <asp:Label ID="Label9" runat="server" Text="Order Name"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtOrderName" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Label ID="Label10" runat="server" Text="Order Total"></asp:Label>
        </td>
        <td style="margin-left: 160px">
            <asp:TextBox ID="txtTotalAmount" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">&nbsp;</td>
        <td style="margin-left: 160px">&nbsp;</td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" style="height: 26px" OnClick="btnSubmit_Click" Width="90px" Height="25px" />
        </td>
        <td style="margin-left: 160px">
            <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="90px" Height="25px" OnClick="btnInsert_Click" />
        </td>
    </tr>
    <tr>
        <td style="margin-left: 320px">
            <asp:Button ID="btnDeleteOrder" runat="server" Text="Delete Order" Width="90px" Height="25px" OnClick="btnDeleteOrder_Click" Enabled="False" />
        </td>
        <td style="margin-left: 160px">
            <asp:Button ID="btnCalculate" runat="server" Height="25px" OnClick="btnCalculate_Click" Text="Calculate" Width="90px" />
        </td>
    </tr>
    <tr>
        <td style="margin-left: 160px">
            &nbsp;</td>
    </tr>
</table>

