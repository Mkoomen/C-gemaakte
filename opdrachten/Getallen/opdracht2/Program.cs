using System;

namespace method2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kies een nummer tussen 1 t/m 4 uit:");
            string num = Console.ReadLine();
            GeefKaart(num);
        }
        private static string GeefKaart(string nummer)
        {
            int i = 1;

            do
            {
                switch (nummer)
                {
                    case "1":
                        Console.WriteLine("U heeft 1 gekozen. Dat is ruiten.");
                        break;
                    case "2":
                        Console.WriteLine("U heeft 2 gekozen. Dat is harten.");
                        break;
                    case "3":
                        Console.WriteLine("U heeft 3 gekozen. Dat is klaveren.");
                        break;
                    case "4":
                        Console.WriteLine("U heeft 4 gekozen. Dat is schoppen.");
                        break;
                    default:
                        Console.WriteLine("Kies een getal uit tussen '1 t/m 4!'");
                        break;
                }
                return null;
            } while (i < 4);
        }
    }
}