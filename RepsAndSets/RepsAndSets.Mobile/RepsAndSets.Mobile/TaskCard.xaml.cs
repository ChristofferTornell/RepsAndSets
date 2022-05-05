using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RepsAndSets.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskCard : ContentView
    {
        public TaskCard() {
            InitializeComponent();
        }
    }
}