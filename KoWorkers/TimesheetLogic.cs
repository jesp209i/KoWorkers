using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class TimesheetLogic
    {
        private static TimesheetLogic instance = null;
        public static TimesheetLogic GetInstance()
        {
            if (instance == null)
            {
                instance = new TimesheetLogic();
            }
            return instance;
        }
        public int CalculateWorkHours(int employeeId, DateTime endDate)
        {
            int totalAmountOfMinutes = 0;
            List <Shift> shiftsSelectedMonth = ShiftRepository.GetInstance().GetShifts(employeeId, endDate);
            foreach (Shift shift in shiftsSelectedMonth)
            {
                totalAmountOfMinutes += shift.TotalNumberOfMinutes;
            }
            return totalAmountOfMinutes;
        }
    }
}
