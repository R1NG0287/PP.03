namespace ReviewSamples.Modules.Variants;

public enum DeliveryZone
{
    Near,
    Far
}

public record DeliveryPriceResult(decimal Price, string Message);

public class Variant16_CourierFixed
{
    private readonly Dictionary<DeliveryZone, IReadOnlyList<WeightPriceBand>> _tariffs = new()
    {
        [DeliveryZone.Near] = new List<WeightPriceBand>
        {
            new(0, 1, 200),
            new(1, 5, 350),
            new(5, 20, 600),
            new(20, double.MaxValue, 1000)
        },
        [DeliveryZone.Far] = new List<WeightPriceBand>
        {
            new(0, 1, 400),
            new(1, 5, 700),
            new(5, 20, 1200),
            new(20, double.MaxValue, 2000)
        }
    };

    public decimal CalculatePrice(double weight, DeliveryZone zone)
    {
        if (weight < 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "Вес не может быть отрицательным.");

        var bands = _tariffs.GetValueOrDefault(zone)
            ?? throw new ArgumentException($"Неизвестная зона доставки: {zone}", nameof(zone));

        var price = bands
            .FirstOrDefault(band => weight > band.MinWeightExclusive && weight <= band.MaxWeightInclusive)
            ?.Price;

        if (!price.HasValue)
            throw new InvalidOperationException($"Не удалось определить тариф для веса {weight} и зоны {zone}.");

        return price.Value;
    }


    public double Calc(Variant16_Parcel parcel)
    {
        if (parcel == null)
            throw new ArgumentNullException(nameof(parcel));

        if (!Enum.TryParse<DeliveryZone>(parcel.Zone, true, out var zone))
            throw new ArgumentException($"Недопустимая зона доставки: {parcel.Zone}");

        var price = CalculatePrice(parcel.Weight, zone);
        return (double)price;
    }

    private record WeightPriceBand(double MinWeightExclusive, double MaxWeightInclusive, decimal Price);
}
