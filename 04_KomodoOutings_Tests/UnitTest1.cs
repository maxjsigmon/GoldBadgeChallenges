using System;
using System.Collections.Generic;
using _04_KomodoOutings_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_KomodoOutings_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOutingToList_ShouldReturnTrue()
        {
            Outings outing = new Outings();
            OutingsRepo repo = new OutingsRepo();

            bool addOuting = repo.AddOuting(outing);

            Assert.IsTrue(addOuting);
        }

        [TestMethod]
        public void GetOutingType_ShouldReturnCorrectContent()
        {
            OutingsRepo repo = new OutingsRepo();
            Outings newOuting = new Outings(EventType.Bowling, 10, new DateTime (2020, 10, 26), 10);
            repo.AddOuting(newOuting);
            EventType eventType = EventType.Bowling;

            Outings result = repo.GetOutingByType(eventType);

            Assert.AreEqual(result.EventType, eventType);
        }

        //[TestMethod]
        //public void GetTotalByEvent_ShouldReturn()
        //{
        //    OutingsRepo repo = new OutingsRepo();
        //    Outings newOuting = new Outings(EventType.Bowling, 10, new DateTime(2020, 10, 26), 10);
        //    Outings newOuting2 = new Outings(EventType.Bowling, 10, new DateTime(2020, 10, 27), 10);
        //    repo.AddOuting(newOuting);
        //    repo.AddOuting(newOuting2);
        //    double costPerPerson = 10;

        //} **Test not working
    }
}
