using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    class MyConnection
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection() { ConnectionString = "server=(local); database=dropdown1;Integrated Security = true" };
        }
    }
}
