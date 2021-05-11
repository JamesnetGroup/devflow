
using DevFlow.Controls;
using DevFlow.Tasker.ViewModels;

namespace DevFlow.Tasker.Views
{
    public partial class TaskView : View
    {
        #region . Constructor .

        public TaskView()
        {
            InitializeComponent();
            DataContext = new TaskViewModel();
        }
        #endregion
    }
}
