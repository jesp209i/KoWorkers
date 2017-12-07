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
                person += employees[i].EmployeeId + ". " + employees[i].GetName() + "\n";
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
                            int employeeID = int.Parse(reader["EmployeeID"].ToString());
                            string lastName = reader["LastName"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            Employee employee = new Employee(employeeID, firstName, lastName);
                            employees.Add(employee);
                        }
                    }
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
        }
        public void AddEmployee(Employee newEmployee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("SpNewEmployee", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add(new SqlParameter("@LastName", newEmployee.LastName));
                    cmd1.Parameters.Add(new SqlParameter("@FirstName", newEmployee.FirstName));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e) { Console.WriteLine("Muuuuligvis en fejl\n" + e.Message); }
            }
            FetchAllEmployees();
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
        /*
        TODO:

        Stored Procedures der mangler implementereing:
        SpEmployeeById
        SpUpdateEmployee
         
         
         */
    }
}

