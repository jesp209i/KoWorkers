using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Timesheet
    {
        public int TimesheetID { get; set; }
        public int TimesheetYear { get; set; }
        public int TimesheetMonth { get; set; }
        public int EmployeeId { get; set; }
        public List<Shift> shifts = new List<Shift>();

        public int getTimesheetYear()
        {
            DateTime date = DateTime.Now;
            TimesheetYear = int.Parse(date.Year.ToString());
            return TimesheetYear;

        }

        public int getTimesheetMonth()
        {
            DateTime date = DateTime.Now;
            TimesheetMonth = int.Parse(date.Month.ToString());
            return TimesheetMonth;
        }
    }
}
