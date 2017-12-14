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
        private bool isCheckedIn;
    
        public Employee(string newFirstName, string newLastName,int newPinCode, int newTelephoneNo)
        {
            TelephoneNo = newTelephoneNo;
            FirstName = newFirstName;
            LastName = newLastName;
            PinCode = newPinCode;

        }
        public bool IsChekedIn()
        {
            return isCheckedIn;
        }

        public Employee(int employeeId, string newFirstName, string newLastName, int newPinCode, int newTelephoneNo,bool newIsCheckedIn)
        {
            EmployeeId = employeeId;
            FirstName = newFirstName;
            LastName = newLastName;
            PinCode = newPinCode;
            TelephoneNo = newTelephoneNo;
            isCheckedIn = newIsCheckedIn;
            
        }
        public string GetName()
        {
            return FirstName + " " + LastName;
        }
        public void SetName(string setFirstName, string setLastName)
        {
            FirstName = setFirstName;
            LastName = setLastName;

        }
        public void SetPinCode(int setPinCode)
        {
            PinCode = setPinCode;
        }

        public int GetTelephoneNO()
        {
            return TelephoneNo;
        }
    }
}
