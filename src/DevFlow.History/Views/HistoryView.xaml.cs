using DevFlow.Controls;
using DevFlow.History.ViewModels;
using System.Diagnostics;

namespace DevFlow.History.Views
{
    public partial class HistoryView : View
    {
        #region . Constructor .

        public HistoryView()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
        #endregion
    }
}
