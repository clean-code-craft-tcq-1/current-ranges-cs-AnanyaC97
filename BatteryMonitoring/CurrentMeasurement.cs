using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryMonitoring
{
    public class CurrentMeasurement
    {
        public bool IsReadingListEmpty(List<int> readings)
        {
            return (readings.Count == 0) ? true : false;
        }
        public Dictionary<string, int> GetCurrentReadingsRanges(List<int> readings)
        {
            Dictionary<string, int> readingRange = new Dictionary<string, int>();
            if(!IsReadingListEmpty(readings))
            {
                readingRange = EvaluateReadingRange(readings);
            }
            return readingRange;
        }
        public Dictionary<string, int> EvaluateReadingRange(List<int> readings)
        {
            Dictionary<string, int> readingRange = new Dictionary<string, int>();
            int startReading = readings[0];
            int endReading = readings[0];
            int currentReading = readings[0];
            int readingIndex = 1;
            readings.Sort();
            for (int i = 1; i < readings.Count; i++)
            {
                if (currentReading == readings[i] || currentReading + 1 == readings[i])
                {
                    currentReading = readings[i];
                    endReading = readings[i];
                    readingIndex++;
                }
                else
                {
                    readingRange.Add(startReading + "-" + endReading, readingIndex);
                    startReading = readings[i];
                    endReading = readings[i];
                    currentReading = readings[i];
                    readingIndex = 1;
                }
            }
            readingRange.Add(startReading + "-" + endReading, readingIndex);
            return readingRange;
        }
    }
}
