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
        public List<string> EmployeeListToCheckOutToGui()
        {
            {
                List<string> list = new List<string>();
                {
                    foreach (Employee employee in employeeRepo.employees)
                    {
                        if (employee.GetOpenShift() == -1)
                        {
                            list.Add(employee.GetName() + " id: " + employee.EmployeeId + ". Shift: " + employee.GetOpenShift() + " PIN: " + employee.PinCode);
                        }
                    }
                }
                return list;
            }
        }

        public string ShowSelectedEmployeeTelephoneNO(int idx)
        {
            string telephoneNO = "";
            List<Employee> list = MakeEmployeeListToGui();
            telephoneNO = list[idx].TelephoneNo.ToString();
            return telephoneNO;
        }

        public string ShowSelectedEmployeeLastName(int idx)
        {
            string lastName = "";
            List<Employee> list = MakeEmployeeListToGui();
            lastName = list[idx].LastName;
            return lastName;
        }

        public string ShowSelectedEmployeeFirstName(int idx)
        {
            string firstName = "";
           List<Employee> list = MakeEmployeeListToGui();
            firstName = list[idx].FirstName;
            return firstName;
        }

        public List<Employee> MakeEmployeeListToGui()
        {
            {
                List<Employee> list = new List<Employee>();
                {
                    foreach (Employee employee in employeeRepo.employees)
                    {
                        if (employee.GetOpenShift() != -1)
                        {
                            list.Add(employee);
                        }
                    }
                }
                return list;
            }
        }
        public List<Employee> MakeEmployeeListProgressBar()
        {
            {
                List<Employee> list = new List<Employee>();
                {
                    foreach (Employee employee in employeeRepo.employees)
                    {
                        
                            list.Add(employee);
                        
                    }
                }
                return list;
            }
        }
        public List<string> EmployeeListToCheckInToGui()
        {
            {
                List<string> list = new List<string>();
                {
                    foreach (Employee employee in employeeRepo.employees)
                    {
                        if (employee.GetOpenShift() != -1)
                        {
                            list.Add(employee.GetName() + " id: " + employee.EmployeeId + ". Shift: " + employee.GetOpenShift() + " PIN: " + employee.PinCode);
                        }
                    }
                }
                return list;
            }
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
        public string[,] toGui()
        {
            
            string[,] arraytoGui = new string[MakeEmployeeListProgressBar().Count, 2];
            for(int i =0; i < MakeEmployeeListProgressBar().Count; i++) 
            {
                arraytoGui[i, 0] = MakeEmployeeListProgressBar()[i].GetName();
                arraytoGui[i, 1] = MakeEmployeeListProgressBar()[i].GetOpenShift().ToString();
                //for (int j = 0; j < MakeEmployeeListProgressBar().Count; j++)
                //{

                //    arraytoGui[i, 1] = MakeEmployeeListProgressBar()[i].GetOpenShift().ToString();

                //}
            }
            return arraytoGui;
                }
    }
}
