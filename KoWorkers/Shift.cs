using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Shift
    {
        public int TimeSheetID { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}
