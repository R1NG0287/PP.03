// <copyright file="Variant25_FuelStationBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant25_Fuel
{
    public string Brand;
    public double P;
}

public class Variant25_FuelStationBad
{
    public double Calc(Variant25_Fuel f, double liters)
    {
        double price = 0;

        if (f.Brand == "AI-92")
        {
            price = 50.5;
        }
        else if (f.Brand == "AI-95")
        {
            price = 53.0;
        }
        else if (f.Brand == "AI-98")
        {
            price = 58.0;
        }
        else if (f.Brand == "Diesel")
        {
            price = 56.0;
        }

        return liters * price;
    }
}
