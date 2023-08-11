//Домашнее задание №14 - Модификаторы доступа

Person Koma = new Person("Koma");
Person1 Koma1 = new Person1("Koma"); //не будет доступен



//public 
public class Person
{
    public string Name {get; set;}
    public Person(string name)
    {
        Name = name;
    }
}

//private: доступность в рамках текущего класса 
private class Person1 
{   
    private string Name1 {get; set;}
    private Person1(string name1)
    {
        Name1=name1;
    }
}

//private protected : доступность - для текущего класса и производнных от него 
protected private class Person2
{   
    private string Name2 {get; set;}
    private protected Person2(string name2)
    {
        Name2=Name2;
    }
}

public class PersonVIP: Person2
{
    void Check()
    {
        Console.WriteLine(Person2.Name2)
    }
}

//proctected - достпуен в рамках проекта
protected class Person3
{
    protected void Check2()
    {
        Console.WriteLine("Barbie lets go party");
    }
}



//Домашнее задание - #15
// Классы
public abstract class Building
{
    public abstract string floor { get; set;}
}

// ООП - Наследование и полиморфизм.
public sealed class Elevator : Building
{
    public override string floor { get; set; }
    public string ElevatorNumber {get;set;}
}



// ООП - Инкапсуляция
public sealed class Apartmen : Building
{
    private string? _floor;
    private string? _numberOfRooms;
    public override string floor
    {
        get => _floor ?? string.Empty;
        set => _floor = value;
    }

    public string NumberOfRooms
    {
        get =>_numberOfRooms ?? string.Empty;
        set => _numberOfRooms = value;

    }

}



//Исключения 
try
{
    int x = 10;
    string y = (string) x; 

}

catch(ExceptionNumber1 ex1)
{   
    Console.WriteLine("Вы делаете какую то чушь");
}

finally
{
    Console.WriteLine("Всё норм, чилаут");
}


public sealed class ExceptionNumber1 : Exception
{
    public ExceptionNumber1() { }
    public ExceptionNumber1(string message) : base(message) { }
    public ExceptionNumber1(string message, System.Exception inner) : base(message, inner) { }
}