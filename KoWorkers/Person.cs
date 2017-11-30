using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class Person
    {
        private string firstName;
        public Person(string newFirstName)
        {
            firstName = newFirstName;
        }
        public string GetName()
        {
            return firstName;
        }
        public string SetName(string setFirstName)
        {
            firstName = setFirstName;
        }
    }
}
