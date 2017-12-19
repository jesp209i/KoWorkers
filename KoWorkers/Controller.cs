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
        public string ShowSelectedEmployeeTelephoneNO(int idx)
        {
            string telephoneNO = "";
            List<Employee> list = MakeEmployeeListProgressBar();
            telephoneNO = list[idx].TelephoneNo.ToString();
            return telephoneNO;
        }

        public string ShowSelectedEmployeeLastName(int idx)
        {
            string lastName = "";
            List<Employee> list = MakeEmployeeListProgressBar();
            lastName = list[idx].LastName;
            return lastName;
        }

        public string ShowSelectedEmployeeFirstName(int idx)
        {
            string firstName = "";
           List<Employee> list = MakeEmployeeListProgressBar();
            firstName = list[idx].FirstName;
            return firstName;
        }

        public List<Employee> MakeEmployeeListProgressBar()
        {
                return employeeRepo.employees;
        }
   
        public string ShowCheckInOutMessageInGui(int pin)
        {
            string message = "";
            Employee employee = CheckInByPin(pin);
            if (employee.GetOpenShift() == -1)
            {
                message = employee.GetName() + " blev tjekket ud.";
            }
            if (employee.GetOpenShift() > -1)
            {
                message = employee.GetName() + " er tjekket ind.";
            }
            if (employee == null)
            {
                message = "PIN-koden er forkert";
            }
            return message;
        }

    }
}
