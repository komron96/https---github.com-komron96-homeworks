//Tasks 1, 2, 3, 7, 8
var cancellationTokenSource = new CancellationTokenSource(); //Для отмены какого либо метода создаём токен сорс

var x1 = DoStuffAsync1(cancellationTokenSource.Token); // передаём во входной параметр сам токен
var x2 = DoStuffAsync2();
var x3 = DoStuffAsync3();

Console.ReadKey();

//async делает метод асинхронным, но метод должен возвращать class TASK поэтому делаем метод Generic
//Создано 3 метода которые выполняются асинхронно первый из них выполняют работу WORK1, второй WORK2, третий WORK3
//Затем каждый метод ждёт 2 секунды и выдаёт результат и возвращает тип ТАСК
//Использование async and await не блокирует main тред
async Task<Work1> DoStuffAsync1(CancellationToken cancellationToken)
{
    Console.WriteLine("Some work 1");
    await Task.Delay(2000); //Ожидает некоторое количество времени и возвращает таск
    Console.WriteLine("Work1 done");
    return new();  //Для того чтобы метод был асинхронным метод обязательно должен быть возвращать класс Task
}

async Task<Work1> DoStuffAsync2(CancellationToken cancellationToken)
{
    Console.WriteLine("Some work 2");
    await Task.Delay(2000);
    Console.WriteLine("Work2 done");
    return new();
}
async Task<Work1> DoStuffAsync3(CancellationToken cancellationToken)
{
    Console.WriteLine("Some work 3");
    await Task.Delay(2000);
    Console.WriteLine("Work3 done");
    return new();
}
class Work1{}
class Work2{}
class Work3{}