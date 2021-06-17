using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
{
	public class RootItemView : ListBox
	{
		#region DefaultStyleKey

		static RootItemView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RootItemView), new FrameworkPropertyMetadata(typeof(RootItemView)));
		}
		#endregion

		#region DependencyProperty

		public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(RootItemView));
		public static readonly DependencyProperty PreviewKeyDownCommandProperty = DependencyProperty.Register("PreviewKeyDownCommand", typeof(ICommand), typeof(RootItemView));
		#endregion

		#region DoubleClickCommand

		public ICommand DoubleClickCommand
		{
			get => (ICommand)GetValue(DoubleClickCommandProperty);
			set => SetValue(DoubleClickCommandProperty, value);
		}
		#endregion

		#region PreviewKeyDownCommand

		public ICommand PreviewKeyDownCommand
		{
			get => (ICommand)GetValue(PreviewKeyDownCommandProperty);
			set => SetValue(PreviewKeyDownCommandProperty, value);
		}
		#endregion

		#region OnMouseRightButtonUp

		protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
		{
			base.OnMouseRightButtonUp(e);

			//List<FileInfo> files;
			//ShellContextMenu ctx;

			//if (e.OriginalSource is FrameworkElement fe && fe.DataContext is FileData)
			//{
			//	files = new List<FileInfo>();
			//	ctx = new ShellContextMenu();

			//	// TODD James: Linq AddRange
			//	files.AddRange(from FileData file in SelectedItems select new FileInfo(file.FullName));
			//	ctx.ShowContextMenu(files.ToArray(), MousePosition.GetMousePosition(this));
			//}
		}
		#endregion

		#region OnMouseDoubleClick

		protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
			{
				DoubleClickCommand?.Execute(SelectedItem);
			}
		}
		#endregion

		#region OnPreviewKeyDown

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			base.OnPreviewKeyDown(e);
			PreviewKeyDownCommand?.Execute(e);
		}
		#endregion
	}
}
