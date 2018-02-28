using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class SortTest
    {
        ShiftRepository sr;
        public SortTest()
        {
            sr = ShiftRepository.GetInstance();
            datoer = sr.GetShifts();
            
        }

        public List<Shift> datoer = new List<Shift>();
        public List<DateTime> dtt = new List<DateTime>();

       public List<DateTime> monday = new List<DateTime>();
       public List<DateTime> tuesday = new List<DateTime>();
        List<DateTime> wednesday = new List<DateTime>();
        List<DateTime> thursday = new List<DateTime>();
        List<DateTime> friday = new List<DateTime>();
        List<DateTime> saturday = new List<DateTime>();
        List<DateTime> sunday = new List<DateTime>();

        public void Sort()
        {
            int jan = datoer.Count;
            
            foreach (Shift shift in datoer)
            {
                dtt.Add(shift.StartTime);
            }
            

            foreach (DateTime datet in dtt)
            {
                if (datet.DayOfWeek == DayOfWeek.Monday)
                {
                    monday.Add(datet);
                }
                if (datet.DayOfWeek == DayOfWeek.Tuesday)
                {
                    tuesday.Add(datet);
                }
                if (datet.DayOfWeek == DayOfWeek.Wednesday)
                {
                    wednesday.Add(datet);
                }
                if (datet.DayOfWeek == DayOfWeek.Thursday)
                {
                    thursday.Add(datet);
                }

                if (datet.DayOfWeek == DayOfWeek.Friday)
                {
                    friday.Add(datet);
                }

                if (datet.DayOfWeek == DayOfWeek.Saturday)
                {
                    saturday.Add(datet);
                }
                if (datet.DayOfWeek == DayOfWeek.Sunday)
                {
                    sunday.Add(datet);
                }


            }
        }
    }
}
