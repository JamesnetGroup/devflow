using DevFlow.Controls;
using DevFlow.History.ViewModels;
using System.Windows.Controls;

namespace DevFlow.History.Views
{
    /// <summary>
    /// HistoryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HistoryView : View
    {
        public HistoryView()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
    }
}
