// <copyright file="OrderProcessorFixed.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReviewSamples.Modules;

public record Order(int quantity, decimal unitPrice, bool hasDiscount);

public class OrderProcessorFixed
{
    private const decimal DiscountRate = 0.10m;
    private const decimal ExpensiveDeliveryLimit = 1000m;
    private const decimal StandardDeliveryPrice = 100m;
    private const decimal ExpensiveDeliveryPrice = 200m;

    public decimal Process(Order order)
    {
        Validate(order);

        var itemsTotal = order.quantity * order.unitPrice;
        var discountedTotal = ApplyDiscount(itemsTotal, order.hasDiscount);
        var deliveryPrice = CalculateDeliveryPrice(discountedTotal);

        return discountedTotal + deliveryPrice;
    }

    private static void Validate(Order order)
    {
        if (order.quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(order.quantity), "Количество должно быть больше нуля.");
        }

        if (order.unitPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(order.unitPrice), "Цена не может быть отрицательной.");
        }
    }

    private static decimal ApplyDiscount(decimal total, bool hasDiscount)
    {
        return hasDiscount ? total * (1 - DiscountRate) : total;
    }

    private static decimal CalculateDeliveryPrice(decimal total)
    {
        return total > ExpensiveDeliveryLimit ? ExpensiveDeliveryPrice : StandardDeliveryPrice;
    }
}
