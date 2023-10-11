using Npgsql;
using System;
public interface IRateProcess
{
    List<CurrencyRate> RateQueryExecution(NpgsqlConnection conn);
}
public class RateProcess : IRateProcess
{
    private List<CurrencyRate> _rateList = new List<CurrencyRate>();
    public List<CurrencyRate> RateQueryExecution(NpgsqlConnection conn)
    {
        const string sqlQuery = "SQL-Rate.txt";
        string sqlContent = File.ReadAllText(sqlQuery);

        using (var cmd = new NpgsqlCommand(sqlContent, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CurrencyRate rate = new CurrencyRate
                    {
                        Date = reader.GetString(0),
                        Rate = reader.GetDecimal(1).ToString(),
                        Currency = reader.GetString(2)
                    };
                    _rateList.Add(rate);
                }
            }
        }
        return _rateList;
    }


    public IEnumerator<CurrencyRate> GetEnumerator()
    {
        foreach (CurrencyRate rate in _rateList)
            yield return rate;
    }

    public void PrintRateResult()
    {
        foreach (CurrencyRate rate in _rateList)
        {
            Console.WriteLine($"Date: {rate.Date}, Currency: {rate.Rate}, Amount: {rate.Currency}");
        }
    }
}










// public void ReadRateResult(List<string> rateList)
// {
//     for (int i = 0; i < rateList.Count; i += 3)
//     {
//         string date = rateList[i];
//         string rates = rateList[i + 1];
//         string currencies = rateList[i + 2];

//         Console.WriteLine($"На {date}, {currencies}: {rates} ");
//     }
// }
// public void ReadFimiResult(List<string> fimiList)
// {
//     for (int i = 0; i < fimiList.Count; i += 3)
//     {
//         string date = fimiList[i];
//         string account_currency = fimiList[i + 2];
//         string amount = fimiList[i + 1];

//         Console.WriteLine($"Дата: {date}, Amount: {amount}, Валюта: {account_currency}");
//     }
// }