using UnityEngine;

public class BookstoreCalculator : MonoBehaviour
{
    [Header("Input")]
    public float coverPrice;   // X
    public int copiesSold;     // Y

    const float DISCOUNT_RATE = 0.40f;
    const float FIRST_COPY_SHIPPING = 3f;
    const float ADDITIONAL_COPY_SHIPPING = 0.75f;

    void Start()
    {
        if (IsValidInput())
        {
            CalculateResults();
        }
        else
        {
            Debug.LogError("Cover price must be positive and copies sold must be at least 1.");
        }
    }

    bool IsValidInput()
    {
        return coverPrice > 0 && copiesSold > 0;
    }

    void CalculateResults()
    {
        float wholesaleCost = CalculateWholesaleCost();
        float shippingCost = CalculateShippingCost();
        float totalCost = wholesaleCost + shippingCost;
        float profit = CalculateProfit(totalCost);

        PrintResults(wholesaleCost, shippingCost, totalCost, profit);
    }

    float CalculateWholesaleCost()
    {
        float discountedPrice = coverPrice * (1 - DISCOUNT_RATE);
        return discountedPrice * copiesSold;
    }

    float CalculateShippingCost()
    {
        if (copiesSold == 1)
        {
            return FIRST_COPY_SHIPPING;
        }

        return FIRST_COPY_SHIPPING + (copiesSold - 1) * ADDITIONAL_COPY_SHIPPING;
    }

    float CalculateProfit(float totalCost)
    {
        float revenue = coverPrice * copiesSold;
        return revenue - totalCost;
    }

    void PrintResults(float wholesale, float shipping, float total, float profit)
    {
        Debug.Log(
            $"Bookstore Results:\n" +
            $"Wholesale cost: ${wholesale:F2}\n" +
            $"Shipping cost: ${shipping:F2}\n" +
            $"Total cost: ${total:F2}\n" +
            $"Profit: ${profit:F2}"
        );
    }
}