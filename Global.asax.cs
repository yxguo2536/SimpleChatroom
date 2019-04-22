using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SimpleChatroom
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            for (int i = 0; i < 13; i++)
            {
                Application["A" + i] = "";
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["id"] = "";
            Session["name"] = "";
            Session["ConnStr"] = "workstation id=SimpleChatroom.mssql.somee.com;packet size=4096;user id=Yxguo_SQLLogin_1;pwd=c6gm4iwq7d;data source=SimpleChatroom.mssql.somee.com;persist security info=False;initial catalog=SimpleChatroom";
        }
    }
}