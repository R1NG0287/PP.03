// <copyright file="AuthorizationBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules;

public class AuthorizationBad
{
    public bool Login(string u, string p)
    {
        if (u == "admin" && p == "123")
        {
            return true;
        }

        if (u == "user" && p == "111")
        {
            return true;
        }

        return false;
    }
}
