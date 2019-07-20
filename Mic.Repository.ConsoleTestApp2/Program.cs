using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mic.Repository.ConsoleTestApp2
{
    class Program
    {
        const string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AnyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            string sql =
                "INSERT INTO universities (Name) VALUES (@Name); "
                   + "SELECT CAST(scope_identity() AS int)";

            using (var con = new SqlConnection(conStr))
            {
                SqlTransaction transaction = null;

                try
                {
                    con.Open();

                    transaction = con.BeginTransaction();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Transaction = transaction;

                        var pname = new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 100);
                        pname.Value = "Test University 111";

                        cmd.Parameters.Add(pname);

                        object obj = cmd.ExecuteScalar();
                        //int count = cmd.ExecuteNonQuery();

                        transaction.Rollback();
                        //transaction.Commit();
                    }
                }
                catch(Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();
                }
            }
        }
    }
}
