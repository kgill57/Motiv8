using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        String username = txtUsername.Text;
        String password = txtPassword.Text;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;


        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.VarChar));
        select.Parameters["@UserName"].Value = txtUsername.Text;

        select.CommandText = "SELECT EmployedStatus FROM [User] WHERE Username = @UserName";


        bool status = Convert.ToBoolean(select.ExecuteScalar());
        if (status == false)
        {
            lblError.Text = "Username does not exist";
            return;
        }

        select.CommandText = "SELECT [PasswordHash] FROM [dbo].[Password] WHERE [UserID] = (SELECT [UserID] FROM [dbo].[User] WHERE [UserName] = @UserName)";

        String hash = (String)select.ExecuteScalar();

        bool admin;
        select.CommandText = "(SELECT [Admin] FROM [dbo].[User] WHERE [UserName] = @UserName)";
        admin = Convert.ToBoolean(select.ExecuteScalar());
        con.Close();

        bool verify = SimpleHash.VerifyHash(password, "MD5", hash);

        if (verify)
        {
            getUser(txtUsername.Text);

            if (admin)
            {
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                Response.Redirect("TeamMemberPage.aspx");
            }
        }
        else
        {
            lblError.Text = "Invalid username and/or password.";
        }

    }

    public void getUser(string username)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;

        select.Parameters.AddWithValue("@username", username);

        select.CommandText = "SELECT UserID  FROM [User] WHERE UserName = @username";
        Session["UserID"] = (int)select.ExecuteScalar();

        select.CommandText = "SELECT FName FROM [User] WHERE UserName = @username";
        Session["FName"] = (String)(select.ExecuteScalar());

        try
        {
            select.CommandText = "SELECT MI FROM [User] WHERE UserName = @username";
            Session["MI"] = (String)select.ExecuteScalar();
        }
        catch (Exception)
        {
            Session["MI"] = "";
        }


        select.CommandText = "SELECT LName FROM [User] WHERE UserName = @username";
        Session["LName"] = (String)(select.ExecuteScalar());

        select.CommandText = "SELECT UserName FROM [User] WHERE UserName = @username";
        Session["UserName"] = (String)(select.ExecuteScalar());

        select.CommandText = "SELECT Email FROM [User] WHERE UserName = @username";
        Session["Email"] = (String)(select.ExecuteScalar());

        select.CommandText = "SELECT Admin FROM [User] WHERE UserName = @username";
        Session["Admin"] = Convert.ToInt32(select.ExecuteScalar());

        select.CommandText = "SELECT EmployerID FROM [User] WHERE UserName = @username";
        Session["EmployerID"] = (int)(select.ExecuteScalar());

        select.CommandText = "SELECT AccountBalance FROM [User] WHERE UserName = @username";
        Session["AccountBalance"] = (Convert.ToDecimal(select.ExecuteScalar()));


    }

    protected void btnCreateAdmin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand select = new SqlCommand();
        select.Connection = con;

        select.CommandText = "SELECT UserName FROM [dbo].[User] WHERE UserName = 'admin'";
        String existingUserName;
        existingUserName = (String)select.ExecuteScalar();
        if (existingUserName == null)
        {
            select.CommandText = "INSERT INTO [dbo].[Employer] VALUES('Elk Logistics', 5000)";
            select.ExecuteNonQuery();

            select.CommandText = "INSERT INTO [dbo].[User] VALUES('Chris', 'J', 'Bennsky', 'Bennskych@gmail.com', 'admin', 'elk-logo.png', 1, NULL, 1, 100, 1, 'Bennsky', '2018-01-01')";
            select.ExecuteNonQuery();

            string password = "password";

            string passwordHashNew =
                       SimpleHash.ComputeHash(password, "MD5", null);

            select.CommandText = "INSERT INTO[dbo].[Password] Values (1, '" + passwordHashNew + "')";
            select.ExecuteNonQuery();
        }
        else
        {
            lblError.Text = "This username is already taken";
        }


        con.Close();

    }
}