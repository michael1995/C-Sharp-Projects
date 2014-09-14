<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Permission.ascx.cs" Inherits="ASPDemo.AdminHub.Permission1" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table class="auto-style1">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Employee's"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboEmployee" runat="server" Width="273px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 80px">
            <asp:Label ID="Label2" runat="server" Text="Page"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboForm" runat="server" Width="273px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 80px">
            <asp:Label ID="Label3" runat="server" Text="Access Type"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboAccessTypes" runat="server" Height="23px" Width="273px">
                <asp:ListItem>Please select an item</asp:ListItem>
                <asp:ListItem>Read</asp:ListItem>
                <asp:ListItem>Write</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Deny</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="margin-left: 80px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="margin-left: 80px">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" style="height: 26px" OnClick="btnSubmit_Click" Width="90px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

