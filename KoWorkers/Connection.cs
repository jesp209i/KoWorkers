using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KoWorkers
{
    public class Connection
    {
        private static string connectionstring =
            "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";

        public void Run()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewEmployee", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@LastName", "Larsen"));
                    cmd1.Parameters.Add(new SqlParameter("@FirstName", "Lars"));

                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("SpEmployee", con);
                    cmd2.CommandType = CommandType.StoredProcedure;


                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string EmployeeID = reader["EmployeeID"].ToString();
                            string LastName = reader["LastName"].ToString();
                            string FirstName = reader["FirstName"].ToString();
                            Console.WriteLine(EmployeeID + " " + LastName + " " + FirstName);
                        }

                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
        }
    }

}


