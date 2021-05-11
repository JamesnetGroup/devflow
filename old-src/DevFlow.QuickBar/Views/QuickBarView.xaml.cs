using DevFlow.Controls;
using DevFlow.QuickBar.ViewModels;

namespace DevFlow.QuickBar.Views
{
    public partial class QuickBarView : View
    {
        public QuickBarView()
        {
            InitializeComponent();
            DataContext = new QuickBarViewModel();
        }
    }
}
