using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lid
    {
        public int Id, PartijId;
        public string Naam;

        public Lid() { }

        public Lid(int id, string naam, int partijid)
        {
            Id = id;
            Naam = naam;
            PartijId = partijid;
        }

        public Lid(string naam, int partijid)
        {
            Naam = naam;
            PartijId = partijid;
        }
    }
}
