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
            string message = "";
            Employee employee = employeeRepo.GetEmployeeByPin(pin);

            if (employee != null && employee.GetOpenShift() == -1)
            {
                ShiftRepository shiftRepository = new ShiftRepository();
                int shiftID = shiftRepository.AddShift(employee.EmployeeId);
                employee.SetOpenShift(shiftID);
                message += employee.GetName() + " er tjekket ind";
            }
            else if (employee != null && employee.GetOpenShift() != -1)
            {
                ShiftRepository shiftRepository = new ShiftRepository();
                shiftRepository.EndShift(employee.GetOpenShift());
                employee.SetOpenShift(-1);
                message += employee.GetName() + " blev tjekket ud";
            }
            else if (employee == null)
            {
                message += "Du har tastet en forkert PIN-kode";
            }
            return message;
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
