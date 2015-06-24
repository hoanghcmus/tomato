<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Đang nhập Quản Trị</title>
    <link rel="Shurtcut Icon" href="images/icon_login.png" type="image/x-icon" />
    <link href="stylesheets/login.css" rel="stylesheet" type="text/css" />
    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var txtUserName = $("#txtTenDangNhap");
            txtUserName.blur(function () {
                $('#lbtitle').show();
                //if there is on text
                if ($('#txtTenDangNhap').val().length == 0) {
                    $('#lbtitle').html("Vui lòng nhập tên đăng nhập và mật khẩu");
                }
                else {
                    $('#lbtitle').html("Kiểm tra...");
                    $.ajax({ type: "POST",
                        url: "Login.asmx/KiemTraTenDangNhap",
                        data: "{tenDangNhap:'" + $('#txtTenDangNhap').val() + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            var result = response.d;
                            if (result == true) {
                                $('#lbtitle').css("color", "black");
                                $('#lbtitle').html("Vui lòng nhập mật khẩu!");
                                $('#txtTenDangNhap').css("border", "1px solid #006cb2");
                            }
                            else {
                                $('#lbtitle').css("color", "#ff0000");
                                $('#lbtitle').html("Tên đăng nhập không tồn tại!");
                                $('#txtTenDangNhap').css("border", "1px solid red");
                            }
                        },
                        error: function (msg) {
                            $('#lbtitle').html("Không kiểm tra được");
                        }
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="middleEdit">
            <div class="clear">
            </div>
            <div class="frmheader">
            </div>
            <div class=" frmcontent">
                <div class="Tam">
                </div>
                <div class="Title">
                    <p>
                        <asp:Label ID="lbtitle" runat="server" Text="Vui lòng nhập tên đăng nhập và mật khẩu!"
                            CssClass="lbtitle" /></p>
                </div>
                <div class="content">
                    <table class="login">
                        <tr>
                            <td class="text">
                                Tên đăng nhập
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTenDangNhap" CssClass="txt" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text">
                                Mật khẩu
                            </td>
                            <td>
                                <asp:TextBox runat="server" TextMode="Password" ID="txtMatKhau" CssClass="txt" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="ckbGhiNho" runat="server" Text="Ghi nhớ tôi!" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- End div container-->
    </form>
</body>
</html>
