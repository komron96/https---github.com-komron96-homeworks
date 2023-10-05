using Npgsql;

public class DatabaseConnection
{
    private string connectionString;
    public DatabaseConnection(string connectionString)
    {
        this.connectionString = connectionString;
    }
    //создаём класс NpgSql в котором будет соединение 
    public NpgsqlConnection OpenConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Успешное подключение к базе данных.");
                return conn;
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Ошибка подключения к базе данных: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        return null;
    }
    public void CloseConnection(NpgsqlConnection conn)
    {
        if (conn != null && conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
        }
    }
}

