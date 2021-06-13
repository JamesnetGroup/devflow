using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Windowbase.Flowbase
{
    public class FlowView : ContentControl
    {
        #region Constructor

        public FlowView()
        {
            Loaded += FlowView_Loaded;
        }
        #endregion

        #region OnDesignerMode

        protected virtual void OnDesignerMode()
        {

        }
        #endregion

        #region FlowView_Loaded

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
