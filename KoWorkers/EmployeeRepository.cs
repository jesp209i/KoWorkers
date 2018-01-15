using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KoWorkers
{
    public class EmployeeRepository
    {
        private static string connectionString =
    "server = EALSQL1.eal.local; database = DB2017_C02; user Id=USER_C02; Password=SesamLukOp_02;";
        private List<Employee> employees = new List<Employee>();
        private static EmployeeRepository instance = null;
        public static EmployeeRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeRepository();
            }
            return instance;
        }
        private EmployeeRepository()
        {
            FetchAllCurrentEmployees(); // Henter Employees fra DB og laver en liste
        }
        public List<Employee> GetEmployees()
        {
            return employees;
        }
        public int Count() // for testing
        {
            int personCounter = 0;
            foreach (Employee person in employees)
            {
                personCounter++;
            }
            return personCounter;
        }
        public Employee GetEmployeeFromList(int id)
        {
            Employee employee = null;
            for (int i = 0; i<employees.Count();i++)
            { 
                if (employees[i].EmployeeId == id)
                {
                    employee = employees[i];
                }
            }
            return employee;
        }
        public void FetchAllCurrentEmployees()
        {
            employees.Clear(); // nulstiller listen inden den bliver hentet igen
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand fetchAllWorkers = new SqlCommand("SpAllEmployees", con);
                    fetchAllWorkers.CommandType = CommandType.StoredProcedure;
                    fetchAllWorkers.Parameters.Add(new SqlParameter("@CurrentDate", DateTime.Now.Date.ToString("d")));
                    SqlDataReader reader = fetchAllWorkers.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int employeeID = int.Parse(reader["EmployeeID"].ToString());
                            string lastName = reader["LastName"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            int pinCode = int.Parse(reader["Pin"].ToString());
                            int telephoneNo = int.Parse(reader["TelephoneNo"].ToString());
                            Employee employee = new Employee(employeeID, firstName, lastName, pinCode, telephoneNo);
                            employees.Add(employee);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            EmployeeHasOpenShifts();
        }

        private void EmployeeHasOpenShifts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand employeesHasOpenShift = new SqlCommand("SpHasOpenShift", con);
                    employeesHasOpenShift.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = employeesHasOpenShift.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employee editEmployeeOpenShiftStatus = GetEmployeeFromList(int.Parse(reader["EmployeeID"].ToString()));
                            editEmployeeOpenShiftStatus.OpenShift = int.Parse(reader["OpenShift"].ToString());
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
        }
        public string AddEmployee(Employee newEmployee)
        {
            string message = newEmployee.FullName + " er tilføjet";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewEmployee", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@LastName", newEmployee.LastName));
                    cmd1.Parameters.Add(new SqlParameter("@FirstName", newEmployee.FirstName));
                    cmd1.Parameters.Add(new SqlParameter("@Pin", newEmployee.PinCode));
                    cmd1.Parameters.Add(new SqlParameter("@TelephoneNo", newEmployee.TelephoneNo));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e) { message = "Der skete en fejl\n" + e.Message +"\nMedarbejder blev ikke tilføjet"; }
            }
            FetchAllCurrentEmployees();
            return message;
        }
        public string RemoveEmployee(Employee removeEmployee)
        {
            // SpRemoveEmployee
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand removesEmployee = new SqlCommand("SpRemoveEmployee", con);
                    removesEmployee.CommandType = CommandType.StoredProcedure;
                    removesEmployee.Parameters.Add(new SqlParameter("@EndDate", DateTime.Now.AddDays(-1)));
                    removesEmployee.Parameters.Add(new SqlParameter("@EmployeeId", removeEmployee.EmployeeId));

                    removesEmployee.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllCurrentEmployees();
            return removeEmployee.FullName;
        }
        public string UpdateEmployee(Employee updateEmployee)
        {
            // SpRemoveEmployee
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand updatesEmployee = new SqlCommand("SpUpdateEmployee", con);
                    updatesEmployee.CommandType = CommandType.StoredProcedure;
                    updatesEmployee.Parameters.Add(new SqlParameter("@LastName", updateEmployee.LastName));
                    updatesEmployee.Parameters.Add(new SqlParameter("@FirstName", updateEmployee.FirstName));
                    updatesEmployee.Parameters.Add(new SqlParameter("@TelephoneNo", updateEmployee.TelephoneNo));
                    updatesEmployee.Parameters.Add(new SqlParameter("@Pin", updateEmployee.PinCode));
                    updatesEmployee.Parameters.Add(new SqlParameter("@EmployeeId", updateEmployee.EmployeeId));

                    updatesEmployee.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllCurrentEmployees();
            return updateEmployee.FullName;
        }

        public Employee GetEmployeeByPin(int pin)
        {
            Employee employee = null;

            for (int i = 0; i < employees.Count(); i++)
            {
                if (employees[i].PinCode == pin)
                {
                    employee = employees[i];
                }
            }
            return employee;
        }
        public Employee GetEmployeeById(int idno)
        {
            Employee employee = null;
            int i = 0;
            do
            {
                employee = employees[i];
                i++;
            } while (employees[i].EmployeeId != idno);
            return employee;
        }
    }
}

