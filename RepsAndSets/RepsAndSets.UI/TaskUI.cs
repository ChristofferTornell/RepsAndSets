using RepsAndSets.Library.Models;
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

namespace RepsAndSets.UI
{
    public partial class TaskUI : UserControl, ITaskUI
    {
        delegate void SetTextCallback(string text);
        public event EventHandler TaskTimerComplete;
        public IWorkoutViewer WorkoutViewer { get; set; }
        public TaskModel TaskModel { get; private set; }

        [Category("Custom Props")]
        public string Title { 
            get { 
                return _title; 
            } 
            set {
                _title = value;
                TitleLabel.Text = value;
            } 
        }
        private string _title;

        [Category("Custom Props")]
        public int SecondsRemaining
        {
            get {
                return _secondsRemaining;
            }
            set {
                _secondsRemaining = value;
                SetTimerText(_secondsRemaining.ToString());
            }
        }
        private int _secondsRemaining;
        public Timer Timer
        {
            get {
                return timer;
            }
        }
        public TaskUI(string title, IWorkoutViewer workoutViewer, TaskModel taskModel) {
            InitializeComponent();
            Title = title;
            WorkoutViewer = workoutViewer;
            TaskModel = taskModel;
            SecondsRemaining = TaskModel.Duration;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e) {
            SecondsRemaining--;
            if (SecondsRemaining <= 0) {
                TaskTimerComplete?.Invoke(this, e);
            }
        }
        private void SetTimerText(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.timerTextLabel.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetTimerText);
                this.Invoke(d, new object[] { text });
            } else {
                this.timerTextLabel.Text = text;
            }
        }
        public void StartTimer() {
            Timer.Start();
        }
        public void ResetTimer() {
            SecondsRemaining = TaskModel.Duration;
        }
        private void DeleteTaskButton_Click(object sender, EventArgs e) {
            WorkoutViewer.RemoveTask(this);
        }

        private void TimeRemainingLabel_Click(object sender, EventArgs e) {

        }

        public void EndTimer() {
            Timer.Stop();
        }

        public void EnterEditMode() {
            timerTextLabel.Hide();
            timerTextBox.Show();
        }
        public void ExitEditMode() {
            timerTextBox.Hide();
            timerTextLabel.Show();
        }

        private void timerTextBox_TextChanged(object sender, EventArgs e) {
            // Adds colon if minute is complete and moves cursor ahead of colon
            if (MinuteTextComplete()) {
                bool moveSelectionAfterSeparator = false;
                if (!timerTextBox.Text.Contains(':')) {
                    timerTextBox.Text += ':';
                    moveSelectionAfterSeparator = true;
                } else if (timerTextBox.SelectionStart == 2) {
                    moveSelectionAfterSeparator = true;
                }
                if (moveSelectionAfterSeparator) {
                    timerTextBox.Select(3, 0);
                }
            }
            CutExcessiveDigits();
        }

        private void CutExcessiveDigits() {
            if (timerTextBox.Text.Contains(':')) {
                string[] split = timerTextBox.Text.Split(':');
                // Cuts excessive minutes
                if (split.Length > 0 && split[0].Length >= 2) {

                    string newTimerTextMinute = split[0][0] + split[0][1] + ":";
                    string newTimerTextSeconds = string.Empty;
                    if (split.Length > 1) {
                        newTimerTextSeconds = split[1];
                    }
                    SetTimerText(newTimerTextMinute + newTimerTextSeconds);
                }
                // Cuts excessive seconds
                if (split.Length > 1 && split[1].Length >= 2) {

                    string newTimerTextMinute = split[0] + ":";
                    string newTimerTextSeconds = string.Empty + split[1][0] + split[1][1];
                    SetTimerText(newTimerTextMinute + newTimerTextSeconds);
                }
            }
        }

        private bool MinuteTextComplete() {
            bool output = false;
            if (timerTextBox.Text.Contains(':')) {
                string[] split = timerTextBox.Text.Split(':');

                // The minute text is regarded complete if the left hand side has 2 digits.
                if (split[0].Length == 2) {
                    output = true;
                }

                // The minute text is also regarded complete if there is no separator but the total text has 2 digits.
            } else if (timerTextBox.Text.Length >= 2) {
                output = true;
            }
            return output;
        }

        private void timerTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            bool isHandled = false;
            if (RestrictTimerTextBoxKeyPress(e)) {
                isHandled = true;
            }
            e.Handled = isHandled;
            
        }

        private bool RestrictTimerTextBoxKeyPress(KeyPressEventArgs e) {
            bool output = false;
            if (timerTextBox.Text.Contains(':')) {
                string[] split = timerTextBox.Text.Split(':');
                // If the cursor is on the minute text and there already are 2 minute digits, 
                // we don't want to let the user enter more.
                if (split.Length > 0 && split[0].Length >= 2 && timerTextBox.SelectionStart < 3) {
                    output = true;
                }

                // If the cursor is on the seconds text and there already are 2 minute digits, 
                // we don't want to let the user enter more.
                if (split.Length > 1 && split[1].Length >= 2 && timerTextBox.SelectionStart >= 3) {
                    output = true;
                }
            }
            if (!char.IsDigit(e.KeyChar)) {
                output = true;
            }
            return output;
        }

        private void timerTextBox_Leave(object sender, EventArgs e) {

        }

        private void timerTextBox_KeyDown(object sender, KeyEventArgs e) {
            //if (e.KeyCode == Keys.Back) {
            //    if (timerTextBox.SelectedText.Contains(':')) {
            //        int colonIndex = timerTextBox.Text.IndexOf(':');
            //        if (colonIndex > timerTextBox.SelectionStart) {
            //            int selectedEnd = timerTextBox.SelectionStart + timerTextBox.SelectedText.Length;
            //            timerTextBox.Select(selectedEnd, selectedEnd);
            //        } else if (colonIndex < timerTextBox.SelectionStart){
            //            timerTextBox.Select(timerTextBox.SelectionStart, timerTextBox.SelectionStart);

            //        } else {
                        
            //        }
            //    }
            //}
            if (e.KeyCode == Keys.Back && timerTextBox.SelectionStart == 3) {
                timerTextBox.Select(2, 0);
            }
        }
    }
}
