using Npgsql;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string coreConnectionString = "Host=192.168.15.197;Port=5432;Username=komronsaydaliev;Password=Soe8dyu66FN76Diq;Database=core";
        string procardConnectionString = "Host=192.168.15.228;Port=5432;Username=komronsaydaliev;Password=Soe8dyu66FN76Diq;Database=visa";

        // Создаем объект класса DatabaseConnection и открываем соединение
        DatabaseConnection coreConnection = new DatabaseConnection(coreConnectionString);
        NpgsqlConnection coreConn = coreConnection.OpenConnection();

        if (coreConn != null)
        {
            // Создаем объект класса DataProcessor и выполняем запросы и обработку данных
            DataProcessor dataProcessor = new DataProcessor();
            List<CurrencyRate> rateResult = dataProcessor.RateQueryExecution(coreConn);
            // dataProcessor.ReadRateResult(rateResult);

            // Закрываем соединение
            coreConnection.CloseConnection(coreConn);
        }


        DatabaseConnection procardConnection = new DatabaseConnection(procardConnectionString);
        NpgsqlConnection procardConn = procardConnection.OpenConnection();

        if (procardConn != null)
        {
            DataProcessor dataProcessor = new DataProcessor();
            List<FimiTransaction> fimiResult = dataProcessor.FimiQueryExecution(procardConn);
            // dataProcessor.ReadFimiResult(fimiResult);

            // Закрываем соединение
            procardConnection.CloseConnection(procardConn);
        }
    }
}
