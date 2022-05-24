using System;
using System.Collections;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stageOpdracht
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wilt u data toevoegen, verwijderen of updaten in de database?");
            string keuze = Console.ReadLine();
            Keuze(keuze);
        }
        static void Keuze(string keuze)
        {
            switch (keuze)
            {
                case "toevoegen" or "Toevoegen":
                    AddData();
                    break;
                case "verwijderen" or "Verwijderen":
                    DeleteData();
                    break;
                case "updaten" or "Updaten":
                    UpdateData();
                    break;
            }
        }
        static void AddData()
        {
            Console.WriteLine("Wat is de naam van Uw straat?");
            string straat = Console.ReadLine();
            Console.WriteLine("Wat is Uw huisnummer?");
            string huisnummer = Console.ReadLine();
            Console.WriteLine("Wat is Uw postcode?");
            string postcode = Console.ReadLine();
            Console.WriteLine("Wat is Uw woonplaats?");
            string plaats = Console.ReadLine();
            Console.WriteLine("Wat is Uw land?");
            string land = Console.ReadLine();

            AddDataFunction(straat, huisnummer, postcode, plaats, land);
        }
        static void AddDataFunction(string straat, string huisnummer, string postcode, string plaats, string land)
        {
            string dbfile = "URI=file:StageDb.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string addAdress = "insert into adressen(Straat, Huisnummer, Postcode, Plaats, Land) values ('" + straat + "', '" + huisnummer + "', '" + postcode + "', '" + plaats + "', '" + land + "');";
            SQLiteCommand command = new SQLiteCommand(addAdress, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Adress succesvol toegevoegd!");
            Console.ReadLine();
        }
        static void DeleteData()
        {
            Console.WriteLine("Wat is de postcode van het adress dat u wilt verwijderen?");
            string verwijderPostcode = Console.ReadLine();
            Console.WriteLine("Wat is het huisnummer van het adress dat u wilt verwijderen?");
            string verwijderHuisnum = Console.ReadLine();

            DeleteDateFunction(verwijderPostcode, verwijderHuisnum);
        }
        static void DeleteDateFunction(string postcode, string huisnum)
        {
            string dbfile = "URI=file:StageDb.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string deleteAdres = "DELETE FROM Adressen WHERE Postcode = '" + postcode + "' AND Huisnummer = '" + huisnum + "'";
            SQLiteCommand command = new SQLiteCommand(deleteAdres, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Adress succesvol verwijdert!");
            Console.ReadLine();
        }
        static void UpdateData()
        {
            Console.WriteLine("Wat is de postcode van het adress dat u wilt verwijderen?");
            string updatePostcode = Console.ReadLine();
            Console.WriteLine("Wat is het huisnummer van het adress dat u wilt verwijderen?");
            string updateHuisnum = Console.ReadLine();
        }
        static void UpdateDataFunction()
        {
            string dbfile = "URI=file:StageDb.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            string updateAdress = "UPDATE adressen set NAME='Big chungus' WHERE ID=1  ;";
            SQLiteCommand command = new SQLiteCommand(updateAdress, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Adress succesvol geupdate!");
            Console.ReadLine();
        }
    }
}