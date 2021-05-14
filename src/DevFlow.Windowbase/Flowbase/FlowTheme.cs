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
        private Collection<ResourceDictionary> Resources;
        private Dictionary<ThemeType, ResourceDictionary> Themes;
        private ResourceDictionary CurrentResource;
        private ThemeType CurrentTheme;


        internal FlowTheme(FlowApp app)
        {
            App = app;
            Resources = App.Resources.MergedDictionaries;
            Themes = new();
        }

        internal void SetDefault(ThemeType theme)
        {
            CurrentResource = Themes[theme];
            CurrentTheme = theme;
            Switch(theme);
        }

        public void Switch(ThemeType theme)
        {
            if (Resources.Contains(CurrentResource))
            {
                Resources.Remove(CurrentResource);
            }
            CurrentResource = Themes[theme];
            Resources.Add(CurrentResource);
        }

        internal void Add(ThemeType type, ResourceDictionary source)
        {
            Themes.Add(type, source);
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
