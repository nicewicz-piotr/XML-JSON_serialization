using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PracaZSerializacja
{
    
    public class Osoba
    {
        [XmlAttribute("imie")]
        public string Imie { get; set;}

        [XmlAttribute("nazwisko")]
        public string Nazwisko { get; set;}

        [XmlAttribute("data_urodzenia")]
        public DateTime DataUrodzenia { get; set;}
        
        public HashSet<Osoba> Dzieci;
        protected decimal Pensja {get; set;}

        public Osoba()
        {

        }
        public Osoba(decimal pensjaPoczatkowa)
        {
            this.Pensja = pensjaPoczatkowa;
        }

    }
}
