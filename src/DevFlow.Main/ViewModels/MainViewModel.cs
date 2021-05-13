using System.Collections.ObjectModel;
using DevFlow.Data;
using DevFlow.Data.Menu;
using DevFlow.Data.Theme;
using DevFlow.Data.Works;
using DevFlow.Languages.Views;
using DevFlow.Menus.ViewModels;
using DevFlow.Skins.ViewModels;
using DevFlow.Skins.Views;
using DevFlow.Windowbase.Flowbase;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Main.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private FlowTheme theme;

		#region Wallpaper

		public string Wallpaper { get; set; }
        #endregion

        #region Menu

        public QuickSlotViewModel Menu { get; set; }
        #endregion

        #region Theme

        public SwitchSkinViewModel Skin { get; set; }
		#endregion

		#region Works

		public ObservableCollection<WorkspaceModel> Works { get; set; }
		#endregion

		#region Constructor

		public MainViewModel()
        {
            Wallpaper = "/DevFlow.Resources;component/Images/wallpaper-08.jpg";

            Works = new ObservableCollection<WorkspaceModel>();
            Menu = new QuickSlotViewModel(MenuSelected);
        }

        public MainViewModel(FlowTheme _theme) : this()
        {
            theme = _theme;

            Skin = new SwitchSkinViewModel(SkinSelected, theme.GetCurrentTheme());
        }
        #endregion

        #region MenuSelected

        private void MenuSelected(MenuModel menu)
        {
            WorkspaceModel work = new WorkspaceModel(menu);

            switch (menu.IconType)
            {
                case GeometryIconStyle.Palette: work.Content = new SwitchSkin(); break;
                case GeometryIconStyle.Web: work.Content = new SwitchTranslate(); break;
            }
            Works.Add(work);
        }
        #endregion

        #region SkinSelected

        private void SkinSelected(SkinModel theme)
        {
            this.theme.Switch(theme.Skin);
        }
        #endregion
    }
}
