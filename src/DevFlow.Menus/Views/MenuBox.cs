using DevFlow.LayoutSupport;
using DevFlow.Menus.ViewModels;
using DevFlow.Windowbase.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace DevFlow.Menus.Views
{
	public class MenuBox : Widget
    {
        static MenuBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuBox), new FrameworkPropertyMetadata(typeof(MenuBox)));
		}

        public MenuBox()
        {
            DataContext = new MenuBoxViewModel();
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
