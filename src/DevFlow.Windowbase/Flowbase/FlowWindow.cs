using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace DevFlow.Windowbase.Flowbase
{
<<<<<<< HEAD
    public class FlowWindow : Window, IFlowUIElement
    {
        public FlowWindow()
        {
=======
	public class FlowWindow : Window
	{
		//public Action<Window> Closed { get; set; }

		public FlowWindow()
		{
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
			Loaded += FlowWindow_Loaded;
		}

		//#region UseMvvm

		//public IFlowElement UseViewModel(ObservableObject vm)
		//{
		//	DataContext = vm;
		//	return this;
		//}
		//#endregion

		#region OnDesignerMode

		protected virtual void OnDesignerMode()
		{

		}

		#endregion

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
	}
}
