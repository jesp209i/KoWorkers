using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace KoWorkers.WorkSchedule
{
    public class WorkScheduleShift : Shift
    {
        public int WeekNumber {
            get {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                return cal.GetWeekOfYear(StartTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            }
        }
        public int Year {
            get { return StartTime.Year; }
        }
        public int Month { get; set; }
        public WorkScheduleShift(Employee employee, DateTime startTime, DateTime endTime)
            : base(employee, startTime)
        {
            EndTime = endTime;
        }
        public WorkScheduleShift(int shiftId,Employee employee, DateTime startTime, DateTime endTime)
            : base(shiftId, employee, startTime, endTime)
        { }
        public override string ToString()
        {
            return StartTime.ToString("hh:mm:ss") + " - " + EndTime.ToString("hh:mm:ss");
        }
    }
}
