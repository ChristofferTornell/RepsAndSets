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
    }
}
