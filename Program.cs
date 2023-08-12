//Принципы SOLID основаны на уровне логики программиста и построения архитектуры программы, а не синтаксиса языка
//SRP предпологает, что каждый отдельный взятый класс должен иметь отдельно взятую зону ответственности. Машина - ездит, самолёт летает. Совмещать нельзя
public abstract class Animal
{
    public abstract void Move();
}

public class Bird : Animal
{
    public override void Move()
    {
        Console.WriteLine("Flying");
    }
}

public class Dog : Animal
{
    public override void Move()
    {
        Console.WriteLine("Moving");
    }
}

//(Open/ClosedPrinciple) - (OCP) 
//предпологается что класс нельзя изменить, но можно дополнить, например ворона является подвидом вида Птиц но дополнительно она умеет имитировать звуки
//принцип достигается путём наследования 
public abstract class Birds
{
    public abstract void Fly();
}

public class Sparrow : Birds
{
    public override void Fly()
    {
        Console.WriteLine("Flying");
    }
       public void Soundimmitation()
    {
        Console.WriteLine("What's up nigga");
    }
}

//Liskov Substituion principle
//Дочерные классы должны иметь функцию замещения родительского класса
//То есть предпологается что свойства дочерних классов которые унаследованы от родителя должны вести себя так же как свойства родительсткого класса
//При этом дочерный класс может иметь хоть 1 свойство хоть, 10. Главное, что эти унаследованные свойства должы быть идентичны родительяским свойствам

public class Eagle : Birds
{
    public override void Fly() // Орёл выполняет то же действие что его родительский класс
    {
        Console.WriteLine("Flying");
    }
}

//Принцип разделения интерфейса (Interface Segregation Principle, ISP):
 //Связанно только с интерфейсом. Принцип говорит о том что в 1 интерфейс  нельзя совмещать слишком много функций
 //Интерфейсы следует разделять на более мелкие, специфичные и подходящие для конкретных сценариев.

interface IVehicle
{
    void SpeedUp();
}
interface ITrack
{
    public void CarryingCargo();
}


class Lexus570 : IVehicle
{
    public void SpeedUp()
    {
        Console.WriteLine("Speeding up");
    }
}

class  Track : ITrack
{  
    public void CarryingCargo()
    {
        Console.WriteLine("Aliexpress is your choice");
    }
}


//(Dependency Inversion Principle, DIP) -Принцип инверсии зависимостей 
//Модуль верхнего уровня должен зависеть от нижнего уровня
//Например модуль crm(где происходит главное взаимодейсвтие) должен зависеть от data.access(классы которые мы создали)