using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace PracaZSerializacja
{
 
    class Program
    {
        static void Main(string[] args)
        {
            //Serializacja XML
            List<Osoba> osoby = new List<Osoba> {
                new Osoba(30000M) {DataUrodzenia = new DateTime(1974, 3, 14), Imie = "Alicja", Nazwisko = "Nowak"},
                new Osoba(20000M) {DataUrodzenia = new DateTime(1969, 2, 19), Imie = "Jan", Nazwisko = "Kowalski"},
                new Osoba(0M) {DataUrodzenia = new DateTime(1939, 12, 18), Imie = "Celina", Nazwisko = "Rozenek"},
                new Osoba(5000M) {DataUrodzenia = new DateTime(1975, 1, 2), Imie = "Marek", Nazwisko = "Kowal", Dzieci = new HashSet<Osoba>{
                    new Osoba(0M) {DataUrodzenia = new DateTime(1988, 2, 15), Imie = "Anna", Nazwisko = "Kowal"},
                    new Osoba(0M) {DataUrodzenia = new DateTime(1990, 9, 20), Imie = "Patryk", Nazwisko = "Kowal"}
                    }
                }

            };

            string sciezka = Path.Combine(Environment.CurrentDirectory,"osoby.xml");

            FileStream strumien = File.Create(sciezka);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>), new XmlRootAttribute("Osoby") );

            serializer.Serialize(strumien, osoby);

            strumien.Close();

            Console.WriteLine($"Zapisano w {new FileInfo(sciezka).DirectoryName} zajętość w bajtach: {new FileInfo(sciezka).Length}");

            Console.WriteLine();

            Console.WriteLine(File.ReadAllText(sciezka));

            FileStream odczytxml = File.Open(sciezka, FileMode.Open);

            List<Osoba> odczytanexml = (List<Osoba>)serializer.Deserialize(odczytxml);

            foreach(Osoba item in odczytanexml)
                Console.WriteLine("Imię: {0} Nazwisko: {1} Ilość dzieci: {2}", item.Imie, item.Nazwisko, item.Dzieci.Count);

            odczytxml.Close();


            //Serializacja Json

            string sciezka2 = Path.Combine(Environment.CurrentDirectory, "osoby.json");

            StreamWriter stream2 = File.CreateText(sciezka2);

            JsonSerializer serializer1 = new JsonSerializer();

            serializer1.Serialize(stream2, osoby);

            stream2.Close();

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Plik {0} ma wielkość {1}", new FileInfo(sciezka2).Name, new FileInfo(sciezka2).Length);

            Console.WriteLine(File.ReadAllText(sciezka2));

        }
    }
}
