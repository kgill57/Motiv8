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
using System.Web.UI.DataVisualization.Charting;

public partial class AnalyticsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rewardsGiven.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        RewardsPerMonth.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        rewardsReceived.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        topSales.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }

        if (!IsPostBack)
        {
            rewardsReceived.Visible = true;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;

        }

        loadProfilePicture();


    }

    protected void loadProfilePicture()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand balance = new SqlCommand("SELECT TotalBalance FROM Employer WHERE EmployerID =" + Convert.ToString((int)Session["EmployerID"]), con);
        double totalBalance = Convert.ToDouble(balance.ExecuteScalar());

        lblBalance.Text = totalBalance.ToString("$#.00");

        try
        {

            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "SELECT ProfilePicture FROM [dbo].[User] WHERE UserID =" + Convert.ToString((int)Session["UserID"]);
            string currentPicture = (String)select.ExecuteScalar();

            profilePicture.ImageUrl = "~/Images/" + currentPicture;
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];

        }
        catch (Exception)
        {

        }
        con.Close();
    }



    protected void giverAndReceiver_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (giverAndReceiver.SelectedIndex == 0)
        {
            rewardsReceived.Visible = true;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;
        }

        else if (giverAndReceiver.SelectedIndex == 1)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = true;
            topSales.Visible = false;
            RewardsPerMonth.Visible = false;
        }
        else if(giverAndReceiver.SelectedIndex == 2)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = false;
            topSales.Visible = true;
            RewardsPerMonth.Visible = false;
        }
        else if(giverAndReceiver.SelectedIndex == 3)
        {
            rewardsReceived.Visible = false;
            rewardsGiven.Visible = false;
            topSales.Visible = false;
            RewardsPerMonth.Visible = true;
        }
        
    }
}