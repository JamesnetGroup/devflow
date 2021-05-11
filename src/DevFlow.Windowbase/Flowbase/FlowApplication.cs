using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevFlow.Windowbase.Flowbase
{
    public class Appbase : Application
    {
        protected ThemeManager Theme;
        protected Window main;

        public Appbase()
        {
            Theme = new ThemeManager(this);
            OnApplyThemeManager();
        }

        protected virtual void OnApplyThemeManager()
        {
        }
    }
}
