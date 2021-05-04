using DevFlow.Controls;
using DevFlow.History.ViewModels;
using System.Windows.Controls;

namespace DevFlow.History.Views
{
    public partial class HistoryView : View
    {
        public HistoryView()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
    }
}
