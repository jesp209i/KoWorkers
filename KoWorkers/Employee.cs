using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KoWorkers
{
    public class Employee : INotifyPropertyChanged
    {
        
        public int EmployeeId { get; set; }
        private string firstName;
        public string FirstName { get {return firstName; } set {firstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            } }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }
        private int pinCode;
        public int PinCode
        {
            get { return pinCode; }
            set
            {
                pinCode = value;
                OnPropertyChanged("PinCode");
            }
        }
        private int telephoneNo;
        public int TelephoneNo
        {
            get { return telephoneNo; }
            set
            {
                telephoneNo = value;
                OnPropertyChanged("TelephoneNo");
            }
        }
        private int openShift;
        public int OpenShift
        {
            get { return openShift; }
            set
            {
                openShift = value;
                OnPropertyChanged("OpenShift");
            }
        }
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
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
