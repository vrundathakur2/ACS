using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public partial class DealerRegis : System.Web.UI.Page
{
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            addcountry();
        }


    }
    public void addcountry()
    {
        string str = "select * from country";
        SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
        DataSet ds = new DataSet();
        da.Fill(ds, "city");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcountryid.DataSource = ds.Tables[0].DefaultView;
            ddlcountryid.DataTextField = "countryname";
            ddlcountryid.DataValueField = "countryid";
            ddlcountryid.DataBind();
            ddlcountryid.Items.Insert(0, "Select");

        }
    }
    protected void btninsert_Click(object sender, EventArgs e)
    {
        string x;
        if (rdomale.Checked == true)
        {
            x = "Male";
        }
        else
        {
            x = "Female";
        }
        string str;
        str = "insert into Dealer values('" + txtDealerName.Text + "','" + x + "','" + txtaddr.Text + "'," + ddlcountryid.SelectedValue + "," + ddlstateid.SelectedValue + ",'" + txtCityName.Text + "'," + txtcontactno.Text + ",'" + txtemailid.Text + "','" + txtpassword.Text + "','Pending')";
        SqlCommand cmd = new SqlCommand(str, objmyclass.con);
        objmyclass.con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            lblMsg.Text = "Record is saved...";
        }
        objmyclass.con.Close();


    }
    protected void ddlcountryid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcountryid.SelectedValue != "Select")
        {
            string str;
            str = "select * from state where countryid=" + ddlcountryid.SelectedValue;
            SqlDataAdapter da = new SqlDataAdapter(str, objmyclass.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ClientDetail");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstateid.DataSource = ds.Tables[0].DefaultView;
                ddlstateid.DataTextField = "statename";
                ddlstateid.DataValueField = "stateid";
                ddlstateid.DataBind();
                ddlstateid.Items.Insert(0, "Select");
            }
        }
        else
        {
            lblMsg.Text = "Select valid country or state...";
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtaddr.Text = "";
        txtCityName.Text = "";
        txtcontactno.Text = "";
        txtDealerName.Text = "";
        txtemailid.Text = "";
        txtpassword.Text = "";
        txtRetailerId.Text = "";
    }
}