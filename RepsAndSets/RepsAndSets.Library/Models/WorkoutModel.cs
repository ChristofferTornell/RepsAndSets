using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library.Models
{
    public class WorkoutModel
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public List<TaskModel> Tasks = new List<TaskModel>();
        
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
