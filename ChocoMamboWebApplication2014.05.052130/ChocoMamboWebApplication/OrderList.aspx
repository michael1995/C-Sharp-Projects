<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="ChocoMamboWebApplication.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    < <
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
      <div id ="gridview">
         <div id="buttonMenu">
        <asp:Button ID="btn_newOrder" runat="server" Text="New Order"  CssClass ="button" OnClick="btn_newOrder_Click"  />
        <asp:Button ID="btn_Edit" runat="server" Text="Edit"  CssClass ="button" OnClick="btn_Edit_Click" />
       

    </div>
         <asp:GridView ID="gv_Order" runat="server" DataKeyNames="ID"  AllowSorting="True" CssClass="Grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1080px" >
           
              <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        
    </div>
</asp:Content>
