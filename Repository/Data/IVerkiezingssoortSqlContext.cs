﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Data
{
    public interface IVerkiezingssoortSqlContext
    {
        List<Verkiezingssoort> GetAll();
        Verkiezingssoort GetById(int id);
        List<Partij> GetParties(Verkiezingssoort soort);
        bool New(Verkiezingssoort s);
    }
}
