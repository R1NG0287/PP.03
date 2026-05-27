// <copyright file="StatisticsFixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules;

public record StatisticsResult(double average, int min, int max, int count);

public class StatisticsFixed
{
    public StatisticsResult Calculate(IEnumerable<int> numbers)
    {
        if (numbers is null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        var values = numbers.ToList();

        if (values.Count == 0)
        {
            throw new ArgumentException("Список чисел не должен быть пустым.", nameof(numbers));
        }

        return new StatisticsResult(
            average: values.Average(),
            min: values.Min(),
            max: values.Max(),
            count: values.Count);
    }
}
