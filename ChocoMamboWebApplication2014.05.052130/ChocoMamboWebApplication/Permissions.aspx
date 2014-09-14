<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.cs" Inherits="ChocoMamboWebApplication.Permissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_Master" runat="server">
    <asp:Button ID="btn_update" runat="server" Text="Update" CssClass="button" OnClick="btn_update_Click" />
    <asp:GridView ID="gv_permissions" runat="server" Width="1080px" AutoGenerateColumns="False" OnRowDataBound="gv_permissions_RowDataBound">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Employee Name">
                <ItemTemplate>
                    <asp:DropDownList ID="dd_employee" runat="server" AppendDataBoundItems="True" AutoPostBack="false"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField AccessibleHeaderText="Form Name">
                <ItemTemplate>
                    <asp:DropDownList ID="dd_form" runat="server" AppendDataBoundItems="True"  AutoPostBack="false"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField AccessibleHeaderText="Access Type">
                <ItemTemplate>
                    <asp:DropDownList ID="dd_AccessRight" runat="server" AppendDataBoundItems="True"  AutoPostBack="False"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
