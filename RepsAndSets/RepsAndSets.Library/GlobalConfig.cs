using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library.Models;
using RepsAndSets.Library.DataAccess;

namespace RepsAndSets.Library
{
    public static class GlobalConfig
    {
        public static UserModel LoggedInUser { get; set; }
        public static IDataConnector Connector;
        public static IWorkoutViewer WorkoutViewer;

        public static void InitializeConnections() {
            Connector = new SqlDataConnector();
        }
        public static void InitializeWorkoutViewer(IWorkoutViewer workoutViewer) {
            WorkoutViewer = workoutViewer;
        }
        public static string ConnectionString(string name) {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
