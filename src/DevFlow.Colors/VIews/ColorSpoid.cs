using DevFlow.LayoutSupport.Controls;
using System.Windows;

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
        }
    }
}
