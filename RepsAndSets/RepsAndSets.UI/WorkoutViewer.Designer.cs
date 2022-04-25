
namespace RepsAndSets.UI
{
    partial class WorkoutViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.WorkoutTitleLabel = new System.Windows.Forms.Label();
            this.workoutsDropDown = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.taskUILayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ActionButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.workoutTitleTextBox = new System.Windows.Forms.RichTextBox();
            this.addNewWorkout = new System.Windows.Forms.Button();
            this.deleteWorkoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorkoutTitleLabel
            // 
            this.WorkoutTitleLabel.AutoSize = true;
            this.WorkoutTitleLabel.Location = new System.Drawing.Point(31, 27);
            this.WorkoutTitleLabel.Name = "WorkoutTitleLabel";
            this.WorkoutTitleLabel.Size = new System.Drawing.Size(53, 13);
            this.WorkoutTitleLabel.TabIndex = 0;
            this.WorkoutTitleLabel.Text = "Workout";
            // 
            // workoutsDropDown
            // 
            this.workoutsDropDown.FormattingEnabled = true;
            this.workoutsDropDown.Location = new System.Drawing.Point(457, 27);
            this.workoutsDropDown.Name = "workoutsDropDown";
            this.workoutsDropDown.Size = new System.Drawing.Size(121, 21);
            this.workoutsDropDown.TabIndex = 1;
            // 
            // editButton
            // 
            this.editButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.editButton.Location = new System.Drawing.Point(34, 59);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(171, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // taskUILayoutPanel
            // 
            this.taskUILayoutPanel.AutoScroll = true;
            this.taskUILayoutPanel.Location = new System.Drawing.Point(274, 87);
            this.taskUILayoutPanel.Name = "taskUILayoutPanel";
            this.taskUILayoutPanel.Size = new System.Drawing.Size(200, 303);
            this.taskUILayoutPanel.TabIndex = 3;
            // 
            // ActionButton
            // 
            this.ActionButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ActionButton.Location = new System.Drawing.Point(339, 59);
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.Size = new System.Drawing.Size(75, 23);
            this.ActionButton.TabIndex = 4;
            this.ActionButton.Text = "PLAY";
            this.ActionButton.UseVisualStyleBackColor = true;
            this.ActionButton.Click += new System.EventHandler(this.ActionButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ResetButton.Location = new System.Drawing.Point(350, 22);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(54, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "RESET";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // workoutTitleTextBox
            // 
            this.workoutTitleTextBox.Location = new System.Drawing.Point(90, 27);
            this.workoutTitleTextBox.Name = "workoutTitleTextBox";
            this.workoutTitleTextBox.Size = new System.Drawing.Size(171, 18);
            this.workoutTitleTextBox.TabIndex = 7;
            this.workoutTitleTextBox.Text = "";
            this.workoutTitleTextBox.Visible = false;
            // 
            // addNewWorkout
            // 
            this.addNewWorkout.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addNewWorkout.Location = new System.Drawing.Point(457, 58);
            this.addNewWorkout.Name = "addNewWorkout";
            this.addNewWorkout.Size = new System.Drawing.Size(59, 23);
            this.addNewWorkout.TabIndex = 8;
            this.addNewWorkout.Text = "NEW";
            this.addNewWorkout.UseVisualStyleBackColor = true;
            this.addNewWorkout.Click += new System.EventHandler(this.addNewWorkout_Click);
            // 
            // deleteWorkoutButton
            // 
            this.deleteWorkoutButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.deleteWorkoutButton.Location = new System.Drawing.Point(522, 58);
            this.deleteWorkoutButton.Name = "deleteWorkoutButton";
            this.deleteWorkoutButton.Size = new System.Drawing.Size(56, 23);
            this.deleteWorkoutButton.TabIndex = 9;
            this.deleteWorkoutButton.Text = "DELETE";
            this.deleteWorkoutButton.UseVisualStyleBackColor = true;
            this.deleteWorkoutButton.Click += new System.EventHandler(this.deleteWorkoutButton_Click);
            // 
            // WorkoutViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteWorkoutButton);
            this.Controls.Add(this.addNewWorkout);
            this.Controls.Add(this.workoutTitleTextBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ActionButton);
            this.Controls.Add(this.taskUILayoutPanel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.workoutsDropDown);
            this.Controls.Add(this.WorkoutTitleLabel);
            this.Font = new System.Drawing.Font("Leelawadee UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "WorkoutViewer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WorkoutTitleLabel;
        private System.Windows.Forms.ComboBox workoutsDropDown;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.FlowLayoutPanel taskUILayoutPanel;
        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.RichTextBox workoutTitleTextBox;
        private System.Windows.Forms.Button addNewWorkout;
        private System.Windows.Forms.Button deleteWorkoutButton;
    }
}

