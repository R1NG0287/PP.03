// <copyright file="Variant17_TravelAgencyBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant17_Tour
{
    public string Country;
    public int Nights;
    public double P;
}

public class Variant17_AgencyBad
{
    private List<Variant17_Tour> tours = new ();

    public Variant17_AgencyBad()
    {
        this.tours.Add(new Variant17_Tour { Country = "Turkey", Nights = 7, P = 50000 });
        this.tours.Add(new Variant17_Tour { Country = "Egypt", Nights = 10, P = 70000 });
        this.tours.Add(new Variant17_Tour { Country = "UAE", Nights = 5, P = 90000 });
    }

    public List<Variant17_Tour> Find(double max, int min)
    {
        var res = new List<Variant17_Tour>();

        for (int i = 0; i < this.tours.Count; i++)
        {
            if (this.tours[i].P <= max && this.tours[i].Nights >= min)
            {
                res.Add(this.tours[i]);
            }
        }

        Console.WriteLine("Found " + res.Count + " tours");
        return res;
    }
}
