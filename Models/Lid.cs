using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lid
    {
        public int Id;
        public string Naam;

        public Lid() { }

        public Lid(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public Lid(string naam)
        {
            Naam = naam;
        }
    }
}
