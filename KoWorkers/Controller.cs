using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Controller
    {
        private EmployeeRepository employeeRepo;
        private TimesheetLogic timesheetLogic;
        private static Controller instance = null;
        public List<Employee> Employees { get; set; }
        public Employee CurrentEmployee { get; set; }
        private Controller()
        {
            employeeRepo = EmployeeRepository.GetInstance();
            timesheetLogic = new TimesheetLogic();
            Employees = employeeRepo.Employees;
            CurrentEmployee = Employees[0];
        }
        public static Controller GetInstance()
        {
            if (instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }
        public string AddEmployee(string firstName, string lastName, int pinCode, int telephoneNo)
        {
            Employee newEmployee = new Employee(firstName, lastName, pinCode, telephoneNo);
            return employeeRepo.AddEmployee(newEmployee);
        }
        public string RemoveEmployee(Employee removeEmployee)
        {
            return employeeRepo.RemoveEmployee(removeEmployee);
        }
        public string UpdateEmployee (Employee updateEmployee)
        {    
            return employeeRepo.UpdateEmployee(updateEmployee);
        }
        public string UpdateCheckInStatus(int pin)
        {
            string message = "";
            Employee employee = employeeRepo.GetEmployeeByPin(pin);
            ShiftRepository sr = ShiftRepository.GetInstance();
            int shiftID = -1;
            if (employee != null)
            {
                if (employee.OpenShift == -1)
                {
                    shiftID = sr.AddShift(employee);
                    message = employee.FullName + " blev tjekket ind.";
                }
                else
                { 
                    sr.EndShift(employee.OpenShift);
                    message = employee.FullName + " er tjekket ud.";
                }
                employee.OpenShift = shiftID;
            } else
            {
                message = "PIN-koden er forkert";
            }
            return message;
        }
        public int ShowSelectedEmployeeCalculatedHours(int idx,int month,int year)
        {
            //
            // hvad blev der af halve timer?
            //
            int totalHours = 0;
            List<Employee> list = Employees;
            int empID = list[idx].EmployeeId;
            if (month == -1 && year == -1)
            { month = 10;
                year = 2017;
            }
            DateTime dt = new DateTime(year, month, 10);
            totalHours = CalculateWorkHours(empID, dt)/60;
            return totalHours;
        }
        public int CalculateWorkHours(int employeeId, DateTime endDate)
        {
            int thisMonth = endDate.Month;
            int thisDay = endDate.Day;
            int thisYear = endDate.Year;
            // cutday 27. each month
            int cutday = 27;
            if (thisDay > cutday)
            {
                thisMonth += 1;
                if (thisMonth > 12)
                {
                    thisMonth -= 12;
                    thisYear += 1;
                }
            }
            thisDay = cutday;
            DateTime newEndDate = DateTime.Parse(thisDay + "-" + thisMonth + "-" + thisYear + " 23:59:59");

            int numberOfMinutes = timesheetLogic.CalculateWorkHours(employeeId, newEndDate);
            return numberOfMinutes;
        }

        public void AddNewScheduleToGui(int year, int month)
        {
            WorkSchedule.WorkSchedule workSchedule = new WorkSchedule.WorkSchedule(year, month); 
        }

    }
}
