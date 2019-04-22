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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool gender = false;
            String sex = null;
            if (RadioButton1.Checked)
            {
                sex = "male";
                gender = true;
            }
            else if (RadioButton2.Checked)
            {
                sex = "female";
                gender = true;
            }
            
            if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals("") &&
                !TextBox3.Text.Equals("") && !TextBox4.Text.Equals("") && gender)
            {
                SqlConnection Conn;
                Conn = new SqlConnection(Session["ConnStr"].ToString());

                SqlCommand cmd = new SqlCommand("select id from db_user where CONVERT(VARCHAR, account) = @account"
                    , Conn);
                cmd.Parameters.AddWithValue("@account", TextBox1.Text);

                SqlDataReader reader = null;

                try
                {
                    Conn.Open(); //Sql connection
                    reader = cmd.ExecuteReader(); //撈資料

                    //先檢查此account有沒有有沒有被註冊過了
                    if (!reader.Read())
                    {
                        cmd.Cancel();
                        reader.Close();

                        cmd = new SqlCommand("insert into db_user (account,password,name,email,sex) " +
                        "values (@account, @password, @name, @email, @sex)", Conn);
                        cmd.Parameters.AddWithValue("@account", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@password", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@name", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@email", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.ExecuteNonQuery();
                    
                        Response.Redirect("http:/simplechatroom.somee.com/Chatroom.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('此帳號已被註冊!');</script>");
                        TextBox2.Text = "";
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
                        cmd.Cancel(); // Cancel command first
                        reader.Close(); //Then close reader
                    }

                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close(); //Close connection
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('請輸入完整資料!');</script>");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http:/simplechatroom.somee.com/LogIn.aspx");
        }
    }
}