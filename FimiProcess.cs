using Npgsql;
using System.Collections.Generic;
public interface IFimiProcess
{
    List<FimiTransaction> FimiQueryExecution(NpgsqlConnection conn);
}

public class FimiProcess : IFimiProcess
{
    private readonly List<FimiTransaction> _fimiList = new List<FimiTransaction>();

    public List<FimiTransaction> FimiQueryExecution(NpgsqlConnection conn)
    {
        const string fimiFile= "SQL-Fimi.sql";
        string sqlQuery = File.ReadAllText(fimiFile);
        using (var cmd = new NpgsqlCommand(sqlQuery, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    FimiTransaction fimiTransaction = new()
                    {
                        Date = reader.GetString(0),
                        Currency = reader.GetDecimal(2).ToString(),
                        Amount = reader.GetDecimal(1).ToString(),
                    };
                    _fimiList.Add(fimiTransaction);
                }
            }
        }
        return _fimiList;
    }

    //Данный метод предназначен для того чтобы передавать по очереди через yild элементы списка(объекты класса FimiProcess)
    //Например если в Programm прописать foreach то он не будет работать если метод GetNumerator не прописан
    public IEnumerator<FimiTransaction> GetEnumerator() 
    {
        foreach (FimiTransaction transaction in _fimiList)
            yield return transaction;
    }

    //Данный метод работает напрямую с элементами списками и не нуждается в методе GetNumerator
    public void PrintFimiResult()
    {
        foreach (FimiTransaction transactionSample in _fimiList)
        {
            Console.WriteLine($"Date: {transactionSample.Date}, Currency: {transactionSample.Currency}, Amount: {transactionSample.Amount}");
        }
    }
}