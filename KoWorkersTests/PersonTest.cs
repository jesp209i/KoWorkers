using System;
using KoWorkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoWorkersTests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void ShouldCreateAPerson()
        {
            Person newPerson = new Person("Lars");
            Assert.AreEqual("Lars", newPerson.GetName());
        }
        [TestMethod]
        public void ShouldRenameAPerson()
        {
            Person newPerson = new Person("Lars");
            newPerson.SetName("Jesper");
            Assert.AreEqual("Jesper", newPerson.GetName());
        }
        [TestMethod]
        public void ShouldPutPersonsInList()
        {
            PersonRepository personRepo = new PersonRepository();

            Assert.AreEqual(0, personRepo.Count());

            Person newPerson = new Person("Lars");
            personRepo.persons.Add(newPerson);

            Assert.AreEqual(1, personRepo.Count()); // tilføjet en person

            Person nextPerson = new Person("Jesper");
            personRepo.persons.Add(nextPerson);
            Person nextNextPerson = new Person("Andreas");
            personRepo.persons.Add(nextNextPerson);

            Assert.AreEqual(3, personRepo.Count()); // tilføjet to mere, dvs 3 ialt
        }
        [TestMethod]
        public void ShouldDeleteAPerson()
        {
            PersonRepository personRepo = new PersonRepository();
            Assert.AreEqual(0, personRepo.Count());

            Person newPerson = new Person("Lars");
            personRepo.persons.Add(newPerson);
            Assert.AreEqual(1, personRepo.Count());

            Person nextPerson = new Person("Jesper");
            personRepo.persons.Add(nextPerson);
            Assert.AreEqual(2, personRepo.Count());
            personRepo.persons.Remove(newPerson);
            Assert.AreEqual(1, personRepo.Count());

            personRepo.persons.Add(newPerson);
            Person nextNextPerson = new Person("Andreas");
            personRepo.persons.Add(nextNextPerson);
            Assert.AreEqual(3, personRepo.Count());

            personRepo.persons.Remove(newPerson);
            Assert.AreEqual(2, personRepo.Count());


        }

        [TestMethod]
        public void ShouldListAllPersons()
        {
            PersonRepository personRepo = new PersonRepository();
            Person newPerson = new Person("Lars");
            personRepo.persons.Add(newPerson);
            personRepo.ListAllPersons();
            Assert.AreEqual("Lars", personRepo.ListAllPersons());
        }


    }
}
