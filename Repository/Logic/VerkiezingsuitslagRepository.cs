using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Data;

namespace Repository.Logic
{
    public class VerkiezingsuitslagRepository
    {
        private IVerkiezingsuitslagSqlContext context;

        public VerkiezingsuitslagRepository(IVerkiezingsuitslagSqlContext context)
        {
            this.context = context;
        }

        public List<Verkiezingsuitslag> GetAll()
        {
            return context.GetAll();
        }

        public Verkiezingsuitslag GetById(int id)
        {
            return context.GetById(id);
        }
        public bool New(Verkiezingsuitslag s)
        {
            return context.New(s);
        }
        public bool Update(Verkiezingsuitslag s)
        {
            return context.Update(s);
        }

        public void GetPartyElectionResults(Verkiezingsuitslag u)
        {
           context.GetPartyElectionResults(u);
        }
    }
}
