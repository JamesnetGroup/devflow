using DevFlow.Data;
using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DevFlow.Menus.ViewModels
{
	public class MenuBoxViewModel : ObservableObject
    {
        #region Commands 

        public ICommand DragWindowCommand { get; set; }
        #endregion

        #region Menus

        public List<MenuModel> Menus { get; set; }
        #endregion

        #region Constructor 

        public MenuBoxViewModel()
        {
            DragWindowCommand = new RelayCommand<MouseEventArgs>(DragWindow);
            Menus = GetMenus();
        }
        #endregion

        #region GetMenus

        private List<MenuModel> GetMenus()
        {
            var menus = new List<MenuModel>();
            menus.Add(new MenuModel { Seq = 0, Name = "Background", IconType = GeometryIconStyle.MonitorShimmer });
            menus.Add(new MenuModel { Seq = 1, Name = "History", IconType = GeometryIconStyle.MovieOpenPlay });
            menus.Add(new MenuModel { Seq = 2, Name = "Color", IconType = GeometryIconStyle.EyedropperVariant });
            menus.Add(new MenuModel { Seq = 3, Name = "Setting", IconType = GeometryIconStyle.OcgRefreshOutline });
            menus.Add(new MenuModel { Seq = 4, Name = "VisualStudio", IconType = GeometryIconStyle.MicrosoftVisualStudio });
            menus.Add(new MenuModel { Seq = 5, Name = "Translate", IconType = GeometryIconStyle.GoogleTranslate });
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
