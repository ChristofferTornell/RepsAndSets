
namespace RepsAndSets.UI
{
    partial class TaskUI
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
            this.components = new System.ComponentModel.Container();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerTextBox = new System.Windows.Forms.RichTextBox();
            this.timerTextLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Location = new System.Drawing.Point(86, 27);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(65, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "<TitleLabel>";
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.BackgroundImage = global::RepsAndSets.UI.Properties.Resources.x_red;
            this.DeleteTaskButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteTaskButton.Location = new System.Drawing.Point(165, 0);
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(25, 25);
            this.DeleteTaskButton.TabIndex = 2;
            this.DeleteTaskButton.UseVisualStyleBackColor = true;
            this.DeleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.timerTextBox);
            this.panel1.Controls.Add(this.timerTextLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 65);
            this.panel1.TabIndex = 3;
            // 
            // timerTextBox
            // 
            this.timerTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.timerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.timerTextBox.Location = new System.Drawing.Point(22, 27);
            this.timerTextBox.Multiline = false;
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.timerTextBox.Size = new System.Drawing.Size(58, 13);
            this.timerTextBox.TabIndex = 1;
            this.timerTextBox.Text = "";
            this.timerTextBox.Visible = false;
            this.timerTextBox.TextChanged += new System.EventHandler(this.timerTextBox_TextChanged);
            this.timerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timerTextBox_KeyDown);
            this.timerTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timerTextBox_KeyPress);
            this.timerTextBox.Leave += new System.EventHandler(this.timerTextBox_Leave);
            // 
            // timerTextLabel
            // 
            this.timerTextLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.timerTextLabel.Location = new System.Drawing.Point(19, 27);
            this.timerTextLabel.Name = "timerTextLabel";
            this.timerTextLabel.Size = new System.Drawing.Size(35, 13);
            this.timerTextLabel.TabIndex = 0;
            this.timerTextLabel.Text = "label1";
            // 
            // TaskUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteTaskButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.panel1);
            this.Name = "TaskUI";
            this.Size = new System.Drawing.Size(188, 65);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button DeleteTaskButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerTextLabel;
        private System.Windows.Forms.RichTextBox timerTextBox;
    }
}
