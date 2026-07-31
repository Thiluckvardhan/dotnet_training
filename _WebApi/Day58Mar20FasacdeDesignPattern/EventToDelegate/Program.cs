using System;

public class Program
{
    public static void Main()
    {
        var goldservice = new GoldService();
        var evaluateservice = new EvaluateService();
        var calculateprice = new CalculatePrice();
        var payment = new Payment();

        goldservice.GoldOrder += evaluateservice.Evaluate;
        evaluateservice.EvaluateOrder += calculateprice.Calculate;
        calculateprice.CalcuatePrice += payment.AcceptPayment;

        goldservice.PlaceOrder("Chain");

    }
}
public class GoldService
{
    public event Action<string>? GoldOrder;
    public void PlaceOrder(string type) {
        Console.WriteLine($"Order for gold {type} being placed");
        GoldOrder?.Invoke(type);

    }
}
public class EvaluateService
{
    public event Action<string>? EvaluateOrder;
    public void Evaluate(string type)
    {
        Console.WriteLine("Enter weight");
        string? weight = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(weight))
        {
            Console.WriteLine("Invalid weight.");
            return;
        }

        Console.WriteLine($"The gold {type} is of weight {weight}g");
        EvaluateOrder?.Invoke(weight);
    }
}

public class CalculatePrice
{
    public event Action<string>? CalcuatePrice;
    public void Calculate(string weight)
    {
        if (!int.TryParse(weight, out var parsedWeight))
        {
            Console.WriteLine("Invalid weight format.");
            return;
        }

        string price = (14850 * parsedWeight).ToString();
        Console.WriteLine($"The calculated gold price is {price}");
        CalcuatePrice?.Invoke(price);
    }
}
public class Payment
{
    public void AcceptPayment(string price)
    {
        Console.WriteLine($"Payment successful of price {price}");
    }
}