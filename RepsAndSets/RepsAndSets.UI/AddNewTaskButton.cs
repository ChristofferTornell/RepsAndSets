using RepsAndSets.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepsAndSets.UI
{
    public partial class AddNewTaskButton : UserControl
    {
        public WorkoutViewer WorkoutViewer { get; set; }
        public AddNewTaskButton() {
            InitializeComponent();
        }

        private void NewTaskButton_Click(object sender, EventArgs e) {
            WorkoutLogic.OnClick_AddNewTaskButton();
        }
    }
}
