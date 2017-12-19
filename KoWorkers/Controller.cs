using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Controller
    {
        public EmployeeRepository employeeRepo;
      
        public Controller()
        {
            employeeRepo = new EmployeeRepository();
        }

        public string AddEmployee(string firstName, string lastName, int pinCode, int telephoneNo)
        {
            Employee newEmployee = new Employee(firstName, lastName, pinCode, telephoneNo);
            return employeeRepo.AddEmployee(newEmployee);
        }
        public Employee GetEmployee(int employeeId)
        {
            return employeeRepo.GetEmployeeFromList(employeeId);
        }
        public string RemoveEmployee(Employee removeEmployee)
        {
            return employeeRepo.RemoveEmployee(removeEmployee);
        }
        public string UpdateEmployee (Employee updateEmployee)
        {
            return employeeRepo.UpdateEmployee(updateEmployee);
        }

        public Employee CheckInByPin(int pin)
        {
            Employee employee = employeeRepo.GetEmployeeByPin(pin);
            ShiftRepository sr = ShiftRepository.GetInstance();
            int shiftID = -1;
            if (employee != null)
            {
                if (employee.OpenShift == -1)
                {
                    shiftID = sr.AddShift(employee.EmployeeId);
                }
                else
                { 
                    sr.EndShift(employee.OpenShift);
                }
                employee.OpenShift = shiftID;
            }
            return employee;
        }

        public void RemoveEmployeeToGui(int idx)
        {
            List<Employee> list = new List<Employee>();
            {
                foreach (Employee employee in employeeRepo.employees)
                { 
                        list.Add(employee);       
                }
            }
            RemoveEmployee(list[idx]);  
        }
        public string ShowSelectedEmployeeTelephoneNO(int idx)
        {
            string telephoneNO = "";
            List<Employee> list = GetAllEmployees();
            telephoneNO = list[idx].TelephoneNo.ToString();
            return telephoneNO;
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
                return employeeRepo.employees;
        }
   
        public string ShowCheckInOutMessageInGui(int pin)
        {
            string message = "";
            Employee employee = CheckInByPin(pin);
            if (employee.OpenShift == -1)
            {
                message = employee.FullName + " blev tjekket ud.";
            }
            if (employee.OpenShift > -1)
            {
                message = employee.FullName + " er tjekket ind.";
            }
            if (employee == null)
            {
                message = "PIN-koden er forkert";
            }
            return message;
        }
        public int CalculateWorkHours(int employeeId, DateTime endDate)
        {
            /*
             Til Lars!
             Det er denne metode du skal gå ud fra.
             Den returnerer det samlede antal minutter der er arbejdet en måned tilbage fra skæringsdato d. 27 hver måned.
             Metoden er fleksibel, så du skal bare give den et "tilfældigt" valid DateTime, så finder den selv ud af hvilken måned.

            EmployeeId 45 , Jesper Madsen har Pinkode 9998 og har været flittig på arbejde 7 dage hver måned siden september :)
             
             */

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
