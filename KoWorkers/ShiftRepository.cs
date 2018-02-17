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
        private static ShiftRepository instance = null;
        public static ShiftRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ShiftRepository();
            }
            return instance;
        }
        private ShiftRepository() 
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
                            Employee employeeToShift = EmployeeRepository.GetInstance().GetEmployeeById(employeeId);
                            Shift newShift = new Shift(shiftId, employeeToShift, startTime, endTime);
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
                if(shift.Employee.EmployeeId == employeeId && shift.StartTime <= endDate && shift.StartTime > beginDate)
                {
                    employeeShiftsForPeriod.Add(shift);
                }
            }
            return employeeShiftsForPeriod;
        }

        public void EndShift(int shiftID)
        {
            Shift endShift = GetShiftById(shiftID);
            endShift.EndTime = GetNow();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpEndShift", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@ShiftID", endShift.ShiftID));
                    cmd1.Parameters.Add(new SqlParameter("@EndTime", endShift.EndTime));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllShifts();
        }

        private Shift GetShiftById(int shiftID)
        {
            Shift thisShift = null;
            int i = 0;
            do
            {
                thisShift = shifts[i];
                i++;
            } while (shifts[i].ShiftID != shiftID);
            return thisShift;
        }

        public int AddShift(Employee employee)
        {
            int shift = -1;
            Shift newShift = new Shift(employee, GetNow());
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewShift", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@StartTime", newShift.StartTime));
                    cmd1.Parameters.Add(new SqlParameter("@EmployeeID", newShift.Employee.EmployeeId));
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            shift = int.Parse(reader["ShiftID"].ToString());                            
                        }
                    }
                }
                catch (SqlException e) {
                    Console.WriteLine("Muuuuligvis en fejl\n" + e.Message);
                }
            } 
            FetchAllShifts();
            return shift;
        }
    }
}
