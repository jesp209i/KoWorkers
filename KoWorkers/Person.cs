using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Person
    {
        public string FirstName { get; set; }
        private string firstName;
        public Person(string newFirstName)
        {
            firstName = newFirstName;
            FirstName = newFirstName;
        }
        public string GetName()
        {
            return firstName;
        }
        public void SetName(string setFirstName)
        {
            firstName = setFirstName;
            
        }
    }
}
