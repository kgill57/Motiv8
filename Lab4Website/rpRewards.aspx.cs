using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class rpRewards : System.Web.UI.Page
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

    protected void btnAddReward_Click(object sender, EventArgs e)
    {
        addReward.Visible = true;
    }


    protected int getProviderID()
    {
        // Instantiate SQL objects, set up a SQL connection
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT ProviderID FROM [User] WHERE UserID = " + (int)Session["UserID"];
        cmd.Connection = con;

        int providerID = (int)cmd.ExecuteScalar();

        return providerID;
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        // Instantiate SQL objects, set up a SQL connection
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "INSERT INTO Reward (RewardName, RewardQuantity, RewardAmount, ProviderID, DateAdded) VALUES (@rewardName, @rewardQuantity, @rewardAmount, @providerID, @dateAdded)";
        cmd.Parameters.AddWithValue("@rewardName", txtRewardName.Text);
        cmd.Parameters.AddWithValue("@rewardQuantity", txtRewardQuantity.Text);
        cmd.Parameters.AddWithValue("@rewardAmount", txtRewardAmount.Text);
        cmd.Parameters.AddWithValue("@providerID", getProviderID());
        cmd.Parameters.AddWithValue("@dateAdded", DateTime.Today.ToString("yyyy-MM-dd"));

        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();

        lblResult.Text = "Reward Added";
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