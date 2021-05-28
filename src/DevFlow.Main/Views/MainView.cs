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
			WindowStyle = WindowStyle.None;
			AllowsTransparency = true;
			Topmost = true;
			Loaded += MainView_Loaded;

			PreviewMouseMove += MainView_MouseMove;
		}

		private void MainView_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
            //if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            //{
            //    this.DragMove();
            //}
		}

		private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            var width = System.Windows.SystemParameters.WorkArea.Width;
            Left = (width - ActualWidth) / 2;
            Top = 0;
        }

		protected override void OnDesignerMode()
        {
            DataContext = new MainViewModel();
        }
	}
}