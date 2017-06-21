using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Partij
    {
        public int Id, Stemmen, Percentage, NieuweZetels, LijsttrekkerId, Zetels;
        public string Afkorting, Naam;
        public List<Lid> Leden = new List<Lid>();

        public Partij() { }

        public Partij(int id, string afkorting, string naam, int zetels, int lijsttrekkerID)
        {
            Id = id;
            Afkorting = afkorting;
            Naam = naam;
            LijsttrekkerId = lijsttrekkerID;
            Zetels = zetels;
    }

        public Partij(string afkorting, string naam, int zetels, int lijsttrekkerID)
        {
            Afkorting = afkorting;
            Naam = naam;
            LijsttrekkerId = lijsttrekkerID;
            Zetels = zetels;
        }
    }
}
