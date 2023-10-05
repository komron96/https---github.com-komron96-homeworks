using Npgsql;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string connectionString = "Host=192.168.15.197;Port=5432;Username=komronsaydaliev;Password=Soe8dyu66FN76Diq;Database=core";

        // Создаем объект класса DatabaseConnection и открываем соединение
        DatabaseConnection dbConnection = new DatabaseConnection(connectionString);
        NpgsqlConnection conn = dbConnection.OpenConnection();

        if (conn != null)
        {
            // Создаем объект класса DataProcessor и выполняем запросы и обработку данных
            DataProcessor dataProcessor = new DataProcessor();
            List<string> results = dataProcessor.ExecuteQueryAndGetResults(conn);
            dataProcessor.ReadResult(results);

            // Закрываем соединение
            dbConnection.CloseConnection(conn);
        }
    }
}
