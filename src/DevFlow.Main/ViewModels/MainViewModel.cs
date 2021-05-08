using DevFlow.Windowbase.Mvvm;
using System.Web.Services.Description;

namespace DevFlow.Main.ViewModels
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

            Service
        }
        #endregion
    }
}
