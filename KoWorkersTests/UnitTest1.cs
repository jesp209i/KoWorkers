using System;
using KoWorkers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KoWorkersTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldCreateAPerson()

        {
            Person newPerson = new Person("Lars");

            Assert.AreEqual("Lars", newPerson.GetName());


        }

        [TestMethod]
        public void ShouldPutPersonsInList()

        {
            PersonRepository personRepo = new PersonRepository();
            Person newPerson = new Person("Lars");
            personRepo.persons.Add(newPerson);
         

            Assert.AreEqual("Lars", personRepo.ListAllPersons());


        }
    }
}
