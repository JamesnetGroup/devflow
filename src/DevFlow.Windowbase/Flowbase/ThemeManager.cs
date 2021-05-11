using DevFlow.Data.Theme;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevFlow.Windowbase.Flowbase
{
    public class ThemeManager
    {
        private Appbase App;
        private Collection<ResourceDictionary> Themes;

        private Dictionary<ThemeType, ResourceDictionary> CustomThemes;
        private ResourceDictionary DarkThemeResource;
        private ResourceDictionary WhiteThemeResource;

        private ResourceDictionary CurrentTheme;

        internal ThemeManager(Appbase app)
        {
            App = app;
            Themes = App.Resources.MergedDictionaries;
        }

        internal void Switch(ThemeType theme)
        {
            if (Themes.Contains(CurrentTheme))
            {
                Themes.Remove(CurrentTheme);
            }

            switch (theme)
            {
                case ThemeType.Dark: CurrentTheme = DarkThemeResource; break;
                case ThemeType.White: CurrentTheme = WhiteThemeResource; break;
            }

            Themes.Add(CurrentTheme);
        }

        public void Add(ThemeType type, string source, UriKind kind)
        {
            ResourceDictionary resource = new ResourceDictionary { Source = new Uri(source, kind) };
            CustomThemes.Add(type, resource);
        }

        public void Add(ThemeType type, string source)
        {
            Add(type, source, UriKind.RelativeOrAbsolute);
        }
    }
}
