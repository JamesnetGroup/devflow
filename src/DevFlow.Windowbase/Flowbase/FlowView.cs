using DevFlow.Windowbase.Flowcore;
using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowView : Button, IFlowUIElement
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

        #region OnDesignerMode

        protected virtual void OnDesignerMode()
        {

        }
        #endregion

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
	}
}
