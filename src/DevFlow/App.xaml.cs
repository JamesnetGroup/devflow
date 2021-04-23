using DevFlow.Main.Views;
using DevFlow.Windowbase.Design;
using System;
using System.Resources;
using System.Windows;

namespace DevFlow
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool dialogResult = true;
            MainWindow main;

            ResourceMerger.Initialize();

            while (dialogResult)
            {

                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                main = new MainWindow();
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }

            Environment.Exit(0);
        }
    }
}
