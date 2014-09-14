<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ChocoMamboWebApplication.OrderLines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/CSS_Content.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
 <div id="Table">
        <asp:Table ID="tbl_orderDetails" runat="server"  >
            <asp:TableRow>
                <asp:TableCell >
                    <asp:Table ID="tbl_CustomerDetails" runat="server" CssClass="table" >
                        <asp:TableRow>
                            <asp:TableCell CssClass="tableFirstColumn"  >
                                <asp:Label ID="Label1" runat="server" Text="Supplier:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="dd_Supplier" runat="server" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="dd_Supplier_SelectedIndexChanged"></asp:DropDownList>
                            </asp:TableCell>
                              <asp:TableCell   >
                                <asp:Label ID="Label7" runat="server" Text="Branch:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="dd_branch" runat="server" Width="250px"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                              
                            <asp:TableCell CssClass="tableFirstColumn"  >
                                <asp:Label ID="Label3" runat="server" Text="Order Date:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Calendar ID="c_OrderDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="90px" NextPrevFormat="FullMonth" SelectedDate="05/04/2014 10:26:35" Width="250px">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
                    <asp:Table ID="tbl_Product" runat="server" CssClass="table">
                        <asp:TableRow>
                            <asp:TableCell CssClass="tableFirstColumn"  >
                                <asp:Label ID="Label4" runat="server" Text="Product:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="dd_Product" runat="server" Width="200px"  AutoPostBack="True" OnSelectedIndexChanged="dd_Product_SelectedIndexChanged"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="tableFirstColumn"  >
                                <asp:Label ID="Label5" runat="server" Text="Price:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txt_Price" runat="server" ReadOnly="true" Width="50px"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="tableFirstColumn"  >
                                <asp:Label ID="Label6" runat="server" Text="QTY:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txt_Qty" runat="server" Width="50px" ></asp:TextBox>
                                 <asp:Button ID="btn_addToOrder" runat="server" Text="Add to Order" OnClick="btn_addToOrder_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label8" runat="server" Text="Order Total: $"></asp:Label>
                            </asp:TableCell>
                             <asp:TableCell>
                                 <asp:TextBox ID="txt_OrderTotal" runat="server" ReadOnly="true" Width="70px"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <asp:Button ID="btn_Save" runat="server" Text="Save"  CssClass="button" OnClick="btn_Save_Click"  />
    <asp:Button ID="btn_Delete" runat="server" Text="Delete" CssClass="button" OnClick="btn_Delete_Click"  />
    <asp:GridView ID="gv_OrderLines" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1080px" >
       
        <Columns>
            <asp:ButtonField CommandName="deleteOrderLine" Text="Delete" />
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
</asp:Content>
