﻿using System;
using System.Windows;
using DevFlow.Data;
using DevFlow.Main.ViewModels;
using DevFlow.Main.Views;
using DevFlow.Windowbase.Flowbase;

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

        protected override void OnStartup(StartupEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("/DevFlow.Resources;component/Themes/Languages/EN.xaml", UriKind.RelativeOrAbsolute) });
            bool dialogResult = true;

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                var main = new MainView();
                main.DataContext = new MainViewModel(Theme);
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }
            Environment.Exit(0);
        }
    }
}
