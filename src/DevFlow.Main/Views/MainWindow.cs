using System.Windows;
using DevFlow.Controls.Primitives;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
    public class MainWindow : SystemWindow
    {
        #region DefaultStyleKey

        static MainWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindow), new FrameworkPropertyMetadata(typeof(MainWindow)));
        }
        #endregion

        #region Constructor

        public MainWindow()
        {

        }
        #endregion

        #region OnDesignerMode

        protected override void OnDesignerMode()
        {
            DataContext = new MainViewModel();
        }
        #endregion
    }
}