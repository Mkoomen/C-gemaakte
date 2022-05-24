using System;
using System.Collections;

namespace Collections
{
    class Program
    {
        public static void Main(string[] args)
        {
            var stapel = new Stack<string>();
            VulStack(stapel, 1);
        }
        private static void VulStack(Stack<string> stapel, int aantal)
        {
            Console.Write("Geef waarde nummer 1: ");
            var waarde1 = Console.ReadLine();
            Console.Write("Geef waarde nummer 2: ");
            var waarde2 = Console.ReadLine();
            stapel.Push(waarde1);
            stapel.Push(waarde2);
            PrintStack(stapel);
            CheckList(stapel);
        }
        private static void CheckList(Stack<string> stapel)
        {
            Console.WriteLine();
            Console.WriteLine("Geef een waarde die in de stack zit: ");
            var Check = Console.ReadLine();
            var TopCheck = stapel.Peek();

            if (stapel.Count > 1)
            {

                if (Check == TopCheck)
                {
                    Console.WriteLine("Deze waarde ligt bovenop de stack!");
                    stapel.Pop();
                    PrintStack(stapel);
                    CheckList(stapel);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Deze waarde ligt niet bovenop de stack");
                    Console.WriteLine();
                }
                VulStack(stapel, 1);
            }
            else
            {
                Console.WriteLine("De stack is leeg!");
                System.Environment.Exit(0);
            }
        }
        private static void PrintStack(Stack<string> stapel)
        {
            Console.WriteLine();
            foreach (string number in stapel)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}