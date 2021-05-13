using System.Windows;
using DevFlow.LayoutSupport;
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
            Width = 500;
            Height = 500;
        }

		protected override void OnDesignerMode()
		{
            DataContext = new MainViewModel();
        }
	}
}
