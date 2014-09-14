<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RawIngredient.ascx.cs" Inherits="ASPDemo.RawIngredient.RawIngredient1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 170px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Ingredient Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtIngredientName" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Ingredient Code"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtIngredientCode" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Price "></asp:Label>
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
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" style="height: 26px" OnClick="btnSubmit_Click" Width="90px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

