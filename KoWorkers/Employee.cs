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
        public int PinCode { get; set; }
        public int TelephoneNo { get; set; }
        public int OpenShift { get; set; }
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
        public DateTime EmploymentEndDate { get; set; }
        public Employee(string newFirstName, string newLastName,int newPinCode, int newTelephoneNo)
        {
            TelephoneNo = newTelephoneNo;
            FirstName = newFirstName;
            LastName = newLastName;
            PinCode = newPinCode;

        }
       
        public Employee(int employeeId, string newFirstName, string newLastName, int newPinCode, int newTelephoneNo)
        {
            EmployeeId = employeeId;
            FirstName = newFirstName;
            LastName = newLastName;
            PinCode = newPinCode;
            TelephoneNo = newTelephoneNo;
            OpenShift = -1;
        }
    }
}
