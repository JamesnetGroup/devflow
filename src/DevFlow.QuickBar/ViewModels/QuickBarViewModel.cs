using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DevFlow.QuickBar.ViewModels
{
    public class QuickBarViewModel : ObservableObject
    {
        public ICommand DragWindowCommand { get; set; }
        public QuickBarViewModel()
        {
            DragWindowCommand = new RelayCommand<MouseEventArgs>(DragWindow);
        }

        private void DragWindow(MouseEventArgs e)
        {
            Window.GetWindow((UIElement)e.Source).DragMove();
        }

        public override void OnInitDesignTime()
        {
        }

        public override void OnLoaded(UserControl view)
        {
            base.OnLoaded(view);
        }
    }
}
