using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class TimesheetLogic
    {
        public int CalculateWorkHours(int employeeId, DateTime endDate)
        {
            int totalAmountOfMinutes = 0;
            ShiftRepository sr = ShiftRepository.GetInstance();
            List <Shift> shiftsSelectedMonth = sr.GetShifts(employeeId, endDate);
            foreach (Shift shift in shiftsSelectedMonth)
            {
                totalAmountOfMinutes += shift.TotalNumberOfMinutes;
                
            }
            return totalAmountOfMinutes;
        }
        
    }
}
