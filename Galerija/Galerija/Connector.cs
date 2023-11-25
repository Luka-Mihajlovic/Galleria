using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Galerija
{
    internal class Connector
    {
        public static SqlConnection connectPlease()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=Projketni;Integrated Security=True");
            return conn;
        }
    }
}
