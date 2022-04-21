using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library.Models
{
    public class WorkoutModel
    {
        string _title { get; set; }
        int _id { get; set; }

        List<TaskModel> tasks;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The total duration of each tasks' timer in milliseconds.</returns>
        //public double TotalDuration() {
        //    double output = 0;
        //    foreach (TaskModel task in tasks) {
        //        output += task.Timer.Interval;
        //    }
        //    return output;
        //}
    }
}
