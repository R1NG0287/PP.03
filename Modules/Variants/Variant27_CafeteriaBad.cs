// <copyright file="Variant27_CafeteriaBad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules.Variants;

public class Variant27_MealPlan
{
    public string Type;
    public double P;
}

public class Variant27_Meal
{
    public string Student;
    public string Type;
    public DateTime D;
    public double P;
}

public class Variant27_CafeteriaBad
{
    private List<Variant27_Meal> meals = new ();

    public string Register(string student, string type, DateTime d)
    {
        if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
        {
            return "bad";
        }

        double price = 0;
        if (type == "breakfast")
        {
            price = 60;
        }
        else if (type == "lunch")
        {
            price = 120;
        }
        else if (type == "dinner")
        {
            price = 100;
        }

        this.meals.Add(new Variant27_Meal { Student = student, Type = type, D = d, P = price });
        return "ok";
    }

    public double Monthly(string student, int month)
    {
        double sum = 0;
        for (int i = 0; i < this.meals.Count; i++)
        {
            if (this.meals[i].Student == student && this.meals[i].D.Month == month)
            {
                sum = sum + this.meals[i].P;
            }
        }

        return sum;
    }
}
