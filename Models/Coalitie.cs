using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coalitie
    {
        public int Id;
        public string Naam;
        public Lid Premier;
        public List<Partij> Partijen = new List<Partij>();

        public Coalitie() { }

        public Coalitie(int id, string naam, Lid premier, List<Partij> partijen)
        {

        }

        public Coalitie(string naam, Lid premier, List<Partij> partijen)
        {

        }

    }
}
