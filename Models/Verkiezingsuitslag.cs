﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Verkiezingsuitslag
    {
        public int Id, Totaal;
        public string Naam;
        public DateTime Datum;
        public Verkiezingssoort Soort;
        public List<Partij> Partijen = new List<Partij>();

        public Verkiezingsuitslag() { }
        public Verkiezingsuitslag(int id, string naam, DateTime datum, Verkiezingssoort soort)
        {
            Id = id;
            Naam = naam;
            Datum = datum;
            Soort = soort;
        }

        public Verkiezingsuitslag(string naam, DateTime datum, Verkiezingssoort soort)
        {
            Naam = naam;
            Datum = datum;
            Soort = soort;
        }

        public void ZetelsEnPercentageBerekenen()
        {
            foreach(Partij p in Partijen)
            {
                p.NieuweZetels = (p.Stemmen / Totaal) * Soort.Zetels;
                p.Percentage = (p.NieuweZetels / Soort.Zetels) * 100;
            }
        }
    }
}
