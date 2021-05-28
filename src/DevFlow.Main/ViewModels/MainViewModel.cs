using System.Linq;
using System.Collections.ObjectModel;
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
using DevFlow.Data.Language;
using DevFlow.Histories.Views;
using DevFlow.Histories.ViewModels;
using DevFlow.Colors.Views;
using DevFlow.Colors.ViewModels;
using System.Windows;

namespace DevFlow.Main.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private FlowTheme theme;
        private FlowCulture culture;

        #region Wallpaper

        public string Wallpaper { get; set; }
        #endregion

        #region Menu

        public QuickSlotViewModel Menu { get; }
        #endregion

        #region Theme

        public SwitchSkinViewModel Skin { get; }
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
            Menu = new QuickSlotViewModel(new RelayCommand<MenuModel>(MenuSelected));
        }

        public MainViewModel(FlowTheme _theme, FlowCulture _culture) : this()
        {
            theme = _theme;
            culture = _culture;
            Skin = new SwitchSkinViewModel(SkinSelected, theme.GetCurrentTheme());
            Translate = new TranslatorViewModel(LanguageChanged, culture.GetCurrentLanguage());
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
                    case GeometryIconStyle.EyedropperVariant: content = new ColorSpoid().UseMvvm(new ColorSpoidViewModel()); break;
                    case GeometryIconStyle.MovieOpenPlay: content = new History().UseMvvm(new HistoryViewModel()); break;
                    case GeometryIconStyle.Palette: content = new SwitchSkin().UseMvvm(Skin); break;
                    case GeometryIconStyle.Web: content = new Translator().UseMvvm(Translate); break;
                    default: content = new EmptyView(); break;
                }

                Window win = new Window();
				win.PreviewMouseMove += Win_PreviewMouseMove;
                win.Content = content;
                win.AllowsTransparency = true;
                win.WindowStyle = WindowStyle.None;
                win.SizeToContent = SizeToContent.WidthAndHeight;
                win.Show();
                //Works.Add(new WorkspaceModel(menu, content));
            }

        }

		private void Win_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ((Window)sender).DragMove();
            }
		}
		#endregion

		#region SkinSelected

		private void SkinSelected(SkinModel theme)
        {
            this.theme.Switch(theme.Skin);
            FlowConfig.SaveTheme(theme.Skin);
        }
        #endregion

        #region LanguageChanged

        private void LanguageChanged(LanguageModel culture)
        {
            this.culture.Switch(culture.Language);
            FlowConfig.SaveLanguage(culture.Language);
        }
        #endregion
    }
}
