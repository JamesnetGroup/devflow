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
        private Button _closeButton;

        public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(View));

        public ICommand MouseDownCommand
        {
            get { return (ICommand)this.GetValue(MouseDownCommandProperty); }
            set { this.SetValue(MouseDownCommandProperty, value); }
        }


        public View()
        {
            Loaded += View_Loaded;
        }

        public override void OnApplyTemplate()
        {
            _closeButton = GetTemplateChild("PART_Close") as Button;
            if (_closeButton != null)
            {
                _closeButton.Click += _closeButton_Click;
            }
        }

        private void _closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Grid grid)
            {
                grid.Children.Remove(this);
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            MouseDownCommand?.Execute(e);
        }


        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
    }
}
