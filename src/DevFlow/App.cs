using System;
using System.Windows;
using DevFlow.Data;
using DevFlow.Data.Settings;
using DevFlow.Main.ViewModels;
using DevFlow.Windowbase.Flowbase;

namespace DevFlow
{
    public class App : FlowApp
    {
        protected override ThemeType OnSetDefaultTheme(ThemeType type)
        {
            return ThemeType.Dark;
        }

        protected override void OnApplyThemeManager()
        {
            AddTheme(ThemeType.Dark, "Generic.Dark.xaml");
            AddTheme(ThemeType.White, "Generic.White.xaml");
            AddTheme(ThemeType.James, "Generic.James.xaml");
            AddTheme(ThemeType.Elena, "Generic.Elena.xaml");
        }

        protected override void OnApplyCultureManager()
        {
            AddLanguage(LanguageType.UnitedStates, "EN.xaml");
            AddLanguage(LanguageType.Korea, "KO.xaml");
            AddLanguage(LanguageType.China, "CN.xaml");
            AddLanguage(LanguageType.Japan, "JP.xaml");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/DevFlow.Resources;component/Themes/Generic.Drawings.xaml", UriKind.RelativeOrAbsolute) });

            bool dialogResult = true;

            ConfigModel config = FlowConfig.LoadConfig();

            Theme.Switch(config.Theme);
            Culture.Switch(config.Language);

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                Main.Views.MainWindow main = new()
                {
                    DataContext = new MainViewModel(Theme, Culture)
                };
                _ = main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }
            Environment.Exit(0);
        }
    }
}
