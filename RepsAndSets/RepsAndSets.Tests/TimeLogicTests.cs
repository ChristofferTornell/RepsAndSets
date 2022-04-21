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
        public void ConvertToTime_ShouldConvertToTime(int secondsTotal, int expectedMinutes, int expectedSeconds) {
            // Arrange

            // Act
            TimeLogic.ConvertToTime(secondsTotal, out int minutes, out int seconds);

            // Assert
            Assert.Equal(expectedMinutes, minutes);
            Assert.Equal(expectedSeconds, seconds);

        }
    }
}
