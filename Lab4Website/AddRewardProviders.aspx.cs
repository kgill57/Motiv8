using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddRewardProviders : System.Web.UI.Page
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

    protected void fillGridView()
    {
        try
        {


            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

            sc.Open();
            // Declare the query string.
            SqlCommand balance = new SqlCommand("SELECT TotalBalance FROM Employer WHERE EmployerID =" + Convert.ToString((int)Session["EmployerID"]), sc);
            double totalBalance = Convert.ToDouble(balance.ExecuteScalar());

            lblBalance.Text = totalBalance.ToString("$#.00");

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM RewardProvider;", sc);
            del.ExecuteNonQuery();

            grdProviders.DataSource = del.ExecuteReader();
            grdProviders.DataBind();
            sc.Close();

        }
        catch
        {

        }
    }

    protected void grdProviders_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdProviders.EditIndex = e.NewEditIndex;
        fillGridView();
    }

    protected void grdProviders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdProviders.EditIndex = -1;
        fillGridView();
    }

    protected void grdProviders_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Boolean textError = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;

        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdProviders.Rows[e.RowIndex].FindControl("txtgvProviderName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdProviders.Rows[e.RowIndex].FindControl("txtgvProviderEmail") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (textError)
        {
            sc.Open();
            // Declare the query string.
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE RewardProvider SET ProviderName=@newProvName, " +
                    "ProviderEmail=@newProvEmail WHERE ProviderID=@providerID", sc);
                del.Parameters.AddWithValue("@newProvName", char.ToUpper((grdProviders.Rows[e.RowIndex].FindControl("txtgvProviderName") as TextBox).Text[0])
                    + (grdProviders.Rows[e.RowIndex].FindControl("txtgvProviderName") as TextBox).Text.Substring(1));
                del.Parameters.AddWithValue("@newProvEmail", (grdProviders.Rows[e.RowIndex].FindControl("txtgvProviderEmail") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@providerID", Convert.ToInt32(grdProviders.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdProviders.EditIndex = -1;
                fillGridView();
            }
            catch
            {

            }


        }



    }

    protected void grdProviders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
            sc.Open();
            //Declare the query string.

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("DELETE" +
                " FROM RewardProvider WHERE ProviderID = @providerID;", sc);
            del.Parameters.AddWithValue("@providerID", Convert.ToInt32(grdProviders.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            sc.Close();
            fillGridView();
        }
        catch
        {

        }
    }

    protected void btnAddProvider_Click1(object sender, EventArgs e)
    {
        providerPanel.Visible = true;
    }



    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }


    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;


        sc.Open();
        //Declare the query string.

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand("INSERT INTO RewardProvider (ProviderName, ProviderEmail) VALUES (@providerName, @providerEmail)", sc);
        insert.Parameters.AddWithValue("@providerName", char.ToUpper(txtNewProviderName.Text[0]) + txtNewProviderName.Text.Substring(1));
        insert.Parameters.AddWithValue("@providerEmail", txtNewProviderEmail.Text);

        insert.ExecuteNonQuery();

        fillGridView();

        txtNewProviderName.Text = "";
        txtNewProviderEmail.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean textError = true;
        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty(txtSearch.Text))
        {
            try
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;


                sc.Open();
                //Declare the query string.

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT *" +
                    " FROM RewardProvider;", sc);
                del.ExecuteNonQuery();

                grdProviders.DataSource = del.ExecuteReader();
                grdProviders.DataBind();
                sc.Close();
            }
            catch
            {

            }
        }
        else
        {
            try
            {

                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
                sc.Open();
                // Declare the query string.

                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT * FROM RewardProvider WHERE ProviderName LIKE '%' + @ProviderName;", sc);
                del.Parameters.AddWithValue("@ProviderName", txtSearch.Text);
                del.ExecuteNonQuery();

                grdProviders.DataSource = del.ExecuteReader();
                grdProviders.DataBind();
                sc.Close();

            }
            catch
            {

            }
        }
    }

    protected void btnClear_Click1(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }



    protected void AutoFillRewardProviderID_Click(object sender, EventArgs e)
    {
        txtNewProviderName.Text = "Test Provider";
        txtNewProviderEmail.Text = "testprovider@gmail.com";
        
    }



    protected void grdProviders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

        int RowIndex = gvr.RowIndex + 1;

        //int providerID = Convert.ToInt16(grdProviders.Rows[RowIndex].Cells[0].Text);

        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT ProviderName, ProviderEmail, ProviderDescription FROM Application WHERE ProviderID = " + RowIndex;
        cmd.Connection = con;
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            string name = Convert.ToString(reader.GetValue(0));
            string email = Convert.ToString(reader.GetValue(1));
            string desc = Convert.ToString(reader.GetValue(2));

            txtCompanyName.Text = name;
            txtEmail.Text = email;
            txtDesc.Text = desc;
        }
        

        

        appPanel.Visible = true;






        
    }
}
