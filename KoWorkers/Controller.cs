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
        public TimesheetRepository timesheetRepo;
        public Controller()
        {
            employeeRepo = new EmployeeRepository();
            timesheetRepo = new TimesheetRepository();
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
            Timesheet timesheet = null;
            if (employee != null && employee.IsChekedIn() == false)
            {
                timesheetRepo.GetEmployeeTimesheet(employee.EmployeeId);
                if (timesheetRepo.GetEmployeeTimesheet(employee.EmployeeId) == null)
                {
                    timesheet = timesheetRepo.AddTimesheet(employee);
                }
            }
            return employee;
            
            
            
        }
        
       

    }
}
