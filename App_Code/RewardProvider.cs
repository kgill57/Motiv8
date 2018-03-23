using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class RewardProvider
{
    private int providerID;
    private String name;
    private String email;

    // Setters
    public void setProviderID(int providerID)
    {
        this.providerID = providerID;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    // Getters
    public int getProviderID()
    {
        return this.providerID;
    }

    public String getName()
    {
        return this.name;
    }

    public String getEmail()
    {
        return this.email;
    }

    public RewardProvider(int providerID, String name, String email)
    {
        setProviderID(providerID);
        setName(name);
        setEmail(email);
    }

}