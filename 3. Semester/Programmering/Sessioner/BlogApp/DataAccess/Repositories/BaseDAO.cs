using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DataAccess.Repositories
{
   public abstract class BaseDAO

    {
        private readonly string _connectionstring;

        protected BaseDAO(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionstring);
        }
    }
}