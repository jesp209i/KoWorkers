using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        private int _totalNumberOfMinutes;

        public int TotalNumberOfMinutes
        { get {
                _totalNumberOfMinutes = 0;
                if (EndTime != null && EndTime > StartTime)
                {
                    TimeSpan shiftTimespan = EndTime.Subtract(StartTime);

                    _totalNumberOfMinutes = (int)shiftTimespan.TotalMinutes;
                    
                    // beregning af halve timer skal forbedres
                    //
                    //if (_totalNumberOfMinutes % 30 < 0.5){
                    //    _totalNumberOfMinutes -= _totalNumberOfMinutes % 30;
                    //} else {
                    //    _totalNumberOfMinutes += 30-(_totalNumberOfMinutes % 30);
                    //}

                }
                    return _totalNumberOfMinutes;
            } }

        public Shift (Employee newEmployee, DateTime newStartTime)
        {
            Employee = newEmployee;
            StartTime = newStartTime;
        }
        public Shift(int newshiftID, Employee newEmployee, DateTime newStartTime, DateTime newEndTime)
        {
            ShiftID = newshiftID;
            Employee = newEmployee;
            StartTime = newStartTime;
            EndTime = newEndTime;
        }
    }
}
