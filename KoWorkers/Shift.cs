using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Shift
    {
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Shift (int newEmployeeID, DateTime newShiftDate, DateTime newStartTime, DateTime newEndTime)
        {
            EmployeeID = newEmployeeID;
            ShiftDate = newShiftDate;
            StartTime = newStartTime;
            EndTime = newEndTime;
        }
    }
}
