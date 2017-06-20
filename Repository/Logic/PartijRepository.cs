using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Data;

namespace Repository.Logic
{
    public class PartijRepository
    {
        private IPartijSqlContext context;

        public PartijRepository(IPartijSqlContext context)
        {
            this.context = context;
        }

        public List<Partij> GetAll()
        {
            return context.GetAll();
        }

        public Partij GetById(int id)
        {
            return context.GetById(id);
        }

        public bool Update(Partij p)
        {
            return context.Update(p);
        }

        public bool Delete(Partij p)
        {
            return context.Delete(p);
        }
    }
}
