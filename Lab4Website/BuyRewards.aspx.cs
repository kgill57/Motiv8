using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class BuyRewards : System.Web.UI.Page
{
    public static Panel[] panelPost;
    public static CheckBox[] chkBuy;
    public static Reward[] reward;
    public static int arraySize;
    protected void Page_Load(object sender, EventArgs e)
    {
        createRewardFeed();
        loadProfilePicture();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        // Show user's name and balance in sidebar
        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");
        }

        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }
    }


    protected void loadProfilePicture()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        try
        {

            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "SELECT ProfilePicture FROM [dbo].[User] WHERE UserID =" + Convert.ToString((int)Session["UserID"]);
            string currentPicture = (String)select.ExecuteScalar();

            profilePicture.ImageUrl = "~/Images/" + currentPicture;
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");

        }
        catch (Exception)
        {

        }
        con.Close();
    }

    public Boolean checkFunds()
    {
        Boolean valid = true;

        SqlConnection con = new SqlConnection();


        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "SELECT AccountBalance FROM [User] WHERE UserID = @userID";
        cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
        double balance = Convert.ToDouble(cmd.ExecuteScalar());
        double transactionTotal = 0;
        for (int i = 0; i < reward.Length; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                transactionTotal += reward[i].getRewardAmount();
            }

        }
        if (balance < transactionTotal)
        {
            lblResult.Text = "Insufficient Funds.";
            valid = false;
        }
        con.Close();

        return valid;
    }


    protected void btnBuy_Click(object sender, EventArgs e)
    {

        if (checkFunds() == false)
            return;

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();


        bool itemSelected = false;

        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                itemSelected = true;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO RewardEarned (UserID, RewardID, DateClaimed) VALUES (@userID, @rewardID, @dateClaimed)";
                cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
                cmd.Parameters.AddWithValue("@rewardID", reward[i].getRewardID());
                cmd.Parameters.AddWithValue("@dateClaimed", DateTime.Today.Date);
                cmd.ExecuteNonQuery();
            }
        }



        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE [Reward] SET RewardQuantity = RewardQuantity - 1 WHERE RewardID = @reward";
                cmd.Parameters.AddWithValue("@reward", reward[i].getRewardID());
                cmd.ExecuteNonQuery();
            }
        }

        for (int i = 0; i < arraySize; i++)
        {
            if (chkBuy[i].Checked == true)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE [User] SET AccountBalance = AccountBalance - @rewardAmount WHERE UserID = @userID";
                cmd.Parameters.AddWithValue("@userID", (int)Session["UserID"]);
                cmd.Parameters.AddWithValue("@rewardAmount", reward[i].getRewardAmount());
                cmd.ExecuteNonQuery();

                Session["AccountBalance"] = (decimal)Session["AccountBalance"] - Convert.ToDecimal(reward[i].getRewardAmount());
            }
        }

        if (itemSelected == true)
        {
            lblResult.Text = "Reward Claimed!";
            createRewardFeed();
        }
        else
        {
            lblResult.Text = "Please Select An Item";
        }


        con.Close();

        Response.Redirect(Request.RawUrl);

    }

    public void createRewardFeed()
    {
        Panel1.Controls.Clear();

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand read = new SqlCommand("SELECT * FROM [dbo].[Reward] WHERE [RewardQuantity] > 0 ORDER BY [RewardID] DESC", con);

        //Create Scaler to see how many rewards there are
        SqlCommand scaler = new SqlCommand("SELECT COUNT(RewardID) FROM [dbo].[Reward] WHERE [RewardQuantity] > 0", con);
        arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        reward = new Reward[arraySize];
        int arrayCounter = 0;

        if (arraySize != 0)
        {


            while (reader.Read())
            {
                reward[arrayCounter] = new Reward(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                    Convert.ToInt32(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToInt32(reader.GetValue(5)), Convert.ToDateTime(reader.GetValue(6)));
                arrayCounter++;
            }

            con.Close();
            panelPost = new Panel[arraySize];
            chkBuy = new CheckBox[arraySize];
            Panel[] panelText = new Panel[arraySize];
            Panel[] panelHeader = new Panel[arraySize];
            Panel[] panelFooter = new Panel[arraySize];
            con.Open();

            for (int i = 0; i < arraySize; i++)
            {
                panelPost[i] = new Panel();
                panelHeader[i] = new Panel();
                panelFooter[i] = new Panel();
                panelText[i] = new Panel();
                Label[] labelPost = new Label[4];


                labelPost[0] = new Label();
                labelPost[0].Text = "Reward Name: " + reward[i].getRewardName();

                panelHeader[i].Controls.Add(labelPost[0]);


                labelPost[1] = new Label();
                labelPost[1].Text = "Reward Quantity: " + reward[i].getRewardQuantity() + " available";


                panelText[i].Controls.Add(labelPost[1]);

                labelPost[2] = new Label();
                labelPost[2].Text = "Reward Amount: $" + reward[i].getRewardAmount();

                panelText[i].Controls.Add(new LiteralControl("<br />"));

                panelText[i].Controls.Add(labelPost[2]);

                chkBuy[i] = new CheckBox();
                chkBuy[i].AutoPostBack = true;
                panelFooter[i].Controls.Add(chkBuy[i]);

                labelPost[3] = new Label();
                labelPost[3].Text = " Check The Box To Select Item";
                panelFooter[i].Controls.Add(labelPost[3]);

                panelText[i].CssClass = "w3-container";
                panelHeader[i].CssClass = "w3-container w3-blue";
                panelFooter[i].CssClass = "w3-container w3-blue";
                panelPost[i].CssClass = "w3 - card - 4";

                panelPost[i].Style.Add("text-align", "left");
                panelHeader[i].Style.Add("text-align", "left");
                panelFooter[i].Style.Add("text-align", "left");

                panelPost[i].Style.Add("margin-top", "4px");
                panelPost[i].Style.Add("margin-bottom", "16px");
                panelHeader[i].Style.Add("font-size", "200%");
                panelFooter[i].Style.Add("padding", "4px");
                panelFooter[i].Style.Add("padding-left", "15px");

                Panel1.Controls.Add(panelPost[i]);
                panelPost[i].Controls.Add(panelHeader[i]);
                panelPost[i].Controls.Add(panelText[i]);
                panelPost[i].Controls.Add(panelFooter[i]);
            }
            con.Close();
        }
    }
}