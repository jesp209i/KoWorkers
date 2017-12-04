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
        public string ListAllEmployees()
        {
            string person = "";
                for (int i = 0; i < employees.Count; i++)
                            {
                person += employees[i].GetName();
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
        /*
        TODO:

        Stored Procedures der mangler implementereing:
        SpEmployeeById
        SpRemoveEmployee
        SpUpdateEmployee
         
         
         */
    }
}

