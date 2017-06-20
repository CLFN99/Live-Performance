using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Partij
    {
        public int Id, Stemmen, Percentage, NieuweZetels;
        public string Afkorting, Naam;
        public List<Lid> Leden = new List<Lid>();

        public Partij() { }

        public Partij(int id, string afkorting, string naam, int lijsttrekkerID, List<Lid> leden)
        {

        }

        public Partij(string afkorting, string naam, int lijsttrekkerID, List<Lid> leden)
        {
           
        }
    }
}
