<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Purchase.ascx.cs" Inherits="ASPDemo.Purchase.Purchase1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table class="auto-style1">
    <tr>
        <td rowspan="4">
            <asp:GridView ID="gvPurchaseLines" runat="server" Width="391px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="10px" style="text-align: center" OnRowCommand="gvPurchaseLines_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:ButtonField CommandName="deletePurchaseLine" Text="Delete" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Supplier"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboSupplier" runat="server" Width="156px">
                <asp:ListItem>Please Select an item</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Branch"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboBranch" runat="server" Width="156px">
                <asp:ListItem>Please Select an item</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Date Purchase"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpDatePurchased" runat="server" Width="150px" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td rowspan="5">&nbsp;</td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Ingredients"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboRawIngredients" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="cboRawIngredients_SelectedIndexChanged">
                <asp:ListItem>Please Select an item</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPrice" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Quantity"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtQuantity" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Text="Line Total"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLineTotal" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td rowspan="6">&nbsp;</td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="Purchase Code"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPurchaseCode" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label10" runat="server" Text="Purchase Total"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTotalAmount" runat="server" Width="150px" BackColor="#CCCCCC" Enabled="False" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" style="height: 26px" OnClick="btnSubmit_Click" Width="90px" Height="25px" />
        </td>
        <td>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" Width="90px" Height="25px" OnClick="btnInsert_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnDeleteOrder" runat="server" Text="Delete " Width="90px" Height="25px" OnClick="btnDeleteOrder_Click" Enabled="False" />
        </td>
        <td>
            <asp:Button ID="btnCalculate" runat="server" Height="25px" OnClick="btnCalculate_Click" Text="Calculate" Width="90px" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

