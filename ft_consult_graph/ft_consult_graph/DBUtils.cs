using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ft_consult.connection
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"MAIN-WORK";

            string database = "solving_test";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }

}