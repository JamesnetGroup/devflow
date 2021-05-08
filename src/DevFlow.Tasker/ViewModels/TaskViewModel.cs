using DevFlow.Tasker.Local.Models;
using DevFlow.Tasker.Local.WinApi;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Tasker.ViewModels
{
    public class TaskViewModel : ObservableObject
    {
        public List<TaskProgramModel> Programs { get; set; } 

        public TaskViewModel()
        {
            Programs = EnumWindows.Instance.GetTaskPrograms();
        }
    }
}
