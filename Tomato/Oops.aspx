<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Oops.aspx.cs" Inherits="Oops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.:: Website Nhà Hàng Như Bảo đang bảo trì ::.</title>
    <link rel="Shurtcut Icon" href="Design/logo.png" type="image/x-icon" />
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            text-align: center; /*background: #dbdbdb;*/
            background: #fff;
        }

        .container
        {
            margin: 0 auto;
            text-align: center;
            width: 950px;
            font-size: 1.2em;
        }

        .middle
        {
            display: block;
            width: 950px;
            margin-top: 10px;
            background: #ffffff;
            -khtml-border-radius: 10px; /* Konqueror */
            -moz-border-radius: 10px; /* Firefox */
            -webkit-border-radius: 10px; /* Safari & Google Chrome */
            -border-radius: 10px; /* Opera */
        }
    </style>
</head>
<body style="background-color: White;">
    <div class="container">
        <div class="middle">
            <p>
                Ban quản trị website Khách sạn 1001 thông báo!<br />
                Hiện website đang được bảo trì mời bạn vui lòng quay lại sau
            </p>
            <img src="Design/baotrihethong.jpg" />
            <%--<p>
                Trở về <b><a href="./">Trang chủ</a></b></p>--%>
        </div>
    </div>
</body>
</html>
