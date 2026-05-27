// <copyright file="Variant21_InventoryBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant21_Equipment
{
    public string Inv;
    public string N;
    public string Status;
    public string Dept;
}

public class Variant21_InventoryBad
{
    private List<Variant21_Equipment> items = new ();

    public string Add(Variant21_Equipment e)
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i].Inv == e.Inv)
            {
                return "bad";
            }
        }

        this.items.Add(e);
        return "ok";
    }

    public string MoveTo(Variant21_Equipment e, string dept)
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i].Inv == e.Inv)
            {
                this.items[i].Dept = dept;
                Console.WriteLine("Moved " + e.N + " to " + dept);
                return "ok";
            }
        }

        return "bad";
    }
}
