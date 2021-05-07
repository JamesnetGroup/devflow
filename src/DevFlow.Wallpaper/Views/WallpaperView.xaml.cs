using DevFlow.Controls;
using DevFlow.Wallpaper.ViewModels;

namespace DevFlow.Wallpaper.Views
{
    public partial class WallpaperView : View
    {
        #region . Constructor .

        public WallpaperView()
        {
            InitializeComponent();
            DataContext = new WallpaperViewModel();
        }
        #endregion
    }
}
