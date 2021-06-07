using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
{
	public class RootTreeView : TreeView
	{
		static RootTreeView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RootTreeView), new FrameworkPropertyMetadata(typeof(RootTreeView)));
		}

		public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(RootTreeView));
    
		public ICommand SelectionCommand
		{
			get { return (ICommand)this.GetValue(SelectionCommandProperty); }
			set { this.SetValue(SelectionCommandProperty, value); }
		}

		public RootTreeView()
		{
			SelectedItemChanged += RootTreeView_SelectedItemChanged;
		}

		private void RootTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			if (SelectedItem == null)
			{
				SelectionCommand.Execute(null);
			}
			else if (e.OriginalSource is FrameworkElement fe && fe.DataContext.Equals(SelectedItem))
			{
				SelectionCommand.Execute(SelectedItem);
			}
		}
	}
}
