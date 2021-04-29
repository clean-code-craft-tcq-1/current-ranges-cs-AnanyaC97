using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BatteryMonitoring.Tests
{
    [TestClass]
    public class CurrentMeasurementTest
    {
        CurrentMeasurement currentMeasurement = new CurrentMeasurement();
        List<int> CurrentReadings = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };

        [TestMethod]
        public void GivenEmptyReading_WhenListIsEmpty_ThenTrueIsReturned()
        {
            List<int> emptyReadings = new List<int>();
            Assert.IsTrue(currentMeasurement.IsReadingListEmpty(emptyReadings));
        }

        [TestMethod]
        public void GivenReadingWithValues_WhenListIsNotEmpty_ThenFalseIsReturned()
        {
            Assert.IsTrue(currentMeasurement.IsReadingListEmpty(CurrentReadings));
        }

        [TestMethod]
        public void GivenReadingWithValues_WhenListHasExpectedRange_ThenTrueIsReturned()
        {
            Dictionary<string, int> expectedRange = new Dictionary<string, int>();
            expectedRange.Add("3-5", 4);
            expectedRange.Add("10-12", 3);
            CollectionAssert.AreEqual(expectedRange, currentMeasurement.GetCurrentReadingsRanges(CurrentReadings));
        }

        [TestMethod]
        public void GivenReadingWithValues_WhenListHasNotExpectedRange_ThenFalseIsReturned()
        {
            Dictionary<string, int> expectedRange = new Dictionary<string, int>();
            expectedRange.Add("3-5", 4);
            expectedRange.Add("10-12", 4);
            CollectionAssert.AreEqual(expectedRange, currentMeasurement.GetCurrentReadingsRanges(CurrentReadings));
        }
    }
}
