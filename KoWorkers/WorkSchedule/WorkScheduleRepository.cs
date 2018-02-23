using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers.WorkSchedule
{
    public class WorkScheduleRepository
    {
        private static WorkScheduleRepository instance = null;
        private List<WorkSchedule> workSchedules;
        private WorkScheduleRepository()
        {
            workSchedules = new List<WorkSchedule>();
        }
        public static WorkScheduleRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkScheduleRepository();
            }
            return instance;
        }
        public List<WorkSchedule> GetWorkSchedules()
        {
            return workSchedules;
        }
    }
}
