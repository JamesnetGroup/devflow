using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DevFlow.Data;
using DevFlow.Data.Menu;
using DevFlow.Data.Theme;
using DevFlow.Data.Works;
using DevFlow.Languages.ViewModels;
using DevFlow.Languages.Views;
using DevFlow.Main.Views;
using DevFlow.Menus.ViewModels;
using DevFlow.Skins.ViewModels;
using DevFlow.Skins.Views;
using DevFlow.Windowbase.Flowbase;
using DevFlow.Windowbase.Flowcore;
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

		#region Translate

        TranslatorViewModel Translate { get; }
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
            Translate = new TranslatorViewModel();
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
            if (Works.FirstOrDefault(x => x.Menu.Equals(menu)) is null)
            {
                IFlowUIElement content;

                switch (menu.IconType)
                {
                    case GeometryIconStyle.Palette: content = new SwitchSkin().UseMvvm(Skin); break;
                    case GeometryIconStyle.Web: content = new Translator().UseMvvm(Translate); break;
                    default: content = new EmptyView(); break;
                }
                Works.Add(new WorkspaceModel(menu, content));
            }

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
