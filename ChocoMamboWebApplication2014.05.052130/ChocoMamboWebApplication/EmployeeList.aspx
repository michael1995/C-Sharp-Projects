<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="ChocoMamboWebApplication.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="Styles/CSS_Content.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
    <div id="buttonMenu">
        <asp:Button ID="btn_newEmployee" runat="server" Text="New Employee" OnClick="btn_newEmployee_Click" CssClass ="button" />
        <asp:Button ID="btn_Edit" runat="server" Text="Edit"  CssClass ="button" OnClick="btn_Edit_Click" />
       

    </div>
    <div id ="gridview">
         <asp:GridView ID="gv_Employee" runat="server" DataKeyNames="ID"  AllowSorting="True" CssClass="Grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
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
