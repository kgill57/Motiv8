using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ManageCommunityPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblUser.Text = (String)Session["FName"] + " " + (String)Session["LName"];
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }

        if (!IsPostBack)
            fillGridView();

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

    protected void btnInsertUser_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
            con.Open();

            SqlCommand select = new SqlCommand();
            select.Connection = con;

            select.CommandText = "INSERT INTO [dbo].[EventPost] VALUES(@EventTitle, " +
                " @EventDesc, '" + DateTime.Today.ToString() + "', " + (int)Session["UserID"] + ")";

            select.Parameters.Add(new SqlParameter("@EventTitle", SqlDbType.VarChar));
            select.Parameters["@EventTitle"].Value = txtEventName.Text;

            select.Parameters.Add(new SqlParameter("@EventDesc", SqlDbType.VarChar));
            select.Parameters["@EventDesc"].Value = txtEventDesc.Text;



            select.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception a)
        {
            Console.WriteLine();
        }
        fillGridView();

        txtEventName.Text = "";
        txtEventDesc.Text = "";
    }

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();
            // Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT " +
                "* FROM [EventPost];", sc);
            del.ExecuteNonQuery();

            grdUsers.DataSource = del.ExecuteReader();
            grdUsers.DataBind();
            sc.Close();

        }
        catch (Exception a)
        {
            Console.WriteLine();
        }
    }

    protected void grdUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdUsers.EditIndex = e.NewEditIndex;
        fillGridView();
    }

    protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int num = Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString());
        Console.WriteLine();
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM [EventPost] WHERE EventPostID = @EventPostID;", sc);
            del.Parameters.AddWithValue("@EventPostID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void grdUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;


        if (textError)
        {

            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE [EventPost] SET EventTitle=@EventTitle, " +
                    "EventDesc=@EventDesc WHERE EventPostID=@EventPostID", sc);
                del.Parameters.AddWithValue("@EventTitle", (grdUsers.Rows[e.RowIndex].FindControl("EventTitleEdit") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@EventDesc", (grdUsers.Rows[e.RowIndex].FindControl("EventDescEdit") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@EventPostID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdUsers.EditIndex = -1;
                fillGridView();
            }
            catch (Exception a)
            {
                Console.WriteLine();
            }

        }
    }

    protected void grdUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdUsers.EditIndex = -1;
        fillGridView();
    }

    protected void btnAutoFillUser_Click(object sender, EventArgs e)
    {
        txtEventName.Text = "Test Event";
        txtEventDesc.Text = "Test Event Description";

    }
}