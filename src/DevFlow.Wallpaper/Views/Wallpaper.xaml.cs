using DevFlow.Controls;
using DevFlow.Wallpaper.ViewModels;

namespace DevFlow.Wallpaper.Views
{
    public partial class Wallpaper : View
    {
        #region . Constructor .

        public Wallpaper()
        {
            InitializeComponent();
            DataContext = new WallpaperViewModel();
        }
        #endregion
    }
}
