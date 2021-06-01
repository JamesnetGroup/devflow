using DevFlow.Windowbase.Flowcore;
using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowWindow : Window, IFlowElement
    {
        public FlowWindow()
        {
			Loaded += FlowWindow_Loaded;
        }

        #region UseMvvm

        public IFlowElement UseMvvm(ObservableObject vm)
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
