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

       public Timesheet(int newTimesheetID, int newTimesheetYear, int newTimesheetMonth, int newEmployeeId)
        {
            TimesheetID = newTimesheetID;
            TimesheetYear = newTimesheetYear;
            TimesheetMonth = newTimesheetMonth;
            EmployeeId = newEmployeeId;
            
        }
    }
}
