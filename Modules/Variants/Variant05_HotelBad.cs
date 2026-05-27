// <copyright file="Variant05_HotelBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant05_Room
{
    public int N;
    public string T;
    public double P;
}

public class Variant05_Booking
{
    public string Guest;
    public DateTime From;
    public DateTime To;
    public int RoomN;
}

public class Variant05_HotelBad
{
    private List<Variant05_Booking> bookings = new ();

    public string Book(Variant05_Room r, string guest, DateTime from, DateTime to)
    {
        for (int i = 0; i < this.bookings.Count; i++)
        {
            if (this.bookings[i].RoomN == r.N)
            {
                if (from < this.bookings[i].To && to > this.bookings[i].From)
                {
                    return "bad";
                }
            }
        }

        var b = new Variant05_Booking { Guest = guest, From = from, To = to, RoomN = r.N };
        this.bookings.Add(b);
        return "ok";
    }

    public double Price(Variant05_Booking b, Variant05_Room r)
    {
        var nights = (b.To - b.From).Days;
        return nights * r.P;
    }
}
