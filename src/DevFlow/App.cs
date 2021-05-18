using System;
using System.Collections.Generic;
using System.Windows;
using DevFlow.Data;
using DevFlow.Data.Settings;
using DevFlow.Main.ViewModels;
using DevFlow.Main.Views;
using DevFlow.Windowbase.Flowbase;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DevFlow
{
    public class App : FlowApp
    {
        protected override ThemeType OnSetDefaultTheme(ThemeType type) => ThemeType.Dark;

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
            bool dialogResult = true;

            ConfigModel config = FlowConfig.LoadConfig();

            Theme.Switch(config.Theme);
            Culture.Switch(config.Language);

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                var main = new MainView();
                main.DataContext = new MainViewModel(Theme, Culture);
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }
            Environment.Exit(0);
        }
    }
}
