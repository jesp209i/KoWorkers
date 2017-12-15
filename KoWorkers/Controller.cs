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

        public string CheckInByPin(int pin)
        {
            Employee employee = employeeRepo.GetEmployeeByPin(pin);
            string messageToUI = "";
            if (employee != null && employee.GetOpenShift() == -1)
            {
                ShiftRepository shiftRepository = new ShiftRepository();
                int shiftID = shiftRepository.AddShift(employee.EmployeeId);
                employee.SetOpenShift(shiftID);
                messageToUI = employee.GetName() + " blev tjekket ind";
            }
            else if (employee != null && employee.GetOpenShift() > -1)
            {
                ShiftRepository shiftRepository = new ShiftRepository();
                shiftRepository.EndShift(employee.GetOpenShift());
                employee.SetOpenShift(-1);
                messageToUI = employee.GetName() + " blev tjekket ud";
            }
            else if (employee != null)
            {
                messageToUI = "Ingen medarbejder med den PINkode. Blev der tastet korrekt ind?";
            }
            return messageToUI;            
        }
        public List<string> EmployeeListToGui()
        {
            List<string> list = new List<string>();
            {
                foreach (Employee employee in employeeRepo.employees)
                {
                    list.Add(employee.GetName());
                    
                }
            }
            return list;
        }



    }
}
