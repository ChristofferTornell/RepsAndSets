using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library;
using Xunit;

namespace RepsAndSets.Tests
{
    public class TimeLogicTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(30, 0, 30)]
        [InlineData(60, 1, 0)]
        [InlineData(90, 1, 30)]
        [InlineData(119, 1, 59)]
        [InlineData(120, 2, 0)]
        public void ConvertToTime_ShouldConvertSecondsToTime(int secondsTotal, int expectedMinutes, int expectedSeconds) {
            // Arrange

            // Act
            TimeLogic.ConvertToTime(secondsTotal, out int minutes, out int seconds);

            // Assert
            Assert.Equal(expectedMinutes, minutes);
            Assert.Equal(expectedSeconds, seconds);

        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 30, 30)]
        [InlineData(1, 0, 60)]
        [InlineData(1, 1, 61)]
        public void ConvertFromTime_ShouldConvertTimeToSeconds(int minutes, int seconds, int expectedSeconds) {
            // Arrange

            // Act
            int secondsResult = TimeLogic.ConvertFromTime(minutes, seconds);

            // Assert
            Assert.Equal(expectedSeconds, secondsResult);

        }

        [Theory]
        [InlineData("00:00", 0, 0)]
        [InlineData("abcdef", 0, 0)]
        [InlineData("0:", 0, 0)]
        [InlineData(":0", 0, 0)]
        [InlineData("", 0, 0)]
        [InlineData("1:010", 1, 10)]
        [InlineData("1:000", 1, 00)]
        [InlineData("02:30", 2, 30)]
        public void ConvertFromTime_ShouldConvertStringToTime(string timeString, int expectedMinutes, int expectedSeconds) {
            // Arrange

            // Act
            timeString.ToTime(out int minutes, out int seconds);

            // Assert
            Assert.Equal(expectedMinutes, minutes);
            Assert.Equal(expectedSeconds, seconds);

        }

        [Theory]
        [InlineData(0, "00")]
        [InlineData(10, "10")]
        public void ConvertFromTime_ShouldConvertTimeMeasurementToString(int measurement, string expectedString) {
            // Arrange

            // Act
            string measurementString = measurement.ToTimeString();

            // Assert
            Assert.Equal(measurementString, expectedString);
        }
    }
}
