using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers.WorkSchedule
{
    public class WorkScheduleViewModel
    {
        private class WorkScheduleShiftViewModel
        {
            public int WeekNumber { get; set; }
            public String FullName { get; set; }
            public String Monday { get; set; }
            public String Tuesday { get; set; }
            public String Wednesday { get; set; }
            public String Thursday { get; set; }
            public String Friday { get; set; }
            public String Saturday { get; set; }
            public String Sunday { get; set; }
        }
        private List<WorkScheduleShiftViewModel> listForViewModel = new List<WorkScheduleShiftViewModel>();
    }
}
