using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Reward
{
    private int rewardID;
    private String rewardName;
    private int rewardQuantity;
    private double rewardAmount;
    private int companyID;
    private int adminID;
    private DateTime dateAdded;
    
    // Setters
    public void setRewardID(int rewardID)
    {
        this.rewardID = rewardID;
    }

    public void setRewardName(String rewardName)
    {
        this.rewardName = rewardName;
    }

    public void setRewardQuantity(int rewardQuantity)
    {
        this.rewardQuantity = rewardQuantity;
    }

    public void setRewardAmount(double rewardAmount)
    {
        this.rewardAmount = rewardAmount;
    }

    public void setCompanyID(int companyID)
    {
        this.companyID = companyID;
    }

    public void setAdminID(int adminID)
    {
        this.adminID = adminID;
    }

    public void setDateAdded(DateTime dateAdded)
    {
        this.dateAdded = dateAdded;
    }

    // Getters
    public int getRewardID()
    {
        return this.rewardID;
    }

    public String getRewardName()
    {
        return this.rewardName;
    }

    public int getRewardQuantity()
    {
        return this.rewardQuantity;
    }

    public double getRewardAmount()
    {
        return this.rewardAmount;
    }

    public int getCompanyID()
    {
        return this.companyID;
    }

    public int getAdminID()
    {
        return this.adminID;
    }

    public DateTime getDateAdded()
    {
        return this.dateAdded;
    }

    public Reward()
    {

    }

    public Reward(int rewardID, String rewardName, int rewardQuantity, double rewardAmount, int companyID, int adminID, DateTime dateAdded)
    {
        setRewardID(rewardID);
        setRewardName(rewardName);
        setRewardQuantity(rewardQuantity);
        setRewardAmount(rewardAmount);
        setCompanyID(companyID);
        setAdminID(adminID);
        setDateAdded(dateAdded);
    }
}