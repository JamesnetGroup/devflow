using DevFlow.Menus.ViewModels;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Main.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        #region Wallpaper

        public string Wallpaper { get; set; }
        #endregion

        public MenuBoxViewModel Menu { get; set; }

        #region Constructor

        public MainViewModel()
        {
            Wallpaper = "/DevFlow.Resources;component/Images/wallpaper-08.jpg";
            Menu = new MenuBoxViewModel();
        }
        #endregion
    }
}
