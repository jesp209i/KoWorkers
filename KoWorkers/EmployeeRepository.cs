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
        public List<Employee> employees = new List<Employee>();
        public EmployeeRepository()
        {
            FetchAllEmployees(); // Henter Employees fra DB og laver en liste
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
        public string ListAllEmployees()
        {
            string person = "";
                for (int i = 0; i < employees.Count; i++)
                            {
                person += employees[i].EmployeeId + ". " + employees[i].GetName() + " Tlf: " + employees[i].GetTelephoneNO() +"\n";
                }
                        return person;
        }

        public void FetchAllEmployees()
        {
            employees.Clear(); // nulstiller listen inden den bliver hentet igen
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand fetchAllWorkers = new SqlCommand("SpAllEmployees", con);
                    fetchAllWorkers.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = fetchAllWorkers.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bool isCheckedIn = false;
                            int employeeID = int.Parse(reader["EmployeeID"].ToString());
                            string lastName = reader["LastName"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            int pinCode = int.Parse(reader["Pin"].ToString());
                            int telephoneNo = int.Parse (reader["TelephoneNo"].ToString());
                            if (int.Parse(reader["OpenShift"].ToString()) > 0)
                            {
                                isCheckedIn = true;
                            }                                                     
                            Employee employee = new Employee(employeeID, firstName, lastName,pinCode, telephoneNo,isCheckedIn);
                            employees.Add(employee);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
        }
        public string AddEmployee(Employee newEmployee)
        {
            string message = newEmployee.GetName() + " er tilføjet";
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
            FetchAllEmployees();
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
                    removesEmployee.Parameters.Add(new SqlParameter("@LastName", removeEmployee.LastName));
                    removesEmployee.Parameters.Add(new SqlParameter("@FirstName", removeEmployee.FirstName));
                    removesEmployee.Parameters.Add(new SqlParameter("@EmployeeId", removeEmployee.EmployeeId));

                    removesEmployee.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllEmployees();
            return removeEmployee.GetName();
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
                    updatesEmployee.Parameters.Add(new SqlParameter("@EmployeeId", updateEmployee.EmployeeId));

                    updatesEmployee.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllEmployees();
            return updateEmployee.GetName();
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
        /*
        TODO:

        Stored Procedures der mangler implementereing:
        SpEmployeeById
         */
    }
}

