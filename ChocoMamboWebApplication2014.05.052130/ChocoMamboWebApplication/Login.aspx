<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChocoMamboWebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choco Mambo</title>
     <link rel="stylesheet" type="text/css" href="../Styles/CSS_Master.css" />
    <link rel="stylesheet" type="text/css" href="Styles/CSS_Login.css" />
     <script type="text/javascript" src="Scripts/jquery-1.10.2.js"> </script>
    <script type="text/javascript">
        $(function () {
            headerHeight = $('#banner').height();
            footerHeight = $('#footer').height();
            windowHeight = $(window).height();
            $('#contentArea').css('min-height', windowHeight - headerHeight - footerHeight * 2);
        });
   </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="banner">
            <div id="headerImage">
            </div>
        </div>
    <div id="wrapper">
         <div id="contentArea">
             <div id="Login">
                 <asp:Table ID="tbl_login" runat="server">
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
                         </asp:TableCell>
                          <asp:TableCell>
                              <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
                          </asp:TableCell>
                     </asp:TableRow>
                 </asp:Table>
             </div>
        </div>
    </div>
         <div id="footer">

        </div>
    </form>
</body>
</html>
