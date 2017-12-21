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
        private Controller()
        {
            employeeRepo = new EmployeeRepository();
            timesheetLogic = new TimesheetLogic();
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
        public string CheckInOrOutByPin(int pin)
        {
            string message = "";
            Employee employee = employeeRepo.GetEmployeeByPin(pin);
            ShiftRepository sr = new ShiftRepository();
            int shiftID = -1;
            if (employee != null)
            {
                if (employee.OpenShift == -1)
                {
                    shiftID = sr.AddShift(employee.EmployeeId);
                    message = employee.FullName + " blev tjekket ud.";
                }
                else
                { 
                    sr.EndShift(employee.OpenShift);
                    message = employee.FullName + " er tjekket ind.";
                }
                employee.OpenShift = shiftID;
            } else
            {
                message = "PIN-koden er forkert";
            }
            return message;
        }
        public void UpdateEmployeeToGuiFirstName(int idx, string firstName, string lastName, int telephoneNo, int pinCode)
        {
            List<Employee> list = GetAllEmployees();
            list[idx].FirstName = firstName;
            list[idx].LastName = lastName;
            list[idx].TelephoneNo = telephoneNo;
            list[idx].PinCode = pinCode;
            UpdateEmployee(list[idx]);
        }


        public string ShowSelectedEmployeePinCode(int idx)
        {
            string pinCode = "";
            List<Employee> list = GetAllEmployees();
            pinCode = list[idx].PinCode.ToString();
            return pinCode;
        }
        public void RemoveEmployeeToGui(int idx)
        {
            List<Employee> list = GetAllEmployees();
            RemoveEmployee(list[idx]);  
        }
        public string ShowSelectedEmployeeTelephoneNO(int idx)
        {
            string telephoneNO = "";
            List<Employee> list = GetAllEmployees();
            telephoneNO = list[idx].TelephoneNo.ToString();
            return telephoneNO;
        }

        public int ShowSelectedEmployeeCalculatedHours(int idx,int month,int year)
        {
            //
            // hvad blev der af halve timer?
            //
            int totalHours = 0;
            List<Employee> list = GetAllEmployees();
            int empID = list[idx].EmployeeId;
            if (month == -1 && year == -1)
            { month = 10;
                year = 2017;
            }
            DateTime dt = new DateTime(year, month, 10);
            totalHours = CalculateWorkHours(empID, dt)/60;
            return totalHours;
        }

        public string ShowSelectedEmployeeLastName(int idx)
        {
            string lastName = "";
            List<Employee> list = GetAllEmployees();
            lastName = list[idx].LastName;
            return lastName;
        }

        public string ShowSelectedEmployeeFirstName(int idx)
        {
            string firstName = "";
           List<Employee> list = GetAllEmployees();
            firstName = list[idx].FirstName;
            return firstName;
        }

        public List<Employee> GetAllEmployees()
        {
                return employeeRepo.GetEmployees();
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

            int numberOfMinutes = TimesheetLogic.GetInstance().CalculateWorkHours(employeeId, newEndDate);
            return numberOfMinutes;
        }

    }
}
