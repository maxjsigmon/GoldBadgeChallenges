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
        public void MyTestMethod()
        {

        }
    }
}
