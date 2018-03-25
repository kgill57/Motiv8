using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class rpEvents : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        if (!IsPostBack)
        {
            loadProfilePicture();
        }

    }

    protected void loadProfilePicture()
    {
        RewardProvider rp = new RewardProvider();
        con.Open();

        try
        {
            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "SELECT ProviderPicture FROM [dbo].[RewardProvider] WHERE ProviderID =" + rp.getProviderID((int)Session["UserID"]);
            string currentPicture = (String)select.ExecuteScalar();

            profilePicture.ImageUrl = "~/Images/" + currentPicture;
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];
        }
        catch (Exception)
        {

        }

        con.Close();
    }
}