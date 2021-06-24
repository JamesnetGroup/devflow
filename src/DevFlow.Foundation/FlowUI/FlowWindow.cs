using DevFlow.Data.Menu;
using DevFlow.Foundation.Flowcore;
using DevFlow.Foundation.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace DevFlow.Foundation.Flowbase
{
	public abstract class FlowWindow : Window, IFlowElement
	{
		#region Constructor

		public FlowWindow()
		{
			Loaded += FlowWindow_Loaded;
		}
		#endregion

		#region UseMvvm

		public IFlowElement UseViewModel(ObservableObject vm)
		{
			DataContext = vm;
			return this;
		}
		#endregion

		#region Show

		public abstract void OnShow(MenuModel menu);
		#endregion

		#region OnDesignerMode

		protected virtual void OnDesignerMode()
		{

		}

		#endregion

		#region Loaded

		private void FlowWindow_Loaded(object sender, RoutedEventArgs e)
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
