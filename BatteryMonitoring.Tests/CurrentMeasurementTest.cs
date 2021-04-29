using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BatteryMonitoring.Tests
{
    [TestClass]
    public class CurrentMeasurementTest
    {
        CurrentMeasurement currentMeasurement = new CurrentMeasurement();

        [TestMethod]
        public void GivenEmptyReading_WhenListIsEmpty_ThenTrueIsReturned()
        {
            List<int> CurrentReadings = new List<int>() { };
            Assert.IsTrue(currentMeasurement.IsReadingListEmpty(CurrentReadings));
        }

        [TestMethod]
        public void GivenReadingWithValues_WhenListIsNotEmpty_ThenFalseIsReturned()
        {
            List<int> CurrentReadings = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Assert.IsTrue(currentMeasurement.IsReadingListEmpty(CurrentReadings));
        }

        [TestMethod]
        public void GivenReadingWithValues_WhenListHasExpectedRange_ThenTrueIsReturned()
        {
            Dictionary<string, int> expectedRange = new Dictionary<string, int>();
            expectedRange.Add("3-5", 4);
            expectedRange.Add("10-12", 3);
            List<int> CurrentReadings = new List<int>() { 3, 3, 5, 4, 10, 11, 12 };
            Dictionary<string, int> actualRange = currentMeasurement.GetCurrentReadingsRanges(CurrentReadings);
            Assert.AreEqual(expectedRange,actualRange);
        }
    }
}
