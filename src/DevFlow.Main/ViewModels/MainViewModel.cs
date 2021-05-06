using DevFlow.Windowbase.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevFlow.Main.ViewModels
{
    public class MainViewModel
    {
        #region . Wallpaper .

        public string Wallpaper { get; set; }
        #endregion

        #region . Constructor .

        public MainViewModel()
        {
            Wallpaper = "/DevFlow.Resources;component/Images/wallpaper-08.jpg";
        }
        #endregion
    }
}
