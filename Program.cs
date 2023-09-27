//task1
Thread thread1 = new(Action1) //созданный тред у которого есть свойство приоритета, который в свою очередь принимает значение Normal.
{
    Priority = ThreadPriority.Normal
};

Thread thread2 = new(Action1)
{
    Priority = ThreadPriority.BelowNormal //Иной тред который принимает значение ниже нормального и будет выполняться после Normal
};

static void Action1() //метод который реализует какое то событие
{
    for (int i = 0; i < 1000; i++)
    {
        Console.WriteLine("Itteration:");
        Thread.Sleep(1000);
    }
}

//task2 - Отмена управляемых потоков
//У приложения есть MAIN трэд и есть ветки

CancellationTokenSource cancell = new();
//Для отмены трэда создаётся ТОКЕН(struct) который выбрасывает исключение

Thread thread3 = new(Action3);
thread3.Start();

if (Console.ReadKey().Key == ConsoleKey.Escape)
{
    cancell.Cancel();
}
void Action3(object boxedToken)
{
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(1000);
        CancellationToken token = (CancellationToken) boxedToken;
        token.ThrowIfCancellationRequested();
        Console.WriteLine("Itteration: " + i);
    }
}