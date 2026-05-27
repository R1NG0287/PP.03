// <copyright file="Variant22_PolyclinicBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant22_Doctor
{
    public string N;
    public string Spec;
}

public class Variant22_Slot
{
    public Variant22_Doctor D;
    public DateTime Time;
    public string Patient;
}

public class Variant22_ClinicBad
{
    private List<Variant22_Slot> slots = new ();

    public string Issue(Variant22_Doctor d, DateTime time, string patient)
    {
        for (int i = 0; i < this.slots.Count; i++)
        {
            if (this.slots[i].D.N == d.N && this.slots[i].Time == time)
            {
                if (this.slots[i].Patient != null)
                {
                    return "bad";
                }

                this.slots[i].Patient = patient;
                return "ok";
            }
        }

        var s = new Variant22_Slot { D = d, Time = time, Patient = patient };
        this.slots.Add(s);
        return "ok";
    }
}
