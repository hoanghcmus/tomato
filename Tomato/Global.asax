<%@ Application Language="C#" %>

<script RunAt="server">
   
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        Application["SoLuotTruyCap"] = 0;
        Application["visitors_online"] = 0;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        Session["IDNguoiDung"] = "";
        Session["TenDangNhap"] = "";
        Session["TenNguoiDung"] = "";
        Session["QuyenHan"] = "";
        Session["IDDangNhap"] = "";
        Session["HanhDongDangNhap"] = "";

        Session["CheckInDate"] = "";
        Session["CheckOutDate"] = "";
        Session["AdultAmount"] = "";
        Session["ChildAmount"] = "";


        Session["lang"] = "vn";

        // Code that runs when a new session is started
        Session.Timeout = 120;
        Application.Lock();
        Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 5;
        Application.UnLock();
        try
        {
            DataAccess.Classes.ThongKeTruyCap data = DataAccess.Classes.ThongKeTruyCap.Start();
            Application["SoLuotTruyCap"] = data.LuotTruyCap.ToString();
            data = null;
        }
        catch
        {
        }
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
        Application.UnLock();
    }
       
</script>
