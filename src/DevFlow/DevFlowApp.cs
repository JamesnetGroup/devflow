using System;
using System.Windows;
using DevFlow.Local;
using DevFlow.Data.Theme;
using DevFlow.Main.Views;
using DevFlow.Windowbase.Flowbase;

namespace DevFlow
{
    public class DevFlowApp : Appbase
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            bool dialogResult = true;

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                main = new MainView();
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }
            Environment.Exit(0);
        }

        protected override void OnApplyThemeManager()
        {
            Theme.Add(ThemeType.Dark, "/DevFlow.Resources;component/Themes/Generic.Dark.xaml");
            Theme.Add(ThemeType.White, "/DevFlow.Resources;component/Themes/Generic.Dark.xaml");
        }
    }
}
