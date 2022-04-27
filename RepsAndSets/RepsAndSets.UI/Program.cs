using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepsAndSets.Library;
using RepsAndSets.Library.Models;

namespace RepsAndSets.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalConfig.InitializeConnections();

            GlobalConfig.LoggedInUser = GlobalConfig.Connector.User_GetByNickname("Christoffer");
            GlobalConfig.LoggedInUser.Workouts = GlobalConfig.Connector.Workouts_GetByUser(GlobalConfig.LoggedInUser.Id);
            foreach (WorkoutModel workout in GlobalConfig.LoggedInUser.Workouts) {
                workout.Tasks = GlobalConfig.Connector.Tasks_GetByWorkout(workout.Id);
            }

            WorkoutViewer workoutViewer = new WorkoutViewer();

            GlobalConfig.InitializeWorkoutViewer(workoutViewer);

            Application.Run(workoutViewer);
        }
    }
}
