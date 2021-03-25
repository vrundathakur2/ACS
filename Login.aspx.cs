using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session["Emailid"] = "";
        Session["uname"] = "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        if (objmyclass.con.State == ConnectionState.Closed)
        {

            objmyclass.con.Open();
        }
        Session["uname"] = "";
        if (txtuname.Text == "Admin" && txtpwd.Text == "Admin")
        {
            Session["Emailid"] = txtuname.Text;
            Response.Redirect("~/Admin/adminhome.aspx");
        }
        else if (txtuname.Text != "Admin" && txtpwd.Text != "Admin")
        {
            if (objmyclass.con.State == ConnectionState.Closed)
            {

                objmyclass.con.Open();
            }
            string s;
            s = "select * from Login where EmailId like '" + txtuname.Text + "' and Password like '" + txtpwd.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(s, objmyclass.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Loginmaster");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "A")
                {
                    Session["username"] = txtuname.Text;
                    Response.Redirect("~/Admin/AdminHome.aspx");
                }
                else if (ds.Tables[0].Rows[0]["UserRole"].ToString() == "E")
                {
                    Session["username"] = txtuname.Text;
                    if (objmyclass.con.State == ConnectionState.Closed)
                    {

                        objmyclass.con.Open();
                    }
                    string str;
                    str = "select * from employee where EmpEmail = '" + txtuname.Text + "' and EmpPass ='" + txtpwd.Text + "'";
                    SqlDataAdapter da101 = new SqlDataAdapter(str, objmyclass.con);
                    DataSet ds101 = new DataSet();
                    da101.Fill(ds101, "employee");

                    if (ds101.Tables[0].Rows.Count > 0)
                    {

                        Session["EmpName"] = ds101.Tables[0].Rows[0]["EmpName"].ToString();
                        Session["Emailid"] = txtuname.Text.ToString();
                        Session["EmpId"] = ds101.Tables[0].Rows[0]["EmpId"].ToString();
                        string designation = ds101.Tables[0].Rows[0]["EmpDesig"].ToString();
                        //if (designation == "1")
                        //{
                        //    Response.Redirect("~/Sales Manager/EmpHomePage.aspx");
                        //}
                        //else if (designation == "2")
                        //{
                        //    Response.Redirect("~/Accountent/EmpHomePage.aspx");
                        //}
                        //else if (designation == "3")
                        //{
                        //    Response.Redirect("~/Purchase Manager/EmpHomePage.aspx");
                        //}
                        //else if (designation == "4")
                        //{
                        //    Response.Redirect("~/Production Manager/EmpHomePage.aspx");
                        //}
                        //else
                        //{

                        //}
                    }
                    else
                    {
                        lblMsg.Text = "Username and password not match..";
                        lblMsg.CssClass = "error";
                    }
                }

              


                else
                {
                    Session["username"] = txtuname.Text;
                    Response.Redirect("Login.aspx");
                }


            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Username and Password are Incorrect";

            }
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Username and Password are Incorrect";
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtpwd.Text = "";
        txtuname.Text = "";
    }
}
