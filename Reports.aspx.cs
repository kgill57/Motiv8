//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChooseReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ChooseReport.SelectedValue == "Employer Report")
        {
            EmployerReport.Visible = true;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Event Post Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = true;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Password Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = true;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Reward Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = true;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Reward Earned Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = true;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Reward Provider Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = true;
            TransactionReport.Visible = false;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "Transaction Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = true;
            UserReport.Visible = false;
        }
        else if (ChooseReport.SelectedValue == "User Report")
        {
            EmployerReport.Visible = false;
            EventPostReport.Visible = false;
            PasswordReport.Visible = false;
            RewardReport.Visible = false;
            RewardEarnedReport.Visible = false;
            RewardProviderReport.Visible = false;
            TransactionReport.Visible = false;
            UserReport.Visible = true;
        }
    }
}
