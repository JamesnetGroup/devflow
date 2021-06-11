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
			}
		}
		#endregion
	}
}
