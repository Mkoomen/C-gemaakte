string[] array = { "peter", "is", "de", "broer", "van", "hans" };

foreach (string p in array)
{
    Console.Write(p);
    Console.Write(" ");
}

Console.Write("\n");

string[] array2 = { "peter", "is", "de", "broer", "van", "hans" };

var peter = array2[0];
var hans = array2[5];

array2[5] = peter;
array2[0] = hans;

foreach (string a in array2)
{
    Console.Write(a);
    Console.Write(" ");
}