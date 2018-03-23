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

public partial class TeamMemberPage : System.Web.UI.Page
{
    //Creates sql commands to be re-used when different sorting methods are selected
    SqlCommand read;
    SqlCommand scaler;
    SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        connectDB();

        if (giverAndReceiver.SelectedIndex == 0)
        {
            read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] ORDER BY [TransID] DESC", con);
            scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION]", con);
        }

        if (!IsPostBack)
        {
            loadNewsFeed();
            loadProfilePicture();
        }



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


    protected void loadNewsFeed()
    {
        con.Open();

        int arraySize = (int)scaler.ExecuteScalar();

        SqlDataReader reader = read.ExecuteReader();

        Post[] transaction = new Post[arraySize];
        int arrayCounter = 0;
        while (reader.Read())
        {
            transaction[arrayCounter] = new Post(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)),
                Convert.ToString(reader.GetValue(2)), Convert.ToString(reader.GetValue(3)), Convert.ToDouble(reader.GetValue(4)), Convert.ToDateTime(reader.GetValue(5)), Convert.ToBoolean(reader.GetValue(6)), Convert.ToInt32(reader.GetValue(7)), Convert.ToInt32(reader.GetValue(8)));
            arrayCounter++;
        }
        con.Close();
        Panel1.Controls.Clear();
        //Panel[] panelHeader = new Panel[arraySize];
        Panel[] panelPost = new Panel[arraySize];
        //Panel[] mainPanels = new Panel[arraySize];
        con.Open();

        for (int i = 0; i < arraySize; i++)
        {
            panelPost[i] = new Panel();
            panelPost[i].Controls.Add(new LiteralControl("<div class=\"col s12 m8 offset-m2 l6 offset-l3 card-panel grey lighten-5 z-depth-1 row valign-wrapper\"> "));
            panelPost[i].Controls.Add(new LiteralControl("<div style = \"float: left; width: 20%\"> <img src = \"images/userprofile3.jpg\" alt = \"\" class=\"circle feed responsive-img\"> </br> <img src=\"images/userprofile.jpg\" alt=\"#\" class=\"circle feed responsive-img\"> </div>"));
            panelPost[i].Controls.Add(new LiteralControl("<div style = \"float: left; width: 59%\"> <span class=\"black-text\"><strong>" + transaction[i].getGiverNickName(transaction[i].getGiverID()) + "</strong> rewarded <strong>" + transaction[i].getReceiverNickName(transaction[i].getReceiverID()) + "</strong> $" + transaction[i].getRewardValue() + ". </ span > </ div > "));
            panelPost[i].Controls.Add(new LiteralControl("<div style = \"float: right; width: 20%\"> <img src = \"" + getValueImageSrc(transaction[i].getValue()) + "\" alt = \"\" class=\"iconforvalue\" width = \"80%\"> </div>"));
            panelPost[i].Controls.Add(new LiteralControl("</div>"));

            Panel1.Controls.Add(panelPost[i]);
            //mainPanels[i].Controls.Add(panelHeader[i]);
            //mainPanels[i].Controls.Add(panelPost[i]);

        }

        con.Close();
    }
    protected void giverAndReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (giverAndReceiver.SelectedIndex == 0)
        {
            read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] ORDER BY [TransID] DESC", con);
            scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION]", con);
            loadNewsFeed();
        }

        else if (giverAndReceiver.SelectedIndex == 1)
        {
            read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR ReceiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);
            scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " OR ReceiverID=" + (int)Session["UserID"], con);
            loadNewsFeed();

        }
        else if (giverAndReceiver.SelectedIndex == 2)
        {
            read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);
            scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE GiverID=" + (int)Session["UserID"], con);
            loadNewsFeed();
        }
        else if (giverAndReceiver.SelectedIndex == 3)
        {
            read = new SqlCommand("SELECT * FROM [dbo].[TRANSACTION] WHERE ReceiverID=" + (int)Session["UserID"] + " ORDER BY [TransID] DESC", con);
            scaler = new SqlCommand("SELECT COUNT(TransID) FROM [dbo].[TRANSACTION] WHERE ReceiverID=" + (int)Session["UserID"], con);
            loadNewsFeed();
        }

    }
    protected void connectDB()
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
    }

    public static string getValueImageSrc(String value)
    {
        String imgSrc;
        //if statemets to select which value and image to show 
        if (value.Equals("Health, Well Being and Safety Of Team Members"))
        {
            imgSrc = "icons/grouphealth.png";
        }
        else if (value.Equals("Community Involvement"))
        {
            imgSrc = "icons/communityinv.png";
        }
        else if (value.Equals("Customer Service"))
        {
            imgSrc = "icons/customerservice.png";
        }
        else if (value.Equals("Retaining/Attracting New Customers"))
        {
            imgSrc = "icons/addcustomer.png";
        }
        else if (value.Equals("Leadership"))
        {
            imgSrc = "icons/leadership.png";
        }
        else if (value.Equals("Process Improvement Initiatives"))
        {
            imgSrc = "icons/process.png";
        }
        else if (value.Equals("Education"))
        {
            imgSrc = "icons/education.png";
        }
        else
        {
            imgSrc = "icons/teambuilding.png";
        }

        return imgSrc;
    }

}
