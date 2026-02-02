using UnityEngine;

public class DollarBillsCalculator : MonoBehaviour
{
    [Header("Input")]
    public int amount;   // X dollars (no decimals)

    void Start()
    {
        if (IsValidAmount())
        {
            CalculateBills(amount);
        }
        else
        {
            Debug.LogError("Amount must be a non-negative whole number.");
        }
    }

    bool IsValidAmount()
    {
        return amount >= 0;
    }

    void CalculateBills(int total)
    {
        int hundreds = total / 100;
        total %= 100;

        int fifties = total / 50;
        total %= 50;

        int twenties = total / 20;
        total %= 20;

        int tens = total / 10;
        total %= 10;

        int fives = total / 5;
        total %= 5;

        int ones = total;

        PrintResults(hundreds, fifties, twenties, tens, fives, ones);
    }

    void PrintResults(int h, int f, int t, int te, int fi, int o)
    {
        Debug.Log(
            $"Payment Breakdown:\n" +
            $"$100 bills: {h}\n" +
            $"$50 bills: {f}\n" +
            $"$20 bills: {t}\n" +
            $"$10 bills: {te}\n" +
            $"$5 bills: {fi}\n" +
            $"$1 bills: {o}"
        );
    }
}
