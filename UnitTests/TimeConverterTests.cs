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
                Assert.AreEqual("OOOO", timeConverter.FiveHoursLamps(String.Format("{0}:00:00",
                         '0' + i.ToString())));
            }
        }

        [TestMethod]
        public void FiveHoursLampsOneOn()
        {
            for (int i = 5; i < 10; i++)
            {
                Assert.AreEqual("ROOO", timeConverter.FiveHoursLamps(String.Format("{0}:00:00",
                          '0' + i.ToString())));
            }
        }

        [TestMethod]
        public void FiveHoursLampsTwoOn()
        {
            for (int i = 10; i < 15; i++)
            {
                Assert.AreEqual("RROO", timeConverter.FiveHoursLamps(String.Format("{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsThreeOn()
        {
            for (int i = 15; i < 20; i++)
            {
                Assert.AreEqual("RRRO", timeConverter.FiveHoursLamps(String.Format("{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void FiveHoursLampsAllOn()
        {
            for (int i = 20; i < 24; i++)
            {
                Assert.AreEqual("RRRR", timeConverter.FiveHoursLamps(String.Format("{0}:00:00",
                         i)));
            }
        }

        [TestMethod]
        public void OneHourLampsAllOff()
        {
            Assert.AreEqual("OOOO", timeConverter.OneHourLamps("00:00:00"));
            Assert.AreEqual("OOOO", timeConverter.OneHourLamps("05:00:00"));
            Assert.AreEqual("OOOO", timeConverter.OneHourLamps("10:00:00"));
            Assert.AreEqual("OOOO", timeConverter.OneHourLamps("15:00:00"));
            Assert.AreEqual("OOOO", timeConverter.OneHourLamps("20:00:00"));
        }

        [TestMethod]
        public void OneHourLampsOnBeforeTen()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 5 == 1)
                    Assert.AreEqual("ROOO", timeConverter.OneHourLamps(String.Format("{0}:00:00", '0' + i.ToString())));
                else if (i % 5 == 2)
                    Assert.AreEqual("RROO", timeConverter.OneHourLamps(String.Format("{0}:00:00", '0' + i.ToString())));
                else if (i % 5 == 3)
                    Assert.AreEqual("RRRO", timeConverter.OneHourLamps(String.Format("{0}:00:00", '0' + i.ToString())));
                else if (i % 5 == 4)
                    Assert.AreEqual("RRRR", timeConverter.OneHourLamps(String.Format("{0}:00:00", '0' + i.ToString())));
            }
        }

        [TestMethod]
        public void OneHourLampsOnAfterTen()
        {
            for (int i = 10; i < 24; i++)
            {
                if (i % 5 == 1)
                    Assert.AreEqual("ROOO", timeConverter.OneHourLamps(String.Format("{0}:00:00", i)));
                else if (i % 5 == 2)
                    Assert.AreEqual("RROO", timeConverter.OneHourLamps(String.Format("{0}:00:00", i)));
                else if (i % 5 == 3)
                    Assert.AreEqual("RRRO", timeConverter.OneHourLamps(String.Format("{0}:00:00", i)));
                else if (i % 5 == 4)
                    Assert.AreEqual("RRRR", timeConverter.OneHourLamps(String.Format("{0}:00:00", i)));
            }
        }
    }
}
