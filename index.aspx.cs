using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChatroom
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //index.aspx只是為了放在somee.com上所創，只會重新導向Chatroom.aspx
            Response.Redirect("http:/simplechatroom.somee.com/Chatroom.aspx");
        }
    }
}