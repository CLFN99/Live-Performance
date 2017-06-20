using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Data;

namespace Repository.Logic
{
    public class CoalitieRepository
    {
        private ICoalitieSqlContext context;

        public CoalitieRepository(ICoalitieSqlContext context)
        {
            this.context = context;
        }

        public List<Coalitie> GetAll()
        {
            return context.GetAll();
        }
        public Coalitie GetById(int id)
        {
            return context.GetById(id);
        }
        public bool NewCoalition(Coalitie c)
        {
            return context.NewCoalition(c);
        }
    }
}
