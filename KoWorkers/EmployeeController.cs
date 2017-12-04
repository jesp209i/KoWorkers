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
    }
}
