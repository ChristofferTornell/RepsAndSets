using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepsAndSets.Library.Models;

namespace RepsAndSets.Library
{
    public interface ITaskUI
    {
        void StartTimer();
        void ResetTimer();
        void EndTimer();
        void EnterEditMode();
        void ExitEditMode();
        TaskModel GetTaskModel();
    }
}
