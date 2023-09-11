int[] numbers = new int[] {20, 355, -33, 25, -55, 500, -2194, -239, 949, 30, 505, -505, 200, 2100, -300, 420};
string[] stroki = new string[] {"GgWp", "Amogus", "Definite", "Geopolitics", "GlobalWarming", "SomeIssues"};
string[] stroki2 = new string[] { "Hello", "World", "Alif", "Academy", "Car" };
int[] numbers2 = new int[] { 1, 2, 3, 4, 5, 6, 7 };

//1 - Select positive numbers
var first = 
    (from number in numbers
    where number > 0
    select number).ToList();

//2 - Select odd numbers
var second = 
    (from number in numbers
    where number % 2 !=0
    select number).ToList();

//3 - Select even and negative numbers
var third = 
    (from number in numbers
    where number % 2 ==0 && number < 0
    select number).ToList();

//4 - Select higher than 9 and positive
var four = 
    (from number in numbers
    where number > 0 && number > 9
    select number).ToList();

//5 - Select strings > 5 start with G
var five = 
    (from x in stroki
    where x.Length>5 && x.StartsWith("G") 
    select x).ToList();

//6 - Select strings < 5 start with F
var six = 
    (from x in stroki
    where x.Length<5 && x.StartsWith("F") 
    select x).ToList();

//7 - Select strings > 5 start with G
var seven = 
    (from x in stroki
    select x).ToList();

//8 - Select string from stroki2
var eight = 
    (from x in stroki2
    select x[0]).ToList();

//9 - Select int to string
var nine = 
    (from x in numbers2
    where x % 2 != 0
    select x.ToString()).ToList();