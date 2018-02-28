using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KoWorkers.WorkSchedule
{
    public class WorkScheduleShiftRepository
    {
        private static string connectionString =
    "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        private static WorkScheduleShiftRepository instance = null;
        private List<WorkScheduleShift> workShifts;
        private WorkScheduleShiftRepository()
        {
            workShifts = GetAllWorkShifts();
            ViewModel.WorkScheduleViewModel.GetInstance().PopulateViewModel(workShifts);
        }
        public static WorkScheduleShiftRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkScheduleShiftRepository();
            }
            return instance;
        }
        public List<WorkScheduleShift> GetAllWorkShifts()
        {
            return workShifts;
        }
        public void AddWorkShift(WorkScheduleShift newWorkSchedule)
        {
            workShifts.Add(newWorkSchedule);
        }
        public List<WorkScheduleShift> GetAllWorkScheduleShifts()
        {
            List<WorkScheduleShift> allShifts = new List<WorkScheduleShift>();
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
                            allShifts.Add(newShift);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            return allShifts;
        }
    }
}
