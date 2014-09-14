<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.ascx.cs" Inherits="ASPDemo.UserLogin" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    #Reset1 {
        width: 193px;
    }
    .auto-style5 {
        width: 144px;
        background-color: #FFFFFF;
    }
    .auto-style6 {
        width: 144px;
        background-color: #FFFFFF;
        height: 23px;
        font-size: medium;
    }
    .auto-style7 {
        width: 310px;
        background-color: #FFFFFF;
        height: 23px;
        font-size: medium;
    }
    .auto-style8 {
        width: 310px;
        background-color: #FFFFFF;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style6">
            Login </td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:TextBox ID="txtUsername" runat="server" Width="279px" style="margin-left: 1px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Label ID="Label2" runat="server" Text="Password" style="text-align: right"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:TextBox ID="txtPassword" runat="server" Width="279px" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" BorderColor="White" Width="101px" BorderStyle="Groove" />
        </td>
    </tr>
    </table>

