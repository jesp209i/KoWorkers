using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class ShiftRepository
    {
        private static string connectionString =
  "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        public List<Shift> shifts = new List<Shift>();

        public DateTime GetShiftDate()
        {
            DateTime time = DateTime.Now;
            DateTime shiftDate = time.Date;
            return shiftDate;
        }
        public DateTime GetStartTime()
        {
            DateTime time = DateTime.Now;
            DateTime startTime = new DateTime(time.Hour, time.Minute, time.Second);
            return startTime;
        }
        //public Shift AddShift()
        //{

        //}
    }
}
