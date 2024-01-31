public class PaymentSystem
{

    public decimal Fee(decimal amount, int initialPeriod, decimal extraPayment, int minPeriod, int maxPeiod)
    {
        if (initialPeriod < minPeriod || initialPeriod > maxPeiod)
        {
            throw new ArgumentException($"Inccorect credit period format");
        }
        else
        {
            int extraMonths = initialPeriod - minPeriod;
            decimal fee = extraMonths * extraPayment * amount;
            return fee;
        }
        
    }
    public decimal Payment(string productName, decimal amount, string phoneNumber, decimal creditRange, int period)
    {
        decimal totalAmount = amount;

        if (productName == "SmartPhone")
        {
            _ = Fee(amount, period, 0.03m, 3, 9);
        }
        else if (productName == "TV")
        {
            _ = Fee(amount, period, 0.04m, 3, 12);
        }
        else if (productName == "Computer")
        {
            _ = Fee(amount, period, 0.05m, 3, 18);
        }
        else
        {
            throw new ArgumentException($"Wrong produc");
        }

        Console.WriteLine($"{phoneNumber}: Вы успешно купили {productName} на сумму {totalAmount}, период рассчроки составляет {period} месяцев");

        return totalAmount;
    }

}