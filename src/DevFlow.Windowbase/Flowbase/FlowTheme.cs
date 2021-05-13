using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevFlow.Data;

namespace DevFlow.Windowbase.Flowbase
{
    public class FlowTheme
    {
        public string BaseAssemblyPath;

        private FlowApp App;
        private Collection<ResourceDictionary> Themes;
        private Dictionary<ThemeType, ResourceDictionary> CustomThemes;
        private ResourceDictionary CurrentResource;
        private ThemeType CurrentTheme;


        internal FlowTheme(FlowApp app)
        {
            App = app;
            Themes = App.Resources.MergedDictionaries;
            CustomThemes = new();
        }

        internal void SetDefault(ThemeType theme)
        {
            CurrentResource = CustomThemes[theme];
            CurrentTheme = theme;
            Switch(theme);
        }

        public void Switch(ThemeType theme)
        {
            if (Themes.Contains(CurrentResource))
            {
                Themes.Remove(CurrentResource);
            }
            CurrentResource = CustomThemes[theme];
            Themes.Add(CurrentResource);
        }

        internal void Add(ThemeType type, ResourceDictionary source)
        {
            CustomThemes.Add(type, source);
        }

		public ThemeType GetCurrentTheme()
		{
            return CurrentTheme;
		}

		internal void Add(ThemeType type, string source, UriKind kind)
        {
            Add(type, new ResourceDictionary { Source = new Uri(source, kind) });
        }

        internal void Add(ThemeType type, string source)
        {
            Add(type, source, UriKind.RelativeOrAbsolute);
        }
    }
}
