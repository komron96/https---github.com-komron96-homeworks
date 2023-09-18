//Task1
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

int[] numbers = new int[] { 21, 33, 455, 23, 522, 63, 52, -22, 34, -432, 102, -445, 65, -5123, 105, 25, 740, 105, 42, 99, 355, 56 };
var task1 = (from number in numbers where number >= 10 && number <= 99 orderby number select number).ToList();
task1.ForEach(x => Console.WriteLine(x));

//Task2
string[] strs = new[] { "TOMS", "BOBDD", "SAMSS", "TIDDM", "THOMASS", "BILL", "ALEXADNER", "KOMRON", "TWISTEDMETAL", "GAMEOFCLOWNS" };
var task2 = strs.OrderBy(p => p.Length).ThenByDescending(p => p).ToList();
task2.ForEach(x => Console.WriteLine(x));

//Task3
//Unfortunately cant solve

//Task4
var task4 = numbers.Where(p => p > 0).Select(p => p % 10).First();

//Task5
var task5 = strs.Select(s => s.Length % 2 != 0 ? s[0] : s[s.Length - 1]);

//Task6
int K1 = 433;
int K2 = 129;

List<int> A = new List<int> { 552, 6321, 8432,1322,1355, 43,333 };
List<int> B = new List<int> { 754, 923, 11523, 52313, 16223, 4333,344};

var task6 = A.Where(p=> p>K1).Where(p=>p<K2).OrderBy(p=>p);