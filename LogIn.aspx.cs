using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChatroom
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            
            if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals(""))
            {
                SqlConnection Conn;
                Conn = new SqlConnection();
                Conn.ConnectionString = Session["ConnStr"].ToString();

                SqlCommand cmd = new SqlCommand("select id,name from db_user where CONVERT(VARCHAR, account) = @account " +
                    "and CONVERT(VARCHAR, password) = @password", Conn);
                cmd.Parameters.AddWithValue("@account", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", TextBox2.Text);

                SqlDataReader reader = null;

                try
                {
                    Conn.Open();//connect
                    reader = cmd.ExecuteReader(); //take data

                    if (!reader.Read())//no such account
                    {
                        Response.Write("<script>alert('帳號或密碼有誤!');</script>");
                        TextBox2.Text = "";
                    }
                    else
                    {
                        Session["login"] = "OK";
                        Session["id"] = reader[0].ToString();
                        Session["name"] = reader[1].ToString();

                        Response.Redirect("http:/simplechatroom.somee.com/Chatroom.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
                }
                finally
                {
                    if (reader != null)
                    {
                        cmd.Cancel();  // Cancel command first
                        reader.Close(); //Then close reader
                    }

                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close(); //Close connection
                    }
                }
            }
            else //Acoount or password is null
            {
                Response.Write("<script>alert('請輸入帳號和密碼!');</script>");
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("http:/simplechatroom.somee.com/Register.aspx");
        }
    }
}