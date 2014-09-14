<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="ChocoMamboWebApplication.SupplierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" type="text/css" href="Styles/CSS_Content.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
     <div id ="gridview">
         <div id="buttonMenu">
        <asp:Button ID="btn_newSupplier" runat="server" Text="New Supplier"  CssClass ="button" OnClick="btn_newSupplier_Click"  />
        <asp:Button ID="btn_Edit" runat="server" Text="Edit"  CssClass ="button" OnClick="btn_Edit_Click1"  />
       

    </div>
         <asp:GridView ID="gv_Supplier" runat="server" DataKeyNames="ID"  AllowSorting="True" CssClass="Grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
           
              <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#e3e3e3" Font-Bold="false" ForeColor="Black" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        
    </div>
</asp:Content>
