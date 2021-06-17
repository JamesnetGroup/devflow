using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
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

		#region OnSelectedItemChanged
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);

			if (SelectedItem == null)
			{
				SelectionCommand.Execute(null);
			}
			else
			{
				SelectionCommand.Execute(SelectedItem);
			}
		}
		#endregion
	}
}
