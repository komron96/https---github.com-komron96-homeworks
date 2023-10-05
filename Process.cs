using Npgsql;
using System;


public class DataProcessor
{
    public List<string> ExecuteQueryAndGetResults(NpgsqlConnection conn)
    {
        string sqlQuery = "SELECT TO_CHAR(DATE(datetime), 'DD.MM.YYYY') AS formatted_date, TO_CHAR(official_rate, 'FM999999999.00') AS official_rate, currency_from, currency_to FROM exchange_rates WHERE datetime BETWEEN '2023-09-29' AND '2023-10-01' AND type = 'standard' AND currency_from IN ('RUB','USD', 'EUR') AND currency_to = 'TJS';  ";
        List<string> results = new List<string>();

        using (var cmd = new NpgsqlCommand(sqlQuery, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string value1 = reader.GetString(0);
                    string value2 = reader.GetString(1);
                    string value3 = reader.GetString(2);
                    results.Add(value1);
                    results.Add(value2);
                    results.Add(value3);
                }
            }
        }

        return results;
    }
    public void ReadResult(List<string> results)
    {
        for (int i = 0; i < results.Count; i += 3)
        {
            string date = results[i];
            string rates = results[i + 1];
            string currencies = results[i + 2];

            Console.WriteLine($"На {date}, {currencies}: {rates} ");
        }
    }
}


