using DevFlow.Data.Menu;
using DevFlow.Windowbase.Flowbase;
using System.Windows;

namespace DevFlow.Controls.Primitives
{
	public class SystemWindow : FlowWindow
	{
		#region Constructor

		public SystemWindow()
		{
			WindowStyle = WindowStyle.None;
			AllowsTransparency = true;
			Topmost = true;
			
			Loaded += WindowLoaded;
			PreviewMouseDown += WindowDragMove;
		}
		#endregion

		#region WindowDragMove

		private void WindowDragMove(object sender, System.Windows.Input.MouseEventArgs e)
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
		#endregion

		#region WindowLoaded

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			double width = System.Windows.SystemParameters.WorkArea.Width;
			Left = (width - ActualWidth) / 2;
			Top = 0;
		}
		#endregion

		#region OnShow

		public override void OnShow(MenuModel menu)
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}
}
