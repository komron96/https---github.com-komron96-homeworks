Bird x = new Bird();
x.Move();


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


