using RepsAndSets.Library.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public int[] Color = new int[3];
        public int SongId;
        
        /// <summary>
        /// The base duration of the timer in seconds.
        /// </summary>
        public int Duration { get; set; }
        public TaskModel() {
            Title = TaskModelDefaults.TaskName;
            Duration = TaskModelDefaults.TimerDuration;
        }
        public TaskModel(string title, int duration) {
            Title = title;
            Duration = duration;
        }
    }
}
