using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}
