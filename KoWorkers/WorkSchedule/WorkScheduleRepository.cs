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
        
    }
}
