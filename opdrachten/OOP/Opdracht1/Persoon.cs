using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen
{
    public class Persoon
    {
        public static void Main(string[] args)
        {

        }
        public virtual string WieBenIk()
        {
            return $"Ik ben {VoorNaam} {AchterNaam}, en ik ben geboren op {GeboorteDatum}";
        }
        public Persoon(string voornaam, string achternaam)
        {
            VoorNaam = voornaam;
            AchterNaam = achternaam;
    }
        public DateOnly _geboortedatum;

        public string VoorNaam { get; set; }
        public string AchterNaam { get; set; }

        public DateOnly GeboorteDatum
        {
            get
            {
                return _geboortedatum;  
            }
            private set
            {
                _geboortedatum = value;
            }
        }
    }
}
