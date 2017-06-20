using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Coalitie
    {
        public int Id, PremierId;
        public string Naam;
        public List<Partij> Partijen = new List<Partij>();

        public Coalitie() { }

        public Coalitie(int id, string naam, int premier, List<Partij> partijen)
        {
            Id = id;
            Naam = naam;
            PremierId = premier;
            Partijen = partijen;
        }

        public Coalitie(string naam, int premier, List<Partij> partijen)
        {
            Naam = naam;
            PremierId = premier;
            Partijen = partijen;
        }

        public void BepaalPremier()
        {
            var descendingOrder = Partijen.OrderByDescending(i => i);
            PremierId = Partijen[0].LijsttrekkerId;
        }
    }
}
