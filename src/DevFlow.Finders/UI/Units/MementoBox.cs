using DevFlow.Finders.Local.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.UI.Units
{
	public class MementoBox : ComboBox
	{
		#region DefaultStyleKey

		static MementoBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MementoBox), new FrameworkPropertyMetadata(typeof(MementoBox)));
		}
		#endregion

		#region DependencyProperties

		public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(MementoBox));
		#endregion

		#region ICommands

		public ICommand SelectionCommand
		{
			get => (ICommand)GetValue(SelectionCommandProperty);
			set => SetValue(SelectionCommandProperty, value);
		}
		#endregion

		#region OnPreviewMouseLeftButtonDown
		protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseLeftButtonUp(e);

			if (IsDropDownOpen && e.OriginalSource is FrameworkElement fe && fe.DataContext is FileModel root)
			{
				SelectionCommand.Execute(root);
			}
		}
		#endregion
	}
}
