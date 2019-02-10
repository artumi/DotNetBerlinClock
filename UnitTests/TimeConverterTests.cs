using System;
using BerlinClock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TimeConverterTests
    {
        private readonly TimeConverter timeConverter = new TimeConverter();

        [TestMethod]
        public void YellowLampsEven()
        {
            Assert.AreEqual("Y", timeConverter.YellowLamps("00:00:02"));
        }

        [TestMethod]
        public void YellowLampsOdd()
        {
            Assert.AreEqual("O", timeConverter.YellowLamps("00:00:01"));
        }

        [TestMethod]
        public void YellowLampsZero()
        {
            Assert.AreEqual("Y", timeConverter.YellowLamps("00:00:00"));
        }

        [TestMethod]
        public void FiveHoursLampsAllOff()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual("OOOO", timeConverter.FiveHoursLamps(String.Format("0{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsOneOn()
        {
            for (int i = 5; i < 10; i++)
            {
                Assert.AreEqual("ROOO", timeConverter.FiveHoursLamps(String.Format("0{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsTwoOn()
        {
            for (int i = 10; i < 15; i++)
            {
                Assert.AreEqual("RROO", timeConverter.FiveHoursLamps(String.Format("0{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsThreeOn()
        {
            for (int i = 15; i < 20; i++)
            {
                Assert.AreEqual("RRRO", timeConverter.FiveHoursLamps(String.Format("0{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsAllOn()
        {
            for (int i = 20; i < 25; i++)
            {
                Assert.AreEqual("RRRR", timeConverter.FiveHoursLamps(String.Format("0{0}:00:00",
                         i)));
            }
        }
    }
}
