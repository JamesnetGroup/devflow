using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Main.Views
{
    public class MainViewModel : ObservableObject
    {
        #region . Wallpaper .

        public string Wallpaper { get; set; }
        #endregion

        #region . Constructor .

        public MainViewModel()
        {
            Wallpaper = "/DevFlow.Resources;component/Images/wallpaper-08.jpg";
        }
        #endregion
    }
}
