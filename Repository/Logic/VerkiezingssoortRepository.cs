using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Data;

namespace Repository.Logic
{
    public class VerkiezingssoortRepository
    {
        private IVerkiezingssoortSqlContext context;

        public VerkiezingssoortRepository(IVerkiezingssoortSqlContext context)
        {
            this.context = context;
        }

        public List<Verkiezingssoort> GetAll()
        {
            return context.GetAll();
        }
        public Verkiezingssoort GetById(int id)
        {
            return context.GetById(id);
        }
        public bool New(Verkiezingssoort s)
        {
            return context.New(s);
        }
    }
}
