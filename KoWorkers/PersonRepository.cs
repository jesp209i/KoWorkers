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
        public int Count() // for testing
        {
            int personCounter = 0;
            foreach (Person person in persons)
            {
                personCounter++;
            }
            return personCounter;
        }
        public string ListAllPersons()
        {
            string person = "";
                for (int i = 0; i < persons.Count; i++)
                            {
                person += persons[i].FirstName;
                }
                        return person;
        }
        
    }
}

