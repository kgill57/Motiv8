using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class RewardTeamMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadProfilePicture();

        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"] + "  $" + ((Decimal)Session["AccountBalance"]).ToString("0.##");
            if (!IsPostBack)
            {
                ddlCompanyValue.ClearSelection();
                ddlCategory.ClearSelection();
                ddlRewardValue.ClearSelection();
                loadDropDown();
            }
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

    public void loadDropDown()
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        cmdInsert.CommandText = "SELECT Username FROM [User] WHERE [Admin] != 1 AND UserID != " + Convert.ToString((int)Session["UserID"]);

        SqlDataAdapter da = new SqlDataAdapter(cmdInsert);
        DataTable dt = new DataTable();

        da.Fill(dt);

        drpUsernames.DataSource = dt;
        drpUsernames.DataTextField = "Username";
        drpUsernames.DataBind();
        sc.Close();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        sendNotification();

        Post post = new Post();
        post.setValue(ddlCompanyValue.SelectedValue);
        post.setCategory(ddlCategory.SelectedValue);
        post.setDescription(txtDescription.Text);
        post.setRewardValue(Convert.ToDouble(ddlRewardValue.SelectedValue));
        post.setPostDate(DateTime.Now);
        post.setGiverID((int)Session["UserID"]);

        if (Convert.ToByte(chkPrivate.Checked) == 0)
        {
            post.setIsPrivate(false);
        }

        else if (Convert.ToByte(chkPrivate.Checked) == 1)
        {
            post.setIsPrivate(true);
        }

        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();

            System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
            cmdInsert.Connection = sc;


            if (checkTransactionDate(post.getGiverID()) == true)
            {

                cmdInsert.CommandText = "INSERT INTO [dbo].[Transaction] (CompanyValue, Category, Description, RewardValue, TransactionDate,"
                    + " Private, GiverID, ReceiverID) VALUES (@CompanyValue, @Category, @Description, @RewardValue, @TransactionDate, @Private," +
                    " @GiverID, @ReceiverID)";
                cmdInsert.Parameters.AddWithValue("@CompanyValue", post.getValue());
                cmdInsert.Parameters.AddWithValue("@Category", post.getCategory());
                cmdInsert.Parameters.AddWithValue("@Description", post.getDescription());
                cmdInsert.Parameters.AddWithValue("@RewardValue", post.getRewardValue());
                cmdInsert.Parameters.AddWithValue("@TransactionDate", post.getPostDate());
                cmdInsert.Parameters.AddWithValue("@Private", post.getIsPrivate());
                cmdInsert.Parameters.AddWithValue("@GiverID", (int)Session["UserID"]);
                cmdInsert.Parameters.AddWithValue("@ReceiverID", getRecieverID(drpUsernames.SelectedItem.Text));

                cmdInsert.ExecuteNonQuery();


                lblResult.Text = "Reward Sent.";


                sc.Close();

                try
                {
                    System.Data.SqlClient.SqlDataReader readerEmail;
                    SqlConnection checkemail = new SqlConnection();
                    checkemail.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
                    checkemail.Open();

                    SqlCommand reademail = new SqlCommand("SELECT TotalBalance FROM Employer WHERE CompanyName='ElkLogistics'"
                            , checkemail);
                    readerEmail = reademail.ExecuteReader();

                    Decimal totalBalance = 0;

                    while (readerEmail.Read())
                    {
                        totalBalance = readerEmail.GetDecimal(0);
                    }
                    checkemail.Close();

                    if (totalBalance < 500)
                    {
                        var fromAddress = new MailAddress("sdbasketball96@aol.com", "Elk Logistics");
                        var toAddress = new MailAddress("bennskych@gmail.com", "Administrator");
                        const string fromPassword = "Daisydoo#1pet";
                        const string subject = "Reward balance is below 500 dollars";
                        const string body = "Dear Administrator, It seems that"
                            + " the company account balance is below 500 dollars. Please consider adding additional"
                            + " money to the account some time today.";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.aol.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                    }
                }
                catch
                {

                }

                loadDropDown();
            }
        }

        catch
        {

        }
    }

    public void sendNotification()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Email FROM [User] WHERE Username=@username", con);
            cmd.Parameters.AddWithValue("@username", drpUsernames.SelectedValue);

            var fromAddress = new MailAddress("sdbasketball96@aol.com", "Elk Logistics Rewards");
            var toAddress = new MailAddress((String)cmd.ExecuteScalar(), "Test");
            const string fromPassword = "Daisydoo#1pet";
            const string subject = "You Received a Reward From a Co-Worker!";
            const string body = "Dear Team Member, You have received a reward from a fellow Team member. Login to find out who rewarded you!";


            var smtp = new SmtpClient
            {
                Host = "smtp.aol.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
        catch(Exception)
        {

        }
        
    }



    public Boolean checkTransactionDate(int giverID)
    {

        Boolean valid = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;

        cmdInsert.CommandText = "SELECT TransactionDate FROM [Transaction] WHERE TransID = (SELECT MAX(TransID) FROM [Transaction] WHERE GiverID=@giverID)";
        cmdInsert.Parameters.AddWithValue("@giverID", giverID);
        DateTime transDate = Convert.ToDateTime(cmdInsert.ExecuteScalar());

        System.Diagnostics.Debug.WriteLine(transDate);
        DateTime today = DateTime.Today.Date;
        if (transDate.Date == today)
        {
            lblResult.Text = "Cannot make 2 transactions in one day.";
            valid = false;
        }
            


        sc.Close();


        return valid;
    }

    public int getRecieverID(String username)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        sc.Open();

        System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand();
        cmdInsert.Connection = sc;
        cmdInsert.CommandText = "SELECT UserID FROM [User] WHERE Username = @username";

        cmdInsert.Parameters.AddWithValue("@username", username);

        int userID = (int)cmdInsert.ExecuteScalar();

        sc.Close();
        return userID;
    }

    protected void AutoFillRewardSendID_Click(object sender, EventArgs e)
    {
        txtDescription.Text = "Very good job!";
    }
}
