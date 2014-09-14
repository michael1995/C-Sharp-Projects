<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Branch.ascx.cs" Inherits="ASPDemo.Branch.Branch1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 117px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Branch Office"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBranchOffice" runat="server" Width="150px"></asp:TextBox>
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

