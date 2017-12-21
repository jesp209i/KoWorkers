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
        private List<Shift> shifts = new List<Shift>();

        public ShiftRepository() 
        {
            FetchAllShifts();
        }
        private void FetchAllShifts()
        {
            shifts.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand allShiftsFromDB = new SqlCommand("SpGetAllShifts", con);
                    allShiftsFromDB.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    SqlDataReader reader = allShiftsFromDB.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int shiftId = int.Parse(reader["ShiftID"].ToString());
                            int employeeId = int.Parse(reader["EmployeeID"].ToString());
                            DateTime startTime =Convert.ToDateTime(reader["StartTime"]);
                            DateTime endTime;
                            if (!DateTime.TryParse(reader["EndTime"].ToString(), out endTime)){
                                endTime = startTime.AddYears(100);
                            }
                            Shift newShift = new Shift(shiftId, employeeId, startTime, endTime);
                            shifts.Add(newShift);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
        }
        private DateTime GetNow()
        {
            return DateTime.Now;
        }
        public List<Shift> GetShifts(int employeeId,DateTime endDate)
        {
            DateTime beginDate = endDate.AddMonths(-1);
            List<Shift> employeeShiftsForPeriod = new List<Shift>();
            foreach (Shift shift in shifts)
            {
                if(shift.EmployeeID == employeeId && shift.StartTime <= endDate && shift.StartTime > beginDate)
                {
                    employeeShiftsForPeriod.Add(shift);
                }
            }
            return employeeShiftsForPeriod;
        }

        public void EndShift(int shiftID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpEndShift", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@ShiftID", shiftID));
                    cmd1.Parameters.Add(new SqlParameter("@EndTime", GetNow()));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllShifts();
        }   
        
        public int AddShift(int employeeID)
        {
            int shift = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewShift", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@StartTime", GetNow()));
                    cmd1.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
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
            } 
            FetchAllShifts();
            return shift;
        }
    }
}
