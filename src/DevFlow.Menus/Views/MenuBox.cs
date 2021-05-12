using DevFlow.Menus.ViewModels;
using DevFlow.Windowbase.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.Menus.Views
{
	public class MenuBox : Control
    {
        #region DependencyProperty

        public static readonly DependencyProperty MouseDownCommandProperty = DependencyProperty.Register("MouseDownCommand", typeof(ICommand), typeof(MenuBox));
        #endregion

        #region MouseDownCommand

        public ICommand MouseDownCommand
        {
            get { return (ICommand)this.GetValue(MouseDownCommandProperty); }
            set { this.SetValue(MouseDownCommandProperty, value); }
        }
        #endregion

        static MenuBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuBox), new FrameworkPropertyMetadata(typeof(MenuBox)));
		}

        public MenuBox()
        {
            DataContext = new MenuViewModel();
			Loaded += MenuBox_Loaded;
        }

		private void MenuBox_Loaded(object sender, RoutedEventArgs e)
		{
            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
	}
}
