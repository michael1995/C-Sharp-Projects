<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="ChocoMamboWebApplication.Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
      <div id="buttonMenu">
        <asp:Button ID="btn_Save" runat="server" Text="Save"  CssClass ="button" OnClick="btn_Save_Click"    />
        <asp:Button ID="btn_Delete" runat="server" Text="Delete"  CssClass ="button" OnClick="btn_Delete_Click"  />
    </div>
    <asp:Table ID="tbl_Supplier" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Label">Name: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Label">Phone#: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_PhoneNumber" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Label">Building#: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_HouseNumber" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Label">Street: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Street" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Label">Suburb: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Suburb" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Label">State: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_State" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="Label">Postcode: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Postcode" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="Label">Contact Person: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_ContactPerson" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
