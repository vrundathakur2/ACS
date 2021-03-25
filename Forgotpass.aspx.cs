using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

public partial class Forgotpass : System.Web.UI.Page
{
    string pwd;
    myclass objmyclass = new myclass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sendMail(string pass)
    {
        string from = "yourEmailid@gmail.com"; //Replace this with your own correct Gmail Address  
        // string to = "archishah19@gmail.com"; //Replace this with the Email Address to whom you want to send the mail  

        string to = txtEmailId.Text;
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Admin for User Password Varification", System.Text.Encoding.UTF8);
        //  mail.Subject = "This is a test mail by bhikhi";
        mail.Subject = "Your Password";
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //  mail.Body = "Please refer Verification Code";
        mail.Body = "Please refer this password when login..." + pass;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient Customer = new SmtpClient();
        //Add the Creddentials- use your own email id and password  
        Customer.Credentials = new System.Net.NetworkCredential("yourEmailid@gmail.com", "Your Gmail Password");
        Customer.Port = 587; // Gmail works on this port  
        Customer.Host = "smtp.gmail.com";
        Customer.EnableSsl = true; //Gmail works on Server Secured Layer  
        try
        {
            Customer.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try   
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = string.Empty;
        SqlCommand cmd = new SqlCommand("select * from Login", objmyclass.con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt != null)
        {
            pwd = dt.Rows[0]["Password"].ToString();
            sendMail(pwd);
        }
        else
        {
            Response.Write("<script>alert('Invalid Email Id ')</script>");
        }
    }
}