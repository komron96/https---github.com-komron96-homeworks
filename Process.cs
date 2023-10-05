using Npgsql;
using System;


public class DataProcessor
{
    public List<string> RateQueryExecution(NpgsqlConnection conn)
    {
        string sqlQuery = "SELECT DISTINCT TO_CHAR(DATE(datetime), 'DD.MM.YYYY') AS formatted_date, TO_CHAR(official_rate, 'FM999999999.00') AS official_rate, currency_from, currency_to FROM exchange_rates WHERE datetime BETWEEN '2023-09-29' AND '2023-10-01' AND type = 'standard' AND currency_from IN ('RUB','USD', 'EUR') AND currency_to = 'TJS';  ";
        List<string> rateList = new List<string>();

        using (var cmd = new NpgsqlCommand(sqlQuery, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string value1 = reader.GetString(0);
                    string value2 = reader.GetString(1);
                    string value3 = reader.GetString(2);
                    rateList.Add(value1);
                    rateList.Add(value2);
                    rateList.Add(value3);
                }
            }
        }

        return rateList;
    }

    
    public List<string> FimiQueryExecution(NpgsqlConnection conn)
    {
        string sqlQuery = "SELECT TO_CHAR(DATE(datetime), 'DD.MM.YYYY') AS formatted_date, amount, account_currency from fimi_transaction WHERE datetime BETWEEN '2023-09-01 00:00:00' AND '2023-09-01 23:59:09' AND tran_code NOT IN ('624', '801') AND (tran_type <> '420' OR tran_number NOT IN ( SELECT DISTINCT tran_number FROM fimi_transaction WHERE datetime BETWEEN '2023-09-01 00:00:00' AND '2023-09-01 23:59:09' AND tran_type = '420')) and tran_number in ('324400381536', '324400222004', '324447494025', '324403101003', '324400400170', '324450465642');";
        List<string> fimiList = new List<string>();
        
        using (var cmd = new NpgsqlCommand(sqlQuery, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                string date = reader.GetString(0);
                decimal amount = reader.GetDecimal(1); 
                decimal currency = reader.GetDecimal(2);

                fimiList.Add(date);
                fimiList.Add(amount.ToString());
                fimiList.Add(currency.ToString());
                }
            }
        }
        return fimiList;
    }


    public void ReadRateResult(List<string> rateList)
    {
        for (int i = 0; i < rateList.Count; i += 3)
        {
            string date = rateList[i];
            string rates = rateList[i + 1];
            string currencies = rateList[i + 2];

            Console.WriteLine($"На {date}, {currencies}: {rates} ");
        }
    }
    public void ReadFimiResult(List<string> fimiList)
    {
        for (int i = 0; i < fimiList.Count; i += 3)
        {
            string date = fimiList[i];
            string account_currency = fimiList[i + 2];
            string amount = fimiList[i + 1];

            Console.WriteLine($"Дата: {date}, Amount: {amount}, Валюта: {account_currency}");
        }
    }
}


