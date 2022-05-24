using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
            private static Dictionary<String, Double> _voertuigenlijst;
            private static Queue<String> _file;

            public static void Main(string[] args)
            {
                Initialiseer();
                Simuleer();
            }
            private static void Initialiseer()
            {
                _voertuigenlijst = new Dictionary<string, double>();
                _voertuigenlijst.Add("Mazda rx7", 4.5);
                _voertuigenlijst.Add("Mx5 miata", 3.8);
                _voertuigenlijst.Add("Datsun 240z", 4.3);
                _voertuigenlijst.Add("Nissan skyline", 4.6);

                _file = new Queue<string>();
            }
            private static void Simuleer()
            {
                bool juisteKeuze = false;
                var loop = true;    
                do
                {
                    string keuze = Haalkeuze();

                    switch (keuze)
                    {
                        case "toevoegen":
                            voegToe();
                            loop = false;
                            break;
                        case "verwijderen":
                            Verwijder();
                            loop = false;
                            break;
                        case "stoppen":
                            stoppen();
                            loop = false;
                            break;
                    }
                } while (loop);
        }
            private static string Haalkeuze()
            {
                Console.WriteLine();
                Console.Write("Wilt u toevoegen, verwijderen of stoppen? ");
                var haalKeuze = Console.ReadLine();
                Console.WriteLine();
                return haalKeuze;
            }
            private static void voegToe()
            {
                var loop = true;
                do
                {
                    Printvoertuigen();
                    string voertuig = HaalVoertuig();

                switch (voertuig)
                    {
                        case "Mazda rx7":
                            loop = false;
                            _file.Enqueue("Mazda rx7");
                            Console.WriteLine("Mazda rx7 toegevoegd!");
                            PrintFileGegevens();
                            Simuleer();
                            break;
                        case "Mx5 miata":
                            loop = false;
                            _file.Enqueue("Mx5 miata");
                            Console.WriteLine("Mx5 miata toegevoegd!");
                            PrintFileGegevens();
                            Simuleer();
                            break;
                        case "Datsun 240z":
                            loop = false;
                            _file.Enqueue("Datsun 240z");
                            Console.WriteLine("Datsun 240z toegevoegd!");
                            PrintFileGegevens();
                            Simuleer();
                            break;
                        case "Nissan skyline":
                            loop = false;
                            _file.Enqueue("Nissan skyline");
                            Console.WriteLine("Nissan skyline toegevoegd!");
                            PrintFileGegevens();
                            Simuleer();
                            break;
                    }
                } while (loop);
        }
            private static void Printvoertuigen()
            {
                Console.WriteLine("Voertuigen lijst: ");
                Console.WriteLine();
                _voertuigenlijst.ToList().ForEach(x => Console.WriteLine(x.Key));
                Console.WriteLine();
            }
            private static string HaalVoertuig()
            {
                Console.WriteLine("Welk voertuig wilt u toevoegen?");
                string voertuig = Console.ReadLine();
                Console.WriteLine();

                return voertuig;
            }
            private static void Verwijder()
            {
                string voertuig = _file.Dequeue();
                Console.WriteLine("Dit voertuig is verwijdert: " + voertuig);

                Simuleer();
            }
            private static void stoppen()
            {
                Console.WriteLine("U heeft het programma gestopt");

                Environment.Exit(0);
            }
            private static void PrintFileGegevens()
            {
                Console.WriteLine();
                Console.Write("File: ");
                foreach (string number in _file)
                {
                    Console.Write("[" + number + "] ");
                }
                Console.WriteLine();

                double meters = 0;
                
                foreach (var obj in _file)
                {
                    meters += _voertuigenlijst[obj];
                }
                Console.WriteLine("De file is " + meters + " meter lang.");
            }
    }   

}