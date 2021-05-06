using DevFlow.Data;
using DevFlow.Windowbase.Enums;
using DevFlow.Windowbase.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.QuickBar.ViewModels
{
    public class QuickBarViewModel : ObservableObject
    {
        #region . Commands .

        public ICommand DragWindowCommand { get; set; }
        #endregion

        #region . Menus .
        
        public List<QuickMenuModel> Menus { get; set; }
        #endregion

        #region . Constructor .

        public QuickBarViewModel()
        {
            DragWindowCommand = new RelayCommand<MouseEventArgs>(DragWindow);
            Menus = GetMenus();
        }
        #endregion

        #region . GetMenus .

        private List<QuickMenuModel> GetMenus()
        {
            var menus = new List<QuickMenuModel>();
            menus.Add(new QuickMenuModel { Seq = 0, Name = "Background", IconType = GeometryIcon.MonitorShimmer });
            menus.Add(new QuickMenuModel { Seq = 1, Name = "History", IconType = GeometryIcon.MovieOpenPlay });
            menus.Add(new QuickMenuModel { Seq = 2, Name = "Color", IconType = GeometryIcon.EyedropperVariant });
            menus.Add(new QuickMenuModel { Seq = 3, Name = "Setting", IconType = GeometryIcon.OcgRefreshOutline });
            menus.Add(new QuickMenuModel { Seq = 4, Name = "VisualStudio", IconType = GeometryIcon.MicrosoftVisualStudio });
            menus.Add(new QuickMenuModel { Seq = 5, Name = "Translate", IconType  = GeometryIcon.GoogleTranslate });
            return menus;
        }
        #endregion

        #region . DragWindow .

        private void DragWindow(MouseEventArgs e)
        {
            Window.GetWindow((UIElement)e.Source).DragMove();
        }
        #endregion

        #region . OnInitDesignTime .

        protected override void OnInitDesignTime()
        {
        }
        #endregion

        #region . OnLoaded .

        protected override void OnLoaded(UserControl view)
        {
            base.OnLoaded(view);
        }
        #endregion
    }
}
