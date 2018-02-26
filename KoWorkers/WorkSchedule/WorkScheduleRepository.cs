using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KoWorkers.WorkSchedule
{
    public class WorkScheduleRepository
    {
        private static string connectionString =
  "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        private static WorkScheduleRepository instance = null;
        private List<WorkSchedule> workSchedules;
        private WorkScheduleRepository()
        {
            workSchedules = new List<WorkSchedule>();
            GetAllWorkScheduleShifts();
        }
        public static WorkScheduleRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkScheduleRepository();
            }
            return instance;
        }
        public List<WorkSchedule> GetAllWorkSchedules()
        {
            return workSchedules;
        }
        public WorkSchedule GetSchedule(int workYear, int workMonth)
        {
            WorkSchedule workSchedule = null;
            int i = 0;
            bool running = true;
            do
            {
                if (i < workSchedules.Count)
                {
                    if (workSchedules[i].Year == workYear && workSchedules[i].Month == workMonth)
                    {
                        workSchedule = workSchedules[i];
                        running = false;
                    }
                    i++;
                } else
                {
                    running = false;
                }

            } while (running);
            return workSchedule;
        }
        public void AddWorkSchedule(WorkSchedule newWorkSchedule)
        {
            workSchedules.Add(newWorkSchedule);
        }
        public void GetAllWorkScheduleShifts()
        {
            List<WorkScheduleShift> listOfAllShifts = new List<WorkScheduleShift>();
            workSchedules.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand allShiftsFromDB = new SqlCommand("Sp_GetWorkScheduleShifts", con);
                    allShiftsFromDB.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = allShiftsFromDB.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int shiftId = int.Parse(reader["ShiftID"].ToString());
                            int employeeId = int.Parse(reader["EmployeeID"].ToString());
                            DateTime startTime = Convert.ToDateTime(reader["StartTime"]);
                            DateTime endTime = Convert.ToDateTime(reader["EndTime"]);
                            Employee employeeToShift = EmployeeRepository.GetInstance().GetEmployeeById(employeeId);
                            WorkScheduleShift newShift = new WorkScheduleShift(shiftId, employeeToShift, startTime, endTime);
                            listOfAllShifts.Add(newShift);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            foreach (WorkScheduleShift wss in listOfAllShifts)
            {
                int shiftYear = int.Parse(wss.StartTime.ToString("yyyy"));
                int shiftMonth = int.Parse(wss.StartTime.ToString("M"));
                WorkSchedule workSchedule = this.GetSchedule(shiftYear, shiftMonth);
                if (workSchedule == null)
                {
                    workSchedule = new WorkSchedule(shiftYear, shiftMonth);
                    AddWorkSchedule(workSchedule);
                }
                workSchedule.AddShiftToSchedule(wss);
            }
        }
    }
}
