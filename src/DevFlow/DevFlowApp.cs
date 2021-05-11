using DevFlow.Data.Theme;
using DevFlow.Local;
using DevFlow.Main.Views;
using System;
using System.Windows;
using DevFlow;

namespace DevFlow
{

    public class DevFlowApp : Application
    {
        private ThemeManager _themeManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            InitializeTheme();

            bool dialogResult = true;
            MainView mainWin;

            //ResourceMerger.Initialize();

            while (dialogResult)
            {

                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                mainWin = new MainView();
                mainWin.ShowDialog();
                dialogResult = (bool)mainWin.DialogResult;
            }

            Environment.Exit(0);
        }

        private void InitializeTheme()
        {
            _themeManager = new ThemeManager(this);
            _themeManager.Switch(ThemeType.Dark);
        }
    }
}
