using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers.WorkSchedule.ViewModel
{
    public class WorkScheduleViewModel
    {
        private static WorkScheduleViewModel instance = null;
        private WorkScheduleViewModel()
        {
            ListForViewModel = new List<WorkScheduleShiftViewModel>();
        }

        public class WorkScheduleShiftViewModel
        {
            public WorkScheduleShiftViewModel(Employee employee, int weekNumber, int year)
            {
                wssEmployee = employee;
                WeekNumber = weekNumber;
                Year = year;
            }
            public int WeekNumber { get; set; }
            public int Year { get; set; }
            private List<WorkScheduleShift> weekShifts = new List<WorkScheduleShift>();
            private Employee wssEmployee;
            public String EmployeeName { get { return wssEmployee.FullName; } }
            public String Monday { get {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Monday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Tuesday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Tuesday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Wednesday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Thursday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Thursday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Friday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Friday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Saturday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Saturday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public String Sunday
            {
                get
                {
                    string shiftstring = "";
                    foreach (WorkScheduleShift current in weekShifts)
                    {
                        if (current.StartTime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (shiftstring != "")
                            {
                                shiftstring += "\n";
                            }
                            shiftstring += current.ToString(); ;
                        }
                    }
                    return shiftstring;
                }
            }
            public double WeekHours { get {
                    int minutes = 0;
                    foreach(WorkScheduleShift current in weekShifts)
                    {
                        minutes = current.TotalNumberOfMinutes;
                    }
                    return minutes / 60;
                }
            }
            public void AddShift(WorkScheduleShift shift)
            {
                weekShifts.Add(shift);
            }
        }
        public List<WorkScheduleShiftViewModel> ListForViewModel { get; set; }
        public static WorkScheduleViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkScheduleViewModel();
            }
            return instance;
        }
        public void PopulateViewModel(List<WorkScheduleShift> listOfAllShifts)
        {
            foreach (WorkScheduleShift shift in listOfAllShifts)
            {
                WorkScheduleShiftViewModel wssvm = GetWssVM(shift.Employee, shift.WeekNumber, shift.Year);
                if (wssvm == null)
                {
                    wssvm = new WorkScheduleShiftViewModel(shift.Employee, shift.WeekNumber, shift.Year);
                    ListForViewModel.Add(wssvm);
                }
                wssvm.AddShift(shift);
            }
        }
        private WorkScheduleShiftViewModel GetWssVM(Employee employee, int weekNumber, int year)
        {
            WorkScheduleShiftViewModel hest = null;
            foreach (WorkScheduleShiftViewModel wssvm in ListForViewModel)
            {
                if (wssvm.EmployeeName == employee.FullName && wssvm.WeekNumber == weekNumber && wssvm.Year == year)
                {
                    hest = wssvm;
                }
            }
            return hest;
        }
    }
}
