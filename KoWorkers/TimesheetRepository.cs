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
        public void AddTimesheet(Timesheet newTimesheet)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewTimesheet", con);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@TimeSheetMonth", newTimesheet.TimesheetMonth));
                    cmd1.Parameters.Add(new SqlParameter("@TimeSheetYear", newTimesheet.TimesheetYear));
                    cmd1.Parameters.Add(new SqlParameter("@EmployeeID", newTimesheet.EmployeeId));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
           
        }
    }
}
