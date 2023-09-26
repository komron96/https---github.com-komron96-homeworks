//task1

using System.Globalization;

Thread from1To100 = new Thread(DoWork1);
Thread from101To200 = new Thread(DoWork2);
from1To100.Start();
from101To200.Start();
static void DoWork1()
{
    for (int i = 1; i <= 100; i++)
    {
        Console.WriteLine("Поток 1" + i);
        Thread.Sleep(1000);
    }
}
static void DoWork2()
{
    for (int i = 101; i <= 200; i++)
    {
        Console.WriteLine("Поток 2: " + i);
        Thread.Sleep(1000);
    }
}


//task2
Thread evennumbers = new Thread(DoWork12);
Thread oddnumbers = new Thread(DoWork22);
evennumbers.Start();
oddnumbers.Start();
static void DoWork12()
{
    for (int i = 1; i <= 99; i++)
    {
        if (i % 2 == 0)
        {
            Console.WriteLine("Поток 1" + i);
            Thread.Sleep(1000);
        }
    }
}
static void DoWork22()
{
    for (int i = 1; i <= 99; i++)
        if (i % 2 != 0)
        {
            Console.WriteLine("Поток 1" + i);
            Thread.Sleep(1000);
        }
}


//task3
Thread from1To33 = new Thread(DoWork13);
Thread from34To66 = new Thread(DoWork23);
Thread from67To99 = new Thread(DoWork33);
from1To33.Start();
from34To66.Start();
from67To99.Start();
static void DoWork13()
{
    for (int i = 1; i <= 33; i++)
    {
        Console.WriteLine("Поток 1" + i);
        Thread.Sleep(1000);
    }
}
static void DoWork23()
{
    for (int i = 34; i <= 66; i++)
    {
        Console.WriteLine("Поток 2: " + i);
        Thread.Sleep(1000);
    }
}
static void DoWork33()
{
    for (int i = 67; i <= 99; i++)
    {
        Console.WriteLine("Поток 2: " + i);
        Thread.Sleep(1000);
    }
}

//task4
Thread AM = new Thread(DoWork13);
Thread MZ = new Thread(DoWork23);
AM.Start();
MZ.Start();

static void AM1()
{
    for (char letter = 'A'; letter <= 'M'; letter++)
    {
        Console.WriteLine("Поток 1: " + letter);
    }
}

static void MZ1()
{
    for (char letter = 'N'; letter <= 'Z'; letter++)
    {
        Console.WriteLine("Поток 2: " + letter);
    }
}


//task5
Thread divisionOf3 = new(Dowork51);
Thread divisionOf5 = new(Dowork52);

static void Dowork51()
{
    for(int i=1; i < 100; i++)
    {
        if(i % 3 ==0)
            Console.WriteLine("Потом:" +i);
    }
}
static void Dowork52()
{

    for(int i=1; i < 100; i++)
    {
        if(i % 5 ==0)
            Console.WriteLine("Потом:" +i);
    }
}

//task6
//Таск повторяется 

//task7
Thread sumOf = new(Dowork71);
Thread mupltiplicationOf = new(Dowork72);

static void Dowork71()
{
    int number = 0;
    for(int i=1; i < 100; i++)
    {
        number +=i;
    }
    Console.WriteLine("Сумма: " + number);
}
static void Dowork72()
{
    int number = 0;
    for(int i=1; i < 100; i++)
    {
        number *=i;
    }
    Console.WriteLine("Сумма: " + number);
}

//task8
Thread divisionOf3And5 = new(Dowork81);
Thread NotDivisionOf3and5 = new(Dowork82);

static void Dowork81()
{
    for(int i=1; i < 100; i++)
    {
        if (i % 3 == 0 || i % 5 == 0)
            Console.WriteLine("Потом:" +i);
    }
}
static void Dowork82()
{

    for(int i=1; i < 100; i++)
    {
        if (i % 3 != 0 && i % 5 != 0)
            Console.WriteLine("Потом:" +i);
    }
}

//task9
Thread from50To1 = new Thread(DoWork91);
Thread from100To51 = new Thread(DoWork92);

static void DoWork91()
{
    for (int i = 50; i <= 1; i--)
    {
        Console.WriteLine("Поток 1" + i);
    }
}
static void DoWork92()
{
    for (int i = 100; i <= 51; i--)
    {
        Console.WriteLine("Поток 2: " + i);
    }
}

//task10
Thread from01To100 = new Thread(DoWork101);
Thread ResultOfmultiplictionOfThread1 = new Thread(DoWork102);

static void DoWork101()
{
    for (int i = 1; i <= 100; i++)
    {
        Console.WriteLine("Поток 1" + i);
    }
}
static void DoWork102()
{
    for (int i = 1; i <= 100; i++)
    {
        int number = i*i;
        Console.WriteLine("Поток 2: " + number);
    }
}
