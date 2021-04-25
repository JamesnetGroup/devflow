using DevFlow.Data;
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

        public List<QuickMenuModel> Menus { get; set; }

        public QuickBarViewModel()
        {
            DragWindowCommand = new RelayCommand<MouseEventArgs>(DragWindow);
            Menus = GetMenus();
        }

        private List<QuickMenuModel> GetMenus()
        {
            var menus = new List<QuickMenuModel>();
            menus.Add(new QuickMenuModel { Seq = 0, Name = "Background" });
            menus.Add(new QuickMenuModel { Seq = 1, Name = "History" });
            menus.Add(new QuickMenuModel { Seq = 2, Name = "Color" });
            menus.Add(new QuickMenuModel { Seq = 3, Name = "Setting" });
            menus.Add(new QuickMenuModel { Seq = 4, Name = "VisualStudio" });
            menus.Add(new QuickMenuModel { Seq = 5, Name = "Translate" });
            return menus;
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
