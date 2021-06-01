using DevFlow.Colors.ViewModels;
using DevFlow.LayoutSupport.Controls;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Colors.Views
{
    public class ColorSpoid : Palette
    {
        static ColorSpoid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSpoid), new FrameworkPropertyMetadata(typeof(ColorSpoid)));
        }

        public ColorSpoid()
        {
			Loaded += (s, e) => Window.Topmost = true;
        }
    }
}
