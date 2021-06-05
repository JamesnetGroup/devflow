using DevFlow.Data.Menu;
using DevFlow.Windowbase.Flowcore;
using DevFlow.Windowbase.Mvvm;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
<<<<<<< HEAD
    public class FlowView : ContentControl, IFlowUIElement
    {
=======
	public class FlowView : ContentControl, IFlowElement
	{
		public Window Window { get; protected set; }
		public Action<Window> Closed { get; set; }

		public virtual void Show(MenuModel menu)
		{

		}

>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
		#region DependencyProperty

		public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(FlowView));
		#endregion

		#region MouseDownCommand

		public ICommand MouseDownCommand
		{
			get => (ICommand)GetValue(MouseDownCommandProperty);
			set => SetValue(MouseDownCommandProperty, value);
		}
		#endregion

		#region Constructor

		public FlowView()
		{
			Loaded += FlowView_Loaded;
		}
		#endregion

		#region UseMvvm

		public IFlowElement UseViewModel(ObservableObject vm)
		{
			DataContext = vm;
			return this;
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
