using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class EmployeeController
    {
        public EmployeeRepository employeeRepo;
        public TimesheetRepository timesheetRepo;
        public EmployeeController()
        {
            employeeRepo = new EmployeeRepository();
            timesheetRepo = new TimesheetRepository();
        }

        public void AddEmployee(string firstName, string lastName, int pinCode, int telephoneNo)
        {
            Employee newEmployee = new Employee(firstName, lastName, pinCode, telephoneNo);
            employeeRepo.AddEmployee(newEmployee);
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
            
            return employeeRepo.GetEmployeeByPin(pin);  
            
        }
        
        public Timesheet GetEmployeeTimesheet(int employeeId)
        {
            return timesheetRepo.GetEmployeeTimesheet(employeeId);
        }
    }
}
