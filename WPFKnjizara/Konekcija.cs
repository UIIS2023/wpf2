using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjizara
{
    public class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-KB1SV26\SQLEXPRESS", //naziv servera na kom je baza podataka smestena
                InitialCatalog = "Knjizara2",    // naziv baze
                IntegratedSecurity = true   // true ukoliko se baza nalazi na lokalnoj masini
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        } 
    }
} 