<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="ASPDemo.Product.Product1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 118px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtProductName" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Product Code"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtProductCode" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Qty In Stock"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtQauntity" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPrice" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label5" runat="server" Text="Comments"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtComment" runat="server" Width="150px" Height="68px"></asp:TextBox>
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

