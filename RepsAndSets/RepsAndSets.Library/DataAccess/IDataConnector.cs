using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library.Models;

namespace RepsAndSets.Library.DataAccess
{
    public interface IDataConnector
    {
        List<TaskModel> Tasks_GetByWorkout(int workoutId);
        void Tasks_Insert(TaskModel newTask, WorkoutModel workout);
        UserModel User_GetByNickname(string nickname);
        void Workout_Insert(WorkoutModel newWorkout, UserModel userModel);
        void Tasks_RemoveById(int taskId);
        void Workout_Update(WorkoutModel workoutToUpdate);
        void Task_Update(TaskModel taskToUpdate);
        List<WorkoutModel> Workouts_GetByUser(int userId);
        void Workouts_RemoveById(int workoutId);
        void Tasks_RemoveByWorkout(int id);
    }
}