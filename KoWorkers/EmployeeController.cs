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
        public EmployeeController()
        {
            employeeRepo = new EmployeeRepository();
        }

        public void AddEmployee(string firstName, string lastName)
        {
            Employee newEmployee = new Employee(firstName, lastName);
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
    }
}
