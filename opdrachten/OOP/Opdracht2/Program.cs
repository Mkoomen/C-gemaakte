using Personen;
using System.Collections.Generic;
using static System.Console;

namespace OOP2
{
    public class Program
    {
        private static List<Persoon> personen = new List<Persoon>();

        public static void Main()
        {
            Invullen();
            PersonenWeergeven();
        }
        private static void Invullen()
        {
            personen = new List<Persoon>();

            Medewerker medewerker1 = new Medewerker("Mitch", "Koomen", "Student");
            medewerker1._geboortedatum = new DateOnly(2005, 10, 23);

            personen.Add(medewerker1);

            Medewerker medewerker2 = new Medewerker("Mees", "Boerman", "Student");
            medewerker2._geboortedatum = new DateOnly(2005, 02, 03);

            personen.Add(medewerker2);

        }
        private static void PersonenWeergeven()
        {
            foreach (Persoon persoon in personen)
            {
                Console.WriteLine(persoon.WieBenIk());
            }
        }
    }
}