using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChatroom
{
    public partial class Chatroom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果沒有login，重新導向LogIn頁面
            if ( ((String)Session["Login"]).Equals("") )
            {
                Response.Redirect("http:/simplechatroom.somee.com/LogIn.aspx");
            }

            //如果是第一次載入，就用ListAll()顯示全部對話。不然則是ajax，只要更新一條對話就好
            if (!IsPostBack)
            {
                ListAll();
            }

            //預設focus在對話框上
            this.Page.SetFocus(TextBox1);
        }

        protected void ListAll()
        {
            StringBuilder chatroomText = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                chatroomText.AppendLine(Application["A" + i].ToString() + "<br />");
            }

            ChatArea.Text = chatroomText.ToString(); 
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            Application.Lock();
            StringBuilder chatroomText = new StringBuilder();
            if (Application["A12"].ToString().Equals("")) //13格Application未填滿
            {
                for (int i = 0; i < 13; i++)
                {
                    if (Application["A" + i].ToString().Equals(""))//找到空格並寫入
                    {
                        Application["A" + i] = Session["name"] + " : " + TextBox1.Text;
                        break;
                    }
                }

                //將Application讀出
                for (int i = 0; i < 13; i++)
                {
                    chatroomText.AppendLine(Application["A" + i].ToString() + "<br />");
                }
                ChatArea.Text = chatroomText.ToString();
            }
            else //13格Application已填滿
            {
                for (int i = 1; i < 13; i++)//目錄往上移一格
                {
                    Application["A" + (i - 1)] = Application["A" + i];
                    chatroomText.AppendLine(Application["A" + (i - 1)].ToString() + "<br />");
                }

                //寫入新發言並將Application讀出
                Application["A12"] = Session["name"] + " : " + TextBox1.Text;
                chatroomText.AppendLine(Application["A12"].ToString() + "<br />");
                ChatArea.Text = chatroomText.ToString();
            }
            Application.UnLock();

            //輸出使用者發言後，清除文字
            TextBox1.Text = "";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ListAll();
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["id"] = "";
            Session["name"] = "";

            Response.Redirect("http:/simplechatroom.somee.com/LogIn.aspx");

        }
    }
}