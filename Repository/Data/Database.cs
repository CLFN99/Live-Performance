﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repository.Data
{
    public static class Database
    {
        private static string connectionString = "Server=mssql.fhict.local;Database=dbi365425; User Id = dbi365425; Password=lp2017;";
        public static SqlConnection Conn = new SqlConnection(connectionString);
        
    }
}
