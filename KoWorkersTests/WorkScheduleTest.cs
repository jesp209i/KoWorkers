using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KoWorkers.WorkSchedule;
using KoWorkers;

namespace KoWorkersTests
{
    [TestClass]
    public class WorkScheduleTest
    {
        Employee testEmployee = new Employee("Niels", "Hansen", 1234, 12345678);
        DateTime thisMoment = DateTime.Now;
        
        [TestInitialize]
        public void Initialize()
        {
        }
        [TestMethod]
        public void CreateNewShift()
        {
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, thisMoment, thisMoment.AddHours(2));
            TimeSpan timeSpan = new TimeSpan(2, 0, 0);
            Assert.AreEqual("Niels Hansen", newShift.Employee.FullName);
            Assert.AreEqual(timeSpan, newShift.EndTime.Subtract(newShift.StartTime));
            Assert.AreEqual(120, newShift.TotalNumberOfMinutes);
        }
        [TestMethod]
        public void CreateNewSchedule()
        {
            WorkScheduleShift newShift = new WorkScheduleShift(testEmployee, thisMoment, thisMoment.AddHours(2));
            WorkSchedule testSchedule = new WorkSchedule(2018, 3);
            Assert.AreEqual(2018, testSchedule.Year);
            Assert.AreEqual(0, testSchedule.GetAllShifts().Count);
            testSchedule.AddShiftToSchedule(newShift);
            Assert.AreEqual(1, testSchedule.GetAllShifts().Count);
        }
        [TestMethod]
        public void CreateNewScheduleRepo()
        {
            WorkScheduleRepository wsp = WorkScheduleRepository.GetInstance();
            WorkSchedule first = new WorkSchedule(2018, 3);
            WorkSchedule second = new WorkSchedule(2018, 4);
            WorkSchedule third = new WorkSchedule(2018, 5);
            WorkSchedule fourth = new WorkSchedule(2018, 6);
            wsp.AddWorkSchedule(first);
            wsp.AddWorkSchedule(second);
            wsp.AddWorkSchedule(third);
            wsp.AddWorkSchedule(fourth);
            Assert.AreEqual(4, wsp.GetWorkSchedules().Count);
            Assert.AreEqual(5, wsp.GetSchedule(2018, 5).Month);
            Assert.AreEqual(null, wsp.GetSchedule(2017, 1));

        }
    }
}
