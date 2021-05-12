using System.IO;
using System.Windows;
using DevFlow.Data;

namespace DevFlow.Windowbase.Flowbase
{
    public class FlowApp : Application
    {
        protected FlowTheme Theme;
        protected Window main;

        public FlowApp()
        {
            InitilizeTheme();
        }

        private void InitilizeTheme()
        {
            Theme = new FlowTheme(this);
            Theme.BaseAssemblyPath = "/DevFlow.Resources;component/Themes/";
            OnApplyThemeManager();
            Theme.SetDefault(OnSetDefaultTheme(ThemeType.White));
        }

        protected virtual void OnApplyThemeManager()
        {
        }

        protected virtual ThemeType OnSetDefaultTheme(ThemeType type)
        {
            return type;
        }

        protected void AddTheme(ThemeType type, string fileName)
        {
            AddTheme(type, Theme.BaseAssemblyPath, fileName);
        }

        protected void AddTheme(ThemeType type, string baseAssemblyPath, string fileName)
        {
            Theme.Add(type, Path.Combine(baseAssemblyPath, fileName));
        }

        protected void AddThemeResource(ThemeType type, ResourceDictionary source)
        {
            Theme.Add(type, source);
        }
    }
}
