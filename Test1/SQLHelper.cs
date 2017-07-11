using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public static class SQLHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd1 = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd1.Parameters.AddRange(pms);
                    }
                    con.Open();
                    int r = (int)cmd1.ExecuteScalar();
                    return r;
                }
            }
        }
    }
}
