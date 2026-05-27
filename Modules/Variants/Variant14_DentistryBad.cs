// <copyright file="Variant14_DentistryBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant14_Doctor
{
    public string N;
    public string Spec;
}

public class Variant14_Appointment
{
    public Variant14_Doctor D;
    public string Patient;
    public DateTime Time;
}

public class Variant14_ClinicBad
{
    private List<Variant14_Appointment> apps = new ();

    public string Book(Variant14_Doctor d, string patient, DateTime time)
    {
        for (int i = 0; i < this.apps.Count; i++)
        {
            if (this.apps[i].D.N == d.N && this.apps[i].Time == time)
            {
                return "bad";
            }
        }

        var a = new Variant14_Appointment { D = d, Patient = patient, Time = time };
        this.apps.Add(a);

        Console.WriteLine("Booked " + patient + " to " + d.N + " at " + time);
        return "ok";
    }
}
