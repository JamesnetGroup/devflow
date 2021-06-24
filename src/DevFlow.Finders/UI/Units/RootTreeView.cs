using DevFlow.Finders.Local.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.UI.Units
{
	public class RootTreeView : TreeView
	{
		#region DefaultStyleKey

		static RootTreeView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RootTreeView), new FrameworkPropertyMetadata(typeof(RootTreeView)));
		}
		#endregion

		#region DependencyProperties

		public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(RootTreeView));
		#endregion

		#region SelectionCommand

		public ICommand SelectionCommand
		{
			get => (ICommand)GetValue(SelectionCommandProperty);
			set => SetValue(SelectionCommandProperty, value);
		}
		#endregion

		#region Constructor

		public RootTreeView()
		{
			// TODO James: 포커스 스크롤에 대한 연구(정확한 위치)가 필요하며 해결 후에는 옵션으로 기능을 제공합니다.
			//TreeViewItem tvitem = this.ItemContainerGenerator.ContainerFromItem(SelectedItem) as TreeViewItem;
			//tvitem?.BringIntoView();
		}
		#endregion

		#region OnPreviewMouseLeftButtonDown

		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseLeftButtonDown(e);

			if (e.OriginalSource is FrameworkElement fe && fe.DataContext is RootModel root)
			{
				SelectionCommand.Execute(root);
			}
		}
		#endregion
	}
}
