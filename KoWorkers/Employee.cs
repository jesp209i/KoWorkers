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

        public DateTime EmploymentEndDate { get; set; }
        private int openShift = -1;

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
        public void SetOpenShift (int shiftId)
        {
            openShift = shiftId;
        }
        public int GetOpenShift()
        {
            return openShift;
        }

        public DateTime GetEndDateTime()
        {
            return EmploymentEndDate;
        }

        public void SetDateTime(DateTime dateTime)
        {
            EmploymentEndDate = dateTime;
        }
    }
}
