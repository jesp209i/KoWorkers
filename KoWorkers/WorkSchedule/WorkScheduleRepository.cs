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
