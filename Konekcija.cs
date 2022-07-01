using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Studentska_služba
{
    class Konekcija
    {
        public SqlConnection KreireajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-J0GGBS4\SQLEXPRESS",
                InitialCatalog = "Studentska sluzba",
                IntegratedSecurity = true


            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
