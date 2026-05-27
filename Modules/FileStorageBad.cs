// <copyright file="FileStorageBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules;

public class FileStorageBad
{
    public void Save(string p, string t)
    {
        File.WriteAllText(p, t);
    }

    public string Load(string p)
    {
        return File.ReadAllText(p);
    }
}
