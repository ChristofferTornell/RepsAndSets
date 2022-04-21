
namespace RepsAndSets.UI
{
    partial class AddNewTaskButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.NewTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewTaskButton
            // 
            this.NewTaskButton.Location = new System.Drawing.Point(3, 3);
            this.NewTaskButton.Name = "NewTaskButton";
            this.NewTaskButton.Size = new System.Drawing.Size(144, 144);
            this.NewTaskButton.TabIndex = 0;
            this.NewTaskButton.Text = "NEW TASK";
            this.NewTaskButton.UseVisualStyleBackColor = true;
            this.NewTaskButton.Click += new System.EventHandler(this.NewTaskButton_Click);
            // 
            // AddNewTaskButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NewTaskButton);
            this.Name = "AddNewTaskButton";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewTaskButton;
    }
}
