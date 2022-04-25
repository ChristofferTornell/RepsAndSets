using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepsAndSets.Library;

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

            WorkoutViewer workoutViewer = new WorkoutViewer();

            GlobalConfig.LoggedInUser = GlobalConfig.Connector.User_GetByNickname("Christoffer");
            GlobalConfig.LoggedInUser.Workouts = GlobalConfig.Connector.Workouts_GetByUser(GlobalConfig.LoggedInUser.Id);

            GlobalConfig.InitializeWorkoutViewer(workoutViewer);

            Application.Run(workoutViewer);
        }
    }
}
