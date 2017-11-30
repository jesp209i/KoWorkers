using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoWorkers
{
    public class PersonRepository
    {
        public List<Person> persons = new List<Person>();

        public string ListAllPersons()
        {
            String person = "";
            for (int i = 0; i < persons.Count; i++)
            {
                person += persons[i].FirstName;
            }
            return person;
        }
    }
}

