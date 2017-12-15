using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class ShiftRepository
    {
        private static string connectionString =
  "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        public List<Shift> shifts = new List<Shift>();

        public DateTime GetShiftDate()
        {
            DateTime time = DateTime.Now;
            DateTime shiftDate = time.Date;
            return shiftDate;
        }
        public DateTime GetTime()
        {  
            DateTime time = DateTime.Now;
            return time;
        }
        public int AddShift(int EmployeeID)
        {
            int shift = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewShift", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@ShiftDate", GetShiftDate()));
                    cmd1.Parameters.Add(new SqlParameter("@StartTime", GetTime()));
                    cmd1.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            shift = int.Parse(reader["ShiftID"].ToString());
                         
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            } return shift;
        }
    }
}
