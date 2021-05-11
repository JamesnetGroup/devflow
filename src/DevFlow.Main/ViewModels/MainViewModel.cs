namespace DevFlow.Main.ViewModels
{
    public class MainViewModel
    {
        #region Wallpaper

        public string Wallpaper { get; set; }
        #endregion

        #region Constructor

        public MainViewModel()
        {
            Wallpaper = "/DevFlow.Resources;component/Images/wallpaper-08.jpg";
        }
        #endregion
    }
}
