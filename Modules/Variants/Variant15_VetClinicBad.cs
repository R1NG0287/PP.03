// <copyright file="Variant15_VetClinicBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant15_Animal
{
    public string Species;
    public string N;
    public int Age;
}

public class Variant15_Visit
{
    public Variant15_Animal A;
    public DateTime D;
    public string Diag;
    public string Service;
    public double P;
}

public class Variant15_VetBad
{
    private List<Variant15_Visit> visits = new ();

    public string Register(Variant15_Visit v)
    {
        if (v.Diag == string.Empty)
        {
            return "bad";
        }

        this.visits.Add(v);
        Console.WriteLine("Registered visit for " + v.A.N + ", diag = " + v.Diag + ", price = " + v.P);
        return "ok";
    }
}
