using Npgsql;
using System;


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
            RateProcess rateProcessorVariable = new RateProcess();
            List<CurrencyRate> rateResult = rateProcessorVariable.RateQueryExecution(coreConn);
            rateProcessorVariable.PrintRateResult();

            // Закрываем соединение
            coreConnection.CloseConnection(coreConn);
        }


        DatabaseConnection procardConnection = new DatabaseConnection(procardConnectionString);
        NpgsqlConnection procardConn = procardConnection.OpenConnection();

        if (procardConn != null)
        {
            FimiProcess fimiProcessorVariable = new FimiProcess();
            List<FimiTransaction> fimiResult = fimiProcessorVariable.FimiQueryExecution(procardConn);
            fimiProcessorVariable.PrintFimiResult();

            // Закрываем соединение
            procardConnection.CloseConnection(procardConn);
        }
    }
}
