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

        int storedTimerDuration;

        delegate void SetTextCallback(string text);
        delegate void SetBooleanCallback(bool boolean);

        public WorkoutViewer() {
            InitializeComponent();
        }

        public void Initialize() {
            addNewTaskButton = new AddNewTaskButton() {
                WorkoutViewer = this
            };

            //TODO LOGIN LOGIC

            UpdateWorkoutDropDown();

            if (WorkoutLogic.Workouts.Count > 0) {
                WorkoutLogic.RequestDrawWorkout(WorkoutLogic.Workouts[0]);
            } else {
                HandleNoWorkoutExists();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            WorkoutLogic.OnRestartButtonClick();
        }

        private void editButton_Click(object sender, EventArgs e) {
            WorkoutLogic.OnEditButtonClick();
        }


        public void HandleNoWorkoutExists() {
            WorkoutLogic.DrawNewWorkout();
        }

        /// <summary>
        /// Draws the input workout on the screen. NOTE! Should only be called via Worklogic.RequestDrawWorkout.
        /// </summary>
        /// <param name="workout"></param>
        public void DrawWorkout(WorkoutModel workout) {
            taskUIs.Clear();
            taskUILayoutPanel.Controls.Clear();
            taskUILayoutPanel.Hide();
            taskUILayoutPanel.Show();
            for (int i = 0; i < workout.Tasks.Count; i++) {
                TaskModel task = workout.Tasks[i];
                AddTaskUI(task);
            }
            if (WorkoutLogic.CurrentPlayMode == PlayMode.Edit) {
                PutNewTaskButtonAtBottom();
            }
            WorkoutTitleLabel.Text = workout.Title;
            workoutTitleTextBox.Text = workout.Title;
        }

        private TaskUI AddTaskUI(TaskModel task) {
            TaskUI newTaskUI = new TaskUI(task.Title, this, task);
            taskUIs.Add(newTaskUI);
            taskUILayoutPanel.Controls.Add(newTaskUI);
            return newTaskUI;
        }

        public void UpdateWorkoutDropDown() {
            workoutsDropDown.DataSource = null;
            workoutsDropDown.DataSource = GlobalConfig.LoggedInUser.Workouts;
            workoutsDropDown.DisplayMember = "Title";
        }

        public void AddNewTask(TaskModel newTaskModel) {
            TaskUI newTaskUI = AddTaskUI(newTaskModel);
            if (WorkoutLogic.CurrentPlayMode == PlayMode.Edit) {
                newTaskUI.EnterEditMode();

                PutNewTaskButtonAtBottom();
            }
        }

        private void PutNewTaskButtonAtBottom() {
            // Puts the task button back at the bottom of the layout panel
            if (taskUILayoutPanel.Controls.Contains(addNewTaskButton)) {
                taskUILayoutPanel.Controls.Remove(addNewTaskButton);
            }
            taskUILayoutPanel.Controls.Add(addNewTaskButton);
        }

        private void ActionButton_Click(object sender, EventArgs e) {
            OnClickActionButton();
        }

        public void EnterEditMode() {
            ShowActionButton(false);
            SetEditButtonText("Exit Edit Mode"); // TODO add save changes button
            SetActionButtonText("RESUME");

            // Toggles workout title
            WorkoutTitleLabel.Hide();
            workoutTitleTextBox.Text = WorkoutTitleLabel.Text;
            workoutTitleTextBox.Show();

            taskUIs.ForEach(x => x.EnterEditMode());
            taskUILayoutPanel.Controls.Add(addNewTaskButton);
        }
        public void ExitEditMode() {

            // Toggles workout title
            workoutTitleTextBox.Hide();
            WorkoutLogic.CurrentWorkout.Title = workoutTitleTextBox.Text;
            SetWorkoutTitleText(WorkoutLogic.CurrentWorkout.Title);
            WorkoutTitleLabel.Show();

            UpdateWorkoutDropDown();
            WorkoutLogic.SaveExistingWorkout(WorkoutLogic.CurrentWorkout);

            taskUIs.ForEach(x => x.ExitEditMode());
            if (taskUILayoutPanel.Controls.Contains(addNewTaskButton)) {
                taskUILayoutPanel.Controls.Remove(addNewTaskButton);
            }
        }

        public void ResumeTimer() {
            TaskUI currentTask = taskUIs[WorkoutLogic.currentActiveTimer];
            currentTask.TaskTimerComplete += Timer_Ended;
            currentTask.Timer.Start();
            currentTask.Timer.Interval = storedTimerDuration;
        }

        private void ShowActionButton(bool shouldShow) {
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

        public void EndAllTimers() {
            taskUIs.ForEach(x => x.EndTimer());
        }

        public void ResetWorkout() {
            EndCurrentTask();
            taskUIs.ForEach(x => x.ResetTimer());
            WorkoutLogic.currentActiveTimer = 0;
        }

        public void EndCurrentTask() {
            TaskUI currentTask = taskUIs[WorkoutLogic.currentActiveTimer];
            currentTask.TaskTimerComplete -= Timer_Ended;
            currentTask.EndTimer();
        }

        private void Timer_Ended(object sender, EventArgs e) {
            WorkoutLogic.OnCurrentTaskTimerEnded();

        }

        public void StartCurrentTask() {
            TaskUI currentTask = taskUIs[WorkoutLogic.currentActiveTimer];
            currentTask.StartTimer();
            currentTask.TaskTimerComplete += Timer_Ended;
        }

        public void PauseCurrentTask() {
            TaskUI currentTask = taskUIs[WorkoutLogic.currentActiveTimer];
            storedTimerDuration = currentTask.Timer.Interval;
            currentTask.Timer.Stop();
            currentTask.TaskTimerComplete -= Timer_Ended;
        }

        public void RemoveTask(TaskModel task) {
            TaskUI taskUI = taskUIs[task.OrderIndex];
            taskUILayoutPanel.Controls.Remove(taskUI.GetUserControl());
            taskUIs.Remove(taskUI);
        }

        public void OnClickActionButton() {
            WorkoutLogic.OnClickActionButton();
        }

        private void addNewWorkout_Click(object sender, EventArgs e) {
            WorkoutLogic.OnClick_AddNewWorkoutButton(WorkoutLogic.CurrentWorkout);

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
        private void SetWorkoutTitleText(string text) {
            if (this.WorkoutTitleLabel.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetWorkoutTitleText);
                this.Invoke(d, new object[] { text });
            } else {
                this.WorkoutTitleLabel.Text = text;
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

        private void deleteWorkoutButton_Click(object sender, EventArgs e) {
            WorkoutLogic.DeleteWorkout(WorkoutLogic.CurrentWorkout);
            UpdateWorkoutDropDown();
        }
        public void UpdatePlaymode(PlayMode currentPlaymode) {
            switch (currentPlaymode) {
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
                    EnterEditMode();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void workoutsDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (workoutsDropDown.SelectedIndex == -1) {
                return;
            }
            WorkoutLogic.RequestDrawWorkout(WorkoutLogic.Workouts[workoutsDropDown.SelectedIndex]);
        }
        public void WorkoutsDropDownSelect(int selectIndex) {
            workoutsDropDown.SelectedIndex = selectIndex;
            // This will in turn call the workoutsDropDown_SelectedIndexChanged method,
            // requesting to draw the layout at the selected index

        }
    }
}
