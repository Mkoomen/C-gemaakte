using System;
class method1
{
    private static int Leesgeheelgetal(int input)
    {
        return input;
    }
    private static int plusSom(int getal1, int getal2)
    {
        return getal1 + getal2;
    }
    private static int Verschil(int getal1, int getal2)
    {
        return getal1 - getal2;
    }
    private static int Product(int getal1, int getal2)
    {
        return getal1 * getal2;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Voer getal 1 in:");
        var num1 = Console.ReadLine();
        Console.WriteLine("Voer getal 2 in:");
        var num2 = Console.ReadLine();
        int numm1 = Int32.Parse(num1);
        int numm2 = Int32.Parse(num2);

        int check = Leesgeheelgetal(numm1);
        int som = plusSom(check, numm2);
        int min = Verschil(check, numm2);
        int keer = Product(check, numm2);


        Console.WriteLine(check + " + " + num2 + " = " + som);
        Console.WriteLine("Het verschil van " + check + " en " + num2 + " = " + min);
        Console.WriteLine("Het product van " + check + " en " + num2 + " = " + keer);
    }
}