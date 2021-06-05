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
            var menus = new List<MenuModel>();
            menus.Add(new MenuModel { Seq = 0, Name = "Background", IconType = GeometryIconStyle.MonitorShimmer });
            menus.Add(new MenuModel { Seq = 1, Name = "History", IconType = GeometryIconStyle.MovieOpenPlay });
            menus.Add(new MenuModel { Seq = 2, Name = "Color", IconType = GeometryIconStyle.EyedropperVariant });
            menus.Add(new MenuModel { Seq = 3, Name = "Setting", IconType = GeometryIconStyle.OcgRefreshOutline });
            menus.Add(new MenuModel { Seq = 4, Name = "Theme", IconType = GeometryIconStyle.Palette });
            menus.Add(new MenuModel { Seq = 5, Name = "Web", IconType = GeometryIconStyle.Web });
            menus.Add(new MenuModel { Seq = 6, Name = "Color2", IconType = GeometryIconStyle.Crop });
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
