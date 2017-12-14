using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class TimesheetRepository
    {
        private static string connectionString =
  "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        public List<Timesheet> timesheets = new List<Timesheet>();
        public TimesheetRepository()
        {
            // Henter Employees fra DB og laver en liste
        }
        public Timesheet GetEmployeeTimesheet(int id)
        {
            Timesheet timesheet = null;
            for (int i = 0; i < timesheets.Count(); i++)
            {
                if (timesheets[i].EmployeeId == id)
                {
                    timesheet = timesheets[i];
                }
            }
            return timesheet;
        }
        public int GetTimesheetYear()
        {
            DateTime date = DateTime.Now;
            int timesheetYear = date.Year;
            return timesheetYear;

        }

        public int GetTimesheetMonth()
        {
            DateTime date = DateTime.Now;
            int timesheetMonth = date.Month;
            return timesheetMonth;
        }
        public Timesheet AddTimesheet(Employee employee)
        {
            Timesheet timesheet = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewTimesheet", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@TimeSheetMonth", GetTimesheetMonth()));
                    cmd1.Parameters.Add(new SqlParameter("@TimeSheetYear", GetTimesheetYear()));
                    cmd1.Parameters.Add(new SqlParameter("@EmployeeID", employee.EmployeeId));
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            int timesheetMonth = int.Parse(reader["TimeSheetMonth"].ToString());
                            int timesheetYear = int.Parse(reader["TimeSheetYear"].ToString());
                            int employeeId = int.Parse(reader["EmployeeID"].ToString());
                            int timesheetId = int.Parse(reader["TimeSheetID"].ToString());
                            timesheet = new Timesheet(timesheetId, timesheetYear, timesheetMonth, employeeId);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            return timesheet;
            


        }
    }
}
