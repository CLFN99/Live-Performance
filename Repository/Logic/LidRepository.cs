using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Data;

namespace Repository.Logic
{
    public class LidRepository
    {
        private ILidSqlContext context;

        public LidRepository(ILidSqlContext context)
        {
            this.context = context;
        }

        public List<Lid> GetAll()
        {
            return context.GetAll();
        }

        public Lid GetById(int id)
        {
            return context.GetById(id);
        }

        public bool NewMember(Lid l)
        {
            return context.NewMember(l);
        }

        public bool DeleteMember(Lid l)
        {
            return context.DeleteMember(l);
        }
    }
}
