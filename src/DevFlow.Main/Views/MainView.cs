using System.Windows;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
    public class MainView : Window
    {
        static MainView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainView), new FrameworkPropertyMetadata(typeof(MainView)));
        }

        public MainView()
        {
            DataContext = new MainViewModel();
            Width = 3840;
            Height = 2160;
        }
    }
}
