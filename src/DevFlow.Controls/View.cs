using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DevFlow.Controls
{
    public class View : UserControl
    {
        public View()
        {
            Loaded += View_Loaded;       
        }

        private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ViewRegister(this);
            }
        }
    }
}
