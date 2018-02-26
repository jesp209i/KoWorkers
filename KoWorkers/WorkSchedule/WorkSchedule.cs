using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers.WorkSchedule
{
    public class WorkSchedule
    {
        public int Year { get; set; }
        public int Month { get; set; }
        private List<WorkScheduleShift> shifts;
        public WorkSchedule(int year, int month)
        {
            Year = year;
            Month = month;
            shifts = new List<WorkScheduleShift>();
        }
        public List<WorkScheduleShift> GetAllShifts()
        {
            return shifts;
        }
        public void AddShiftToSchedule(WorkScheduleShift shift)
        {
            shifts.Add(shift);
        }
    }
}
