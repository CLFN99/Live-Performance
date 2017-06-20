using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Data
{
    public interface IPartijSqlContext
    {
        List<Partij> GetAll();
        Partij GetById(int id);
        bool Update(Partij p);
        bool Delete(Partij p);

    }
}
