using System.Windows;
using DevFlow.LayoutSupport.Controls;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
    public class MainView : MainWindow
    {
        static MainView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainView), new FrameworkPropertyMetadata(typeof(MainView)));
        }

        public MainView()
        {
            //WindowStyle = WindowStyle.None;
            //AllowsTransparency = true;
            //         Topmost = true;
        }

        protected override void OnDesignerMode()
        {
            DataContext = new MainViewModel();
        }
	}
}