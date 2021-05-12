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
		}

		protected override void OnDesignMode()
		{
			DataContext = new MenuBoxViewModel();
		}
	}
}
