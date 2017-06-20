using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Verkiezingssoort
    {
        public int Id, Zetels;
        public string Naam;
        public List<Partij> Partijen = new List<Partij>();

        public Verkiezingssoort() { }

        public Verkiezingssoort(int id, string naam, int zetels, List<Partij> partijen)
        {
            Id = id;
            Zetels = zetels;
            Naam = naam;
            Partijen = partijen;
        }

        public Verkiezingssoort(string naam, int zetels, List<Partij> partijen)
        {
            Zetels = zetels;
            Naam = naam;
            Partijen = partijen;
        }
    }
}
