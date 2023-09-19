using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"olap-server";

            string database = "DevSandBox";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }

}