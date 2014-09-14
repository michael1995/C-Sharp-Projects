<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="RawIngredient.aspx.cs" Inherits="ChocoMamboWebApplication.RawIngredient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
      <div id="buttonMenu">
        <asp:Button ID="btn_Save" runat="server" Text="Save"  CssClass ="button" OnClick="btn_Save_Click"    />
        <asp:Button ID="btn_Delete" runat="server" Text="Delete"  CssClass ="button" OnClick="btn_Delete_Click"   />
    </div>
    <asp:Table ID="tbl_RawIngredient" runat="server">
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
                    <asp:Label ID="Label2" runat="server" Text="Label">Code: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Code" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Label">Price: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Price" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Label">Qty on Hand: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_QtyOnHand" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Label">Qty on Order: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_QtyOnOrder" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="Label6" runat="server" Text="Label">Supplier: </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txt_Supplier" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
