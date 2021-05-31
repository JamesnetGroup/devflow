using DevFlow.Windowbase.Flowcore;
using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowView : ContentControl, IFlowUIElement
    {
		Window _window;

		#region DependencyProperty

		public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(FlowView));
		#endregion

		#region MouseDownCommand

		public ICommand MouseDownCommand
		{
			get { return (ICommand)this.GetValue(MouseDownCommandProperty); }
			set { this.SetValue(MouseDownCommandProperty, value); }
		}
		#endregion

		#region Constructor

		public FlowView()
        {
			Loaded += FlowView_Loaded;
        }
		#endregion

		#region UseMvvm

		public IFlowUIElement UseMvvm(ObservableObject vm)
        {
            DataContext = vm;
            return this;
        }
		#endregion

		#region Show
		public void Show()
		{
			if (_window == null)
			{
				_window = new Window();
				_window.Content = this;
				_window.AllowsTransparency = true;
				_window.WindowStyle = WindowStyle.None;
				_window.SizeToContent = SizeToContent.WidthAndHeight;
			}
			_window.Show();
		}
		#endregion

		#region OnDesignerMode

		protected virtual void OnDesignerMode()
        {

        }
		#endregion

		#region Loaded

		private void FlowView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                OnDesignerMode();
            }

            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
		#endregion
	}
}
