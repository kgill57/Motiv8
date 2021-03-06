using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserOptions : System.Web.UI.Page
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

        // On initial page load, fill the gridview with all users in the database
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

    protected void btnInsertUser_Click(object sender, EventArgs e)
    {
        // Instantiate SQL objects, set up a SQL connection
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["lab4ConnectionString"].ConnectionString;
        con.Open();



        SqlCommand select = new SqlCommand();
        select.Connection = con;

        // Get the username the admin wants to insert into the database
        select.CommandText = "SELECT UserName FROM [dbo].[User] WHERE UserName = @UserName";

        select.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
        select.Parameters["@UserName"].Value = txtUsername.Text;

        // Check if the desired username is already in the database
        String existingUserName = (String)select.ExecuteScalar();
        if (existingUserName == null)
        {
            int adminBit;
            adminBit = Convert.ToInt32(ddlAccountType.SelectedItem.Value);

            String insertString;

            // Insert the new user into the database
            insertString = "INSERT INTO [dbo].[User] VALUES(@FName, ";

            // Check if the TextBox for the Middle Initial is empty or has white space
            // Pass a null value for MI if the user didn't fill out the TextBox
            if (String.IsNullOrWhiteSpace(txtMI.Text) == true)
            {
                insertString += "NULL,";
            }

            else
            {
                insertString += "@MI, ";
            }

            // SQL insert statement
            insertString += "@LName, @Email, @UserName, NULL, " + adminBit + ", " + (int)Session["UserID"] + ", @EmployerID, @AccountBalance, 1, '" + (String)Session["LName"] + "', '2018-01-01')";

            select.CommandText = insertString;

            // Make the first letter in the First Name TextBox uppercase
            select.Parameters.Add(new SqlParameter("@FName", SqlDbType.VarChar));
            select.Parameters["@FName"].Value = char.ToUpper(txtFName.Text[0]) + txtFName.Text.Substring(1);

            // Check if TextBox for MI was filled out
            if (String.IsNullOrWhiteSpace(txtMI.Text) == false)
            {
                // Make the character in the TextBox for MI uppercase
                select.Parameters.Add(new SqlParameter("@MI", SqlDbType.Char));
                select.Parameters["@MI"].Value = char.ToUpper(txtMI.Text[0]);
            }

            // Make the first letter in the Last Name TextBox uppercase
            select.Parameters.Add(new SqlParameter("@LName", SqlDbType.VarChar));
            select.Parameters["@LName"].Value = char.ToUpper(txtLName.Text[0]) + txtLName.Text.Substring(1);

            select.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
            select.Parameters["@Email"].Value = txtEmail.Text;

            // Set the EmployerID equal to the selected index of the corresponding drop down list + 1 to avoid indexing errors
            select.Parameters.Add(new SqlParameter("@EmployerID", SqlDbType.Int));
            select.Parameters["@EmployerID"].Value = CompanyDropdown.SelectedIndex + 1;

            // Set the new user's account balance equal to $0
            select.Parameters.Add(new SqlParameter("@AccountBalance", SqlDbType.Money));
            select.Parameters["@AccountBalance"].Value = 0;

            select.ExecuteNonQuery();

            // Create a password and password hash for the new user
            string password = "password";

            string passwordHashNew =
                       SimpleHash.ComputeHash(password, "MD5", null);
            select.CommandText = "SELECT [UserID] FROM [USER] WHERE [UserName] = @UserName";
            int userID = (int)select.ExecuteScalar();
            select.CommandText = "INSERT INTO[dbo].[Password] Values (" + userID + ", '" + passwordHashNew + "')";
            select.ExecuteNonQuery();

            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtMI.Text = "";
            txtUsername.Text = "";
            ddlAccountType.SelectedIndex = 0;
            CompanyDropdown.SelectedIndex = 0;
        }

        // Display an error message if the username already exists within the database
        else
        {
            lblError.Text = "This username is already taken";
        }

        // Close the SQL connection and update the gridview
        con.Close();
        fillGridView();
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

            System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("SELECT UserID, FName, LName, MI, Email, " +
                "Username, Admin, EmployedStatus, AccountBalance FROM [User];", sc);
            del.ExecuteNonQuery();

            grdUsers.DataSource = del.ExecuteReader();
            grdUsers.DataBind();
            sc.Close();

        }
        catch
        {

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
                " FROM [Password] WHERE UserID = @userID;", sc);
            del.Parameters.AddWithValue("@userID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
            del.ExecuteNonQuery();
            del.CommandText = "DELETE FROM [User] WHERE UserID=@userID";
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

        //Check if the project name Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvFName") as TextBox).Text.ToString()))
        {
            //projectNameError.Visible = true;
            //projectNameError.Text = "The project name cannot be empty";
            textError = false;
        }

        //Check if the Project Description Text box is empty
        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvLName") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvEmail") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (String.IsNullOrEmpty((grdUsers.Rows[e.RowIndex].FindControl("txtgvUsername") as TextBox).Text.ToString()))
        {
            //projectDescriptionErrror.Visible = true;
            //projectDescriptionErrror.Text = "Field cannot be empty";
            textError = false;
        }

        if (textError)
        {
            // Declare var variables to store the row currently being edited
            var ddl = grdUsers.Rows[e.RowIndex].FindControl("ddlgvAdmin") as DropDownList;
            var ddlEmployed = grdUsers.Rows[e.RowIndex].FindControl("drpStatus") as DropDownList;
            var newMI = grdUsers.Rows[e.RowIndex].FindControl("txtgvMI") as TextBox;

            sc.Open();

            // Declare the query string
            try
            {
                System.Data.SqlClient.SqlCommand del = new System.Data.SqlClient.SqlCommand("UPDATE [User] SET FName=@newFName, " +
                    "LName=@newLName, MI=@newMI, Email=@newEmail, Username=@newUsername, Admin=@newAdmin, EmployedStatus=@employedStatus WHERE UserID=@userID", sc);
                del.Parameters.AddWithValue("@newFName", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtgvFName") as TextBox).Text[0])
                    + (grdUsers.Rows[e.RowIndex].FindControl("txtgvFName") as TextBox).Text.Substring(1)));
                del.Parameters.AddWithValue("@newLName", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtgvLName") as TextBox).Text[0])
                    + (grdUsers.Rows[e.RowIndex].FindControl("txtgvLName") as TextBox).Text.Substring(1)));

                // Check if gridview column for MI is empty or not
                if (String.IsNullOrWhiteSpace(newMI.Text) == true)
                {
                    del.Parameters.AddWithValue("@newMI", DBNull.Value);
                }

                else if (String.IsNullOrWhiteSpace(newMI.Text) == false)
                {
                    del.Parameters.AddWithValue("@newMI", (char.ToUpper((grdUsers.Rows[e.RowIndex].FindControl("txtgvMI") as TextBox).Text[0])));
                }

                del.Parameters.AddWithValue("@newEmail", (grdUsers.Rows[e.RowIndex].FindControl("txtgvEmail") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newUsername", (grdUsers.Rows[e.RowIndex].FindControl("txtgvUsername") as TextBox).Text.ToString());
                del.Parameters.AddWithValue("@newAdmin", ddl.SelectedValue);
                del.Parameters.AddWithValue("@employedStatus", ddlEmployed.SelectedValue);
                del.Parameters.AddWithValue("@userID", Convert.ToInt32(grdUsers.DataKeys[e.RowIndex].Value.ToString()));
                del.ExecuteNonQuery();
                sc.Close();
                grdUsers.EditIndex = -1;
                fillGridView();
            }

            catch
            {

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
        txtFName.Text = "Test";
        txtMI.Text = "";
        txtLName.Text = "User";
        txtEmail.Text = "test@gmail.com";
        txtUsername.Text = "testUser";
    }
}