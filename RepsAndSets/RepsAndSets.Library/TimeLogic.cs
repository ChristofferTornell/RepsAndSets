using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library
{
    public static class TimeLogic
    {
        public static void ConvertToTime(int secondsTotal, out int minutes, out int seconds) {
            minutes = (int)(secondsTotal / 60);
            seconds = secondsTotal % 60;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns>Time in seconds</returns>
        public static int ConvertFromTime(int minutes, int seconds) {
            return minutes * 60 + seconds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public static void ToTime(this string timeString, out int minutes, out int seconds) {
            minutes = 0;
            seconds = 0;
            if (timeString.Contains(':')) {
                string[] split = timeString.Split(':');
                int.TryParse(split[0], out minutes);
                int.TryParse(split[1], out seconds);
            } else {
                int.TryParse(timeString, out minutes);
            }
        }

        public static string ToTimeString(this int timeMeasurement) {
            string output;
            if (timeMeasurement < 10 && timeMeasurement >= 0) {
                output = $"0{timeMeasurement}";
            } else {
                output = timeMeasurement.ToString();
            }
            return output;
        }
    }
}
