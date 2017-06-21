using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Data
{
    public interface IVerkiezingsuitslagSqlContext
    {
        List<Verkiezingsuitslag> GetAll();
        Verkiezingsuitslag GetById(int id);
        bool New(Verkiezingsuitslag s);
        bool Update(Verkiezingsuitslag s);
        List<Partij> GetParties(Verkiezingsuitslag u);
        void GetPartyElectionResults(Verkiezingsuitslag u);
    }
}
