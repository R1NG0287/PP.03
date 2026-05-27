// <copyright file="Variant09_WarehouseBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant09_Product
{
    public string Code;
    public string N;
    public int Q;
}

public class Variant09_WarehouseBad
{
    private List<Variant09_Product> products = new ();

    public string Receive(Variant09_Product p, int q)
    {
        for (int i = 0; i < this.products.Count; i++)
        {
            if (this.products[i].Code == p.Code)
            {
                this.products[i].Q = this.products[i].Q + q;
                Console.WriteLine("Received " + q + " of " + p.N);
                return "ok";
            }
        }

        p.Q = q;
        this.products.Add(p);
        Console.WriteLine("Received " + q + " of " + p.N);
        return "ok";
    }

    public string Issue(Variant09_Product p, int q)
    {
        for (int i = 0; i < this.products.Count; i++)
        {
            if (this.products[i].Code == p.Code)
            {
                this.products[i].Q = this.products[i].Q - q;
                Console.WriteLine("Issued " + q + " of " + p.N);
                return "ok";
            }
        }

        return "bad";
    }
}
