using DevFlow.History.ViewModels;
using System.Windows.Controls;

namespace DevFlow.History.Views
{
    /// <summary>
    /// HistoryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();

            var a = new test();
        }
    }

    public interface IUser
    {
        dynamic Data { get; set; }
    }
    public class test: IUser
    { 
        public string gg { get; set; }
    }
}
