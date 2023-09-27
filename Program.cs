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
    Console.WriteLine("Some actions is taking place");
}

static void Action2() //метод который реализует какое то событие
{
    for(int i; i < 1000; i++)
    {
        Console.WriteLine("Itteration: I");
        Time.Sleep = 
    }
    
}

//task2 - Отмена управляемых потоков
//У приложения есть MAIN трэд и есть ветки

CancellationTokenSource cancell = new(); 
CancellationToken cancellationToken = cancell.Token; //Для отмены трэда создаётся ТОКЕН(struct) который выбрасывает исключение
