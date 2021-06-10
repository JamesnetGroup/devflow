using DevFlow.Data.Menu;
using DevFlow.Windowbase.Flowbase;
using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
	public class MainWindow : FlowWindow
	{
		public MainWindow()
		{
			WindowStyle = WindowStyle.None;
			AllowsTransparency = true;
			Topmost = true;
			Loaded += MainView_Loaded;

			PreviewMouseMove += MainView_MouseMove;
		}

		private void MainView_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
			{
				if ((e.OriginalSource as FrameworkElement).DataContext is MenuModel)
				{
					return;
				}
				DragMove();
			}
		}

		private void MainView_Loaded(object sender, RoutedEventArgs e)
		{
			double width = System.Windows.SystemParameters.WorkArea.Width;
			Left = (width - ActualWidth) / 2;
			Top = 0;
		}

		public override void Show(MenuModel menu)
		{
		}
	}
}
