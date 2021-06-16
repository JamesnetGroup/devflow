using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Finders.Views
{
	public class RootDropBox : ComboBox
	{
		#region DefaultStyleKey

		static RootDropBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RootDropBox), new FrameworkPropertyMetadata(typeof(RootDropBox)));
		}
        #endregion

        #region DependencyProperties

        public static readonly DependencyProperty SelectionCommandProperty = DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(RootDropBox));
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
