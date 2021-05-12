using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowView : UserControl
    {
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

        public FlowView()
        {
			Loaded += FlowView_Loaded;
        }

		private void FlowView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                OnDesignMode();
            }

            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }

        protected virtual void OnDesignMode()
        { 
            
        }
	}
}
