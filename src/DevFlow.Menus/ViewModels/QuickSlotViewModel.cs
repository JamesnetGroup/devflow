using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DevFlow.Data;
using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Menus.ViewModels
{
	public class QuickSlotViewModel : ObservableObject
	{
		#region Commands 

		public ICommand DragWindowCommand { get; set; }
		#endregion

		#region Menus

		public List<MenuModel> Menus { get; set; }
		#endregion

		#region Constructors

		public QuickSlotViewModel()
		{
			DragWindowCommand = new RelayCommand<MouseEventArgs>(DragWindow);
			Menus = GetMenus();
		}

		public QuickSlotViewModel(RelayCommand<MenuModel> menuSelected) : this()
		{
			Menus.ForEach(x => x.MenuClickCommand = menuSelected);
		}
		#endregion

		#region GetMenus

		private List<MenuModel> GetMenus()
		{
			List<MenuModel> menus = new List<MenuModel>();
			menus.Add(new MenuModel { Seq = 0, Name = "Move", IconType = GeoIcon.ArrowAll });
			menus.Add(new MenuModel { Seq = 0, Name = "Directory", IconType = GeoIcon.FolderOpenOutline });
			menus.Add(new MenuModel { Seq = 1, Name = "Color", IconType = GeoIcon.EyedropperVariant });
			menus.Add(new MenuModel { Seq = 2, Name = "Theme", IconType = GeoIcon.Palette });
			menus.Add(new MenuModel { Seq = 3, Name = "Web", IconType = GeoIcon.Web });
			menus.Add(new MenuModel { Seq = 99, Name = "Close", IconType = GeoIcon.Close });
			return menus;
		}
		#endregion

		#region DragWindow

		private void DragWindow(MouseEventArgs e)
		{
			Window.GetWindow((UIElement)e.Source).DragMove();
		}
		#endregion
	}
}
