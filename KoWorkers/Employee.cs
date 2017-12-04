using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string newFirstName, string newLastName)
        {
            FirstName = newFirstName;
            LastName = newLastName;

        }
        public Employee(int employeeId, string newFirstName, string newLastName)
        {
            EmployeeId = employeeId;
            FirstName = newFirstName;
            LastName = newLastName;

        }
        public string GetName()
        {
            return FirstName + " " + LastName;
        }
        public void SetName(string setFirstName, string setLastName)
        {
            FirstName = setFirstName;
            LastName = setLastName;

        }
    }
}
