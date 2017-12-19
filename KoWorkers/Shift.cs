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
        private int _totalNumberOfMinutes;

        public int TotalNumberOfMinutes
        { get {
                _totalNumberOfMinutes = 0;
                if (EndTime != null && EndTime > StartTime)
                {
                    TimeSpan shiftTimespan = EndTime.Subtract(StartTime);
                    _totalNumberOfMinutes = shiftTimespan.Minutes;
                    if (_totalNumberOfMinutes % 30 < 0.5){
                        _totalNumberOfMinutes -= _totalNumberOfMinutes % 30;
                    } else {
                        _totalNumberOfMinutes += 30-(_totalNumberOfMinutes % 30);
                    }

                }
                    return _totalNumberOfMinutes;
            } }

        public Shift (int newEmployeeID, DateTime newShiftDate, DateTime newStartTime, DateTime newEndTime)
        {
            EmployeeID = newEmployeeID;
            ShiftDate = newShiftDate;
            StartTime = newStartTime;
            EndTime = newEndTime;
        }
    }
}
