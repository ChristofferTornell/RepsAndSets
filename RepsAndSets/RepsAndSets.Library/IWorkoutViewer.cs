using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepsAndSets.Library
{
    public interface IWorkoutViewer
    {
        void AddNewTask();
        void RemoveTask(ITaskUI taskUI);
        void OnClickActionButton();
        void EnterEditMode();
        void ExitEditMode();
        void ResumeTimer();
        void ActivatePlayMode();
        void UpdatePlaymode(PlayMode targetPlayMode);
        void EndWorkout();
        void EndAllTimers();
        void ResetWorkout();
        void StartCurrentTask();
        void PauseCurrentTask();
    }
}
