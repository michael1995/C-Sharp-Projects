<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Customer.ascx.cs" Inherits="ASPDemo.Customer.Customer" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 122px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Employee"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboEmployee" runat="server" Width="156px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Customer Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCustomerName" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label5" runat="server" Text="Postcode"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPostCode" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label6" runat="server" Text="Suburb"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSuburb" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label7" runat="server" Text="State"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtState" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" style="height: 26px" OnClick="btnSubmit_Click" Width="90px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

