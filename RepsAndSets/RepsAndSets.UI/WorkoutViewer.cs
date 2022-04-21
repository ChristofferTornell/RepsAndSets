using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepsAndSets.Library;
using RepsAndSets.Library.Constants;
using RepsAndSets.Library.Models;

namespace RepsAndSets.UI
{
    public partial class WorkoutViewer : Form, IWorkoutViewer
    {
        AddNewTaskButton addNewTaskButton;
        List<TaskUI> taskUIs = new List<TaskUI>();
        List<TaskModel> tasks = new List<TaskModel>();
        int currentActiveTimer;

        PlayMode currentPlayMode;
        int storedTimerDuration;

        delegate void SetTextCallback(string text);
        delegate void SetBooleanCallback(bool boolean);

        public WorkoutViewer() {
            InitializeComponent();

            addNewTaskButton = new AddNewTaskButton() {
                WorkoutViewer = this
            };

            if (WorkoutsExists()) {
                DrawWorkout(null);
            } else {
                DrawNewWorkout();
            }
        }
        private void DrawNewWorkout() {
            foreach (TaskUI task in taskUIs) {
                task.Hide();
            }
            AddNewTask();

            // Enable edit mode

        }

        public void AddNewTask() {
            TaskModel newTaskModel = new TaskModel();
            tasks.Add(newTaskModel);

            TaskUI newTaskUI = new TaskUI(TaskModelDefaults.TaskName + tasks.Count, this, newTaskModel);

            taskUILayoutPanel.Controls.Add(newTaskUI);
            taskUIs.Add(newTaskUI);

            // Puts the task button back at the bottom of the layout panel
            if (taskUILayoutPanel.Controls.Contains(addNewTaskButton)) {
                taskUILayoutPanel.Controls.Remove(addNewTaskButton);
            }
            taskUILayoutPanel.Controls.Add(addNewTaskButton);
        }

        public void RemoveTask(TaskUI taskUI) {
            taskUILayoutPanel.Controls.Remove(taskUI);
            taskUIs.Remove(taskUI);
            tasks.Remove(taskUI.TaskModel);

        }

        private bool WorkoutsExists() {
            return false;
        }

        private void WorkoutViewer_Load(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void taskUI1_Load(object sender, EventArgs e) {

        }
        private void DrawWorkout(WorkoutModel workout) { 
        
        }

        private void ActionButton_Click(object sender, EventArgs e) {
            OnClickActionButton();
        }

        private void OnClickActionButton() {
            switch (currentPlayMode) {
                case PlayMode.Idle:
                    ActivatePlayMode();
                    UpdatePlaymode(PlayMode.Playing);
                    break;
                case PlayMode.Playing:
                    PauseCurrentTask();
                    UpdatePlaymode(PlayMode.Paused);
                    break;
                case PlayMode.Paused:
                    ResumeTimer();
                    UpdatePlaymode(PlayMode.Playing);
                    break;
                case PlayMode.Edit:
                    break;
                default:
                    break;
            }
        }

        private void EnterEditMode() {
            taskUIs.ForEach(x => x.EnterEditMode());
        }
        private void ExitEditMode() {
            // TODO Save Changes
            taskUIs.ForEach(x => x.ExitEditMode());
        }

        private void ResumeTimer() {
            TaskUI currentTask = taskUIs[currentActiveTimer];
            currentTask.TaskTimerComplete += Timer_Ended;
            currentTask.Timer.Start();
            currentTask.Timer.Interval = storedTimerDuration;
        }

        private void ActivatePlayMode() {
            UpdatePlaymode(PlayMode.Playing);
            StartCurrentTask();
        }

        private void UpdatePlaymode(PlayMode targetPlayMode) {
            currentPlayMode = targetPlayMode;
            switch (currentPlayMode) {
                case PlayMode.Idle:
                    SetEditButtonText("Edit");
                    SetActionButtonText("PLAY");
                    ShowActionButton(true);
                    break;
                case PlayMode.Playing:
                    SetActionButtonText("PAUSE");
                    ShowActionButton(true);
                    break;
                case PlayMode.Paused:
                    SetActionButtonText("RESUME");
                    ShowActionButton(true);
                    break;
                case PlayMode.Edit:
                    ShowActionButton(false);
                    SetEditButtonText("Exit Edit Mode"); // TODO add save changes button
                    SetActionButtonText("RESUME");
                    EnterEditMode();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetActionButtonText(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ActionButton.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetActionButtonText);
                this.Invoke(d, new object[] { text });
            } else {
                this.ActionButton.Text = text;
            }
        }
        private void SetEditButtonText(string text) {
            if (this.editButton.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetEditButtonText);
                this.Invoke(d, new object[] { text });
            } else {
                this.editButton.Text = text;
            }
        }

        private void ShowActionButton(bool shouldShow) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ActionButton.InvokeRequired) {
                SetBooleanCallback d = new SetBooleanCallback(ShowActionButton);
                this.Invoke(d, new object[] { shouldShow });
            } else {
                if (shouldShow) {
                    ActionButton.Show();
                } else {
                    ActionButton.Hide();
                }
            }
        }

        private void EndWorkout() {
            ResetWorkout();
            EndAllTimers();
            UpdatePlaymode(PlayMode.Idle);
        }

        private void EndAllTimers() {
            taskUIs.ForEach(x => x.EndTimer());
        }

        private void ResetWorkout() {
            EndCurrentTask();
            taskUIs.ForEach(x => x.ResetTimer());
            currentActiveTimer = 0;
        }

        private void EndCurrentTask() {
            TaskUI currentTask = taskUIs[currentActiveTimer];
            currentTask.TaskTimerComplete -= Timer_Ended;
            currentTask.EndTimer();
        }

        private void Timer_Ended(object sender, EventArgs e) {
            EndCurrentTask();
            if (currentActiveTimer+1 >= tasks.Count) {
                EndWorkout();
                return;
            }
            currentActiveTimer++;
            StartCurrentTask();
        }

        private void StartCurrentTask() {
            TaskUI currentTask = taskUIs[currentActiveTimer];
            currentTask.StartTimer();
            currentTask.TaskTimerComplete += Timer_Ended;
        }

        private void PauseCurrentTask() {
            TaskUI currentTask = taskUIs[currentActiveTimer];
            storedTimerDuration = currentTask.Timer.Interval;
            currentTask.Timer.Stop();
            currentTask.TaskTimerComplete -= Timer_Ended;
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            ResetWorkout();
            if (currentPlayMode == PlayMode.Playing) {
                StartCurrentTask();
            }
        }

        private void editButton_Click(object sender, EventArgs e) {
            if (currentPlayMode != PlayMode.Edit) {
                ResetWorkout();
                UpdatePlaymode(PlayMode.Edit);
            } else {
                UpdatePlaymode(PlayMode.Idle);
                ExitEditMode();
            }
        }
    }
}
