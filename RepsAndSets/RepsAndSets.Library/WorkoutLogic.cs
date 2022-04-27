using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library.Models;
using RepsAndSets.Library.Constants;

namespace RepsAndSets.Library
{
    public static class WorkoutLogic
    {
        public static List<WorkoutModel> Workouts
        {
            get {
                return GlobalConfig.LoggedInUser.Workouts;
            }
        }
        public static List<TaskModel> CurrentTasks = new List<TaskModel>();
        public static WorkoutModel CurrentWorkout;
        public static PlayMode CurrentPlayMode;
        public static int currentActiveTimer;


        public static void OnClick_AddNewWorkoutButton(WorkoutModel currentWorkout) {
            SaveExistingWorkout(currentWorkout);
            DrawNewWorkout();
        }

        public static void OnClick_AddNewTaskButton() {
            AddAndSaveNewTask();
        }

        public static void AddAndSaveNewTask() {
            TaskModel newTaskModel = new TaskModel();
            CurrentTasks.Add(newTaskModel);
            newTaskModel.Title = TaskModelDefaults.TaskName + CurrentTasks.IndexOf(newTaskModel);

            GlobalConfig.WorkoutViewer.AddNewTask(newTaskModel);
            newTaskModel.OrderIndex = CurrentTasks.IndexOf(newTaskModel);
            CurrentWorkout.Tasks.Add(newTaskModel);
            GlobalConfig.Connector.Tasks_Insert(newTaskModel, CurrentWorkout);
        }

        public static void DeleteWorkout(WorkoutModel currentWorkout) {
            GlobalConfig.Connector.Tasks_RemoveByWorkout(currentWorkout.Id);
            GlobalConfig.Connector.Workouts_RemoveById(currentWorkout.Id);
            Workouts.Remove(currentWorkout);
            if (Workouts.Count > 0) {
                GlobalConfig.WorkoutViewer.DrawWorkout(Workouts.LastElement());
            } else {
                GlobalConfig.WorkoutViewer.HandleNoWorkoutExists();
            }
        }
        public static void SaveNewWorkout(WorkoutModel newWorkout) {
            GlobalConfig.Connector.Workout_Insert(newWorkout, GlobalConfig.LoggedInUser);
            GlobalConfig.LoggedInUser.Workouts.Add(newWorkout);
        }

        public static void SaveExistingWorkout(WorkoutModel existingWorkout) {
            foreach (TaskModel task in existingWorkout.Tasks) {
                GlobalConfig.Connector.Task_Update(task);
            }
            GlobalConfig.Connector.Workout_Update(existingWorkout);
        }

        public static void OnClickActionButton() {
            switch (CurrentPlayMode) {
                case PlayMode.Idle:
                    GlobalConfig.WorkoutViewer.StartCurrentTask();
                    UpdatePlaymode(PlayMode.Playing);
                    break;
                case PlayMode.Playing:
                    GlobalConfig.WorkoutViewer.PauseCurrentTask();
                    UpdatePlaymode(PlayMode.Paused);
                    break;
                case PlayMode.Paused:
                    GlobalConfig.WorkoutViewer.ResumeTimer();
                    UpdatePlaymode(PlayMode.Playing);
                    break;
                case PlayMode.Edit:
                    break;
                default:
                    break;
            }
        }

        public static void RemoveTask(TaskModel taskModel) {
            CurrentTasks.Remove(taskModel);
            GlobalConfig.WorkoutViewer.RemoveTask(taskModel);
            GlobalConfig.Connector.Tasks_RemoveById(taskModel.Id);

        }

        public static void OnEditButtonClick() {
            if (CurrentPlayMode != PlayMode.Edit) {
                GlobalConfig.WorkoutViewer.ResetWorkout();
                UpdatePlaymode(PlayMode.Edit);
            } else {
                UpdatePlaymode(PlayMode.Idle);
                GlobalConfig.WorkoutViewer.ExitEditMode();
            }
        }

        public static void OnRestartButtonClick() {
            GlobalConfig.WorkoutViewer.ResetWorkout();
            if (CurrentPlayMode == PlayMode.Playing) {
                GlobalConfig.WorkoutViewer.StartCurrentTask();
            }
        }

        public static void OnCurrentTaskTimerEnded() {
            GlobalConfig.WorkoutViewer.EndCurrentTask();
            if (currentActiveTimer + 1 >= CurrentTasks.Count) {
                EndWorkout();
                return;
            }
            currentActiveTimer++;
            GlobalConfig.WorkoutViewer.StartCurrentTask();
        }

        private static void EndWorkout() {
            GlobalConfig.WorkoutViewer.ResetWorkout();
            GlobalConfig.WorkoutViewer.EndAllTimers();
            UpdatePlaymode(PlayMode.Idle);
        }
        public static void RequestDrawWorkout(WorkoutModel workout) {
            CurrentTasks = new List<TaskModel>();
            CurrentWorkout = workout;
            GlobalConfig.WorkoutViewer.DrawWorkout(workout);

        }
        public static void DrawNewWorkout() {
            WorkoutModel newWorkout = new WorkoutModel() { Title = WorkoutModelDefaults.WorkoutName };
            RequestDrawWorkout(newWorkout);
            SaveNewWorkout(newWorkout);
            AddAndSaveNewTask();
            GlobalConfig.WorkoutViewer.UpdateWorkoutDropDown();
            UpdatePlaymode(PlayMode.Edit);
        }

        public static void UpdatePlaymode(PlayMode targetPlayMode) {
            CurrentPlayMode = targetPlayMode;
            GlobalConfig.WorkoutViewer.UpdatePlaymode(targetPlayMode);
        }
    }
}
