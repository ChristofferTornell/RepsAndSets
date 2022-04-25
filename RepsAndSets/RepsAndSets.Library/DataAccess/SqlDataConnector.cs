using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using RepsAndSets.Library.Models;

namespace RepsAndSets.Library.DataAccess
{
    public class SqlDataConnector : IDataConnector
    {
        public List<TaskModel> Tasks_GetByWorkout(int workoutId) {
            List<TaskModel> output; 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@WorkoutId", workoutId);
                output = connection.Query<TaskModel>("dbo.spTasks_GetByWorkoutId", p, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        public UserModel User_GetByNickname(string nickname) {
            UserModel output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@Nickname", nickname);
                output = connection.Query<UserModel>("dbo.spUser_GetByNickname", p, commandType: CommandType.StoredProcedure).First();
            }
            return output;
        }

        public List<WorkoutModel> Workouts_GetByUser(int userId) {
            List<WorkoutModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@UserId", userId);

                output = connection.Query<WorkoutModel>("dbo.spWorkouts_GetByUser", p, commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        public void Tasks_Insert(TaskModel newTask, WorkoutModel workoutModel) {
            //(@WorkoutId, @OrderIndex, @Duration, @Title, @ColorR, @ColorG, @ColorB, @Song)
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@WorkoutId", workoutModel.Id);
                p.Add("@OrderIndex", newTask.OrderIndex);
                p.Add("@Duration", newTask.Duration);
                p.Add("@Title", newTask.Title);
                p.Add("@ColorR", newTask.Color[0]);
                p.Add("@ColorG", newTask.Color[1]);
                p.Add("@ColorB", newTask.Color[2]);
                p.Add("@Song", newTask.SongId);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTasks_Insert", p, commandType: CommandType.StoredProcedure);

                newTask.Id = p.Get<int>("@id");

            }
        }
        public void Workout_Insert(WorkoutModel newWorkout, UserModel userModel) {
            //(@UserId, @Title)
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@UserId", userModel.Id);
                p.Add("@Title", newWorkout.Title);
                // Create date null
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spWorkouts_Insert", p, commandType: CommandType.StoredProcedure);

                newWorkout.Id = p.Get<int>("@id");

            }
        }

        public void Workouts_RemoveById(int workoutId) {
            //(@UserId, @Title)
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@WorkoutId", workoutId);

                connection.Execute("dbo.spWorkouts_RemoveById", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Tasks_RemoveById(int taskId) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@TaskId", taskId);

                connection.Execute("dbo.spTasks_RemoveById", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Task_Update(TaskModel taskToUpdate) {
            //(@WorkoutId, @OrderIndex, @Duration, @Title, @ColorR, @ColorG, @ColorB, @Song)
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@LookupId", taskToUpdate.Id);
                p.Add("@OrderIndex", taskToUpdate.OrderIndex);
                p.Add("@Duration", taskToUpdate.Duration);
                p.Add("@Title", taskToUpdate.Title);
                p.Add("@ColorR", taskToUpdate.Color[0]);
                p.Add("@ColorG", taskToUpdate.Color[1]);
                p.Add("@ColorB", taskToUpdate.Color[2]);
                p.Add("@Song", taskToUpdate.SongId);

                connection.Execute("dbo.spTasks_UpdateById", p, commandType: CommandType.StoredProcedure);
            }
        }
        public void Workout_Update(WorkoutModel workoutToUpdate) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("RepsAndSets"))) {
                var p = new DynamicParameters();
                p.Add("@LookupId", workoutToUpdate.Id);
                p.Add("@Title", workoutToUpdate.Title);

                connection.Execute("dbo.spWorkouts_UpdateById", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Tasks_RemoveByWorkout(int id) {
            throw new NotImplementedException(); // TODO Implement in sql
        }
    }
}
