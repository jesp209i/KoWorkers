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
                if (employee.GetOpenShift() == -1)
                {
                    shiftID = sr.AddShift(employee.EmployeeId);
                }
                else
                { 
                    sr.EndShift(employee.GetOpenShift());
                }  
            }
            employee.SetOpenShift(shiftID);

            return employee;
        }
        public List<string> EmployeeListToGui()
        {
            List<string> list = new List<string>();
            {
                foreach (Employee employee in employeeRepo.employees)
                {
                    list.Add(employee.EmployeeId + ". " + employee.GetName() + " Tlf: " + employee.GetTelephoneNO() );
                    
                }
            }
            return list;
        }



    }
}
