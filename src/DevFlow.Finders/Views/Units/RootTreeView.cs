using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
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

		#region ICommands

		public ICommand SelectionCommand
		{
			get => (ICommand)GetValue(SelectionCommandProperty);
			set => SetValue(SelectionCommandProperty, value);
		}
		#endregion

		#region Constructor

		public RootTreeView()
		{
		}
		#endregion

		#region OnSelectedItemChanged

		protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
		{
			base.OnSelectedItemChanged(e);

			if (SelectedItem == null)
			{
				SelectionCommand.Execute(null);
			}
			else if (e.NewValue.Equals(SelectedItem))
			{
				SelectionCommand.Execute(SelectedItem);

				// TODO James: 포커스 스크롤에 대한 연구(정확한 위치)가 필요하며 해결 후에는 옵션으로 기능을 제공합니다.
				//TreeViewItem tvitem = this.ItemContainerGenerator.ContainerFromItem(SelectedItem) as TreeViewItem;
				//tvitem?.BringIntoView();
			}
		}
		#endregion
	}
}
