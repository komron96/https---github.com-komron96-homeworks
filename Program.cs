//task1,6
Thread thread1 = new(Action1) //созданный тред у которого есть свойство приоритета, который в свою очередь принимает значение Highest.
{
    Priority = ThreadPriority.Highest
};

Thread thread2 = new(Action1)
{
    Priority = ThreadPriority.BelowNormal //Иной тред который принимает значение ниже нормального и будет выполняться после Normal или всё что выше normal включая highest
};

static void Action1() //метод который реализует какое то событие
{
    for (int i = 0; i < 1000; i++)
    {
        Console.WriteLine("Itteration:");
        Thread.Sleep(1000);
    }
}

//task2, 7 - Отмена управляемых потоков
//У приложения есть MAIN трэд и есть ветки

CancellationTokenSource cancell = new CancellationTokenSource();
//Для отмены трэда создаётся ТОКЕН(struct) который выбрасывает исключение

Thread thread3 = new Thread(Action3);
thread3.Start(cancell.Token); //Запускаем тред и передаём в него созданный токен

while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.Escape)
    {
        cancell.Cancel();
        break;
    }
}
void Action3(object boxedToken)
{
    try
    {
        CancellationToken token = (CancellationToken)boxedToken;
        for (int i = 0; i < 1000; i++)
        {
            Thread.Sleep(1000);
            token.ThrowIfCancellationRequested();
            Console.WriteLine("Itteration: " + i);
        }
    }
    //task5 - Так как треды начинаются выполняться с мейн треда то исключения которые присходят в доп тредах не могут пойманы мейнтредом
    //Поэтому исключения должны обрабатываться только в методах которые являются входным параметром самого треда.
    catch (System.Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}  //Созданная программа запускает цикл через тред который начаинется считать до 1000 и если нажать escape то будет исключение

//task 3

Thread thread4 = new(Action5);
thread4.Start();
Thread.Sleep(2000);  //Запускается поток который выполяет метод Action5 (цикл выполнения работы) и через 2 секунды он прерывается абортится
thread4.Abort();
void Action5()
{
    try
    {
        while (true)
        {
            Console.WriteLine("Р - значит работа");
            Thread.Sleep(1000);
        }
    }
    catch (ThreadAbortException)
    {
        Console.WriteLine("Aborted");
    }
}


//task9
//Создаём таймер
System.Timers.Timer timer = new(3000);
timer.Elapsed += Elapse;
timer.Enabled = true;
timer.Start();

static void Elapse(object? sender, ElapsedEventArgs e)
{
    Console.WriteLine("Timer elapsed");
}