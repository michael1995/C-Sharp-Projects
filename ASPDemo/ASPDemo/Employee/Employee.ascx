<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Employee.ascx.cs" Inherits="ASPDemo.Employee.Employee" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 132px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtFirstName" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLastName" runat="server" Width="150px"></asp:TextBox>
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
            <asp:Label ID="Label8" runat="server" Text="Department"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="cboDepartment" runat="server" Width="156px">
                <asp:ListItem>Please Select an item</asp:ListItem>
                <asp:ListItem>Sales</asp:ListItem>
                <asp:ListItem>Production</asp:ListItem>
                <asp:ListItem>Office</asp:ListItem>
                <asp:ListItem>Delivery</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label9" runat="server" Text="Salary"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSalary" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label10" runat="server" Text="User Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label11" runat="server" Text="Password"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Width="150px"></asp:TextBox>
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
    </tr>
</table>




