using DevFlow.Controls;
using DevFlow.Wallpaper.ViewModels;
using System.Diagnostics;

namespace DevFlow.Wallpaper.Views
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
