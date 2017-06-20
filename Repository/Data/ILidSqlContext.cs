using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Data
{
    public interface ILidSqlContext
    {
        List<Lid> GetAll();
        Lid GetById(int id);
        bool NewMember(Lid l);
        bool DeleteMember(Lid l);
    }
}
