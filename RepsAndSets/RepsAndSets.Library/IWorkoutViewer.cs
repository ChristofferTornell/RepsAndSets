using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library.Models;

namespace RepsAndSets.Library
{
    public interface IWorkoutViewer
    {
        void AddNewTask(TaskModel newTaskModel);
        void RemoveTask(TaskModel task);
        void OnClickActionButton();
        void EnterEditMode();
        void ExitEditMode();
        void ResumeTimer();
        void UpdatePlaymode(PlayMode targetPlayMode);
        void EndAllTimers();
        void ResetWorkout();
        void StartCurrentTask();
        void PauseCurrentTask();
        void EndCurrentTask();
        void DrawWorkout(WorkoutModel workoutModel);
        void HandleNoWorkoutExists();
        void UpdateWorkoutDropDown();
    }
}
