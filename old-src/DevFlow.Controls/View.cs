using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Controls
{
    public class View : UserControl
    {
        public Action<View> Minimizing;

        #region . DependencyProperty .
        
        public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(View));
        #endregion

        #region . MouseDownCommand . 

        public ICommand MouseDownCommand
        {
            get { return (ICommand)this.GetValue(MouseDownCommandProperty); }
            set { this.SetValue(MouseDownCommandProperty, value); }
        }
        #endregion

        #region . Constructor .

        public View()
        {
            Loaded += ViewLoaded;
        }
        #endregion

        #region . OnApplyTemplate . 

        public override void OnApplyTemplate()
        {
            if (GetTemplateChild("PART_Close") is Button btn)
            {
                btn.Click += CloseButtonClick;
            }

            if (GetTemplateChild("PART_Minimize") is Button btnMin)
            {
                btnMin.Click += BtnMin_Click;
            }
        }
        #endregion

        #region . CloseButtonClick .

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            if (Parent is Grid grid)
            {
                grid.Children.Remove(this);
            }
        }
        #endregion

        #region . MinimizeButtonClick .

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            Minimizing?.Invoke(this);
        }
        #endregion

        #region . OnMouseLeftButtonDown .

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            MouseDownCommand?.Execute(e);
        }
        #endregion

        #region . ViewLoaded .

        private void ViewLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
        #endregion
    }
}
