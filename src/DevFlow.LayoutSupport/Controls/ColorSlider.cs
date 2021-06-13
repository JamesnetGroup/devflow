using System.Windows;
using System.Windows.Controls;

namespace DevFlow.LayoutSupport.Controls
{
    public class ColorSlider : Slider
    {
        #region DefaultStyleKey

        static ColorSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSlider), new FrameworkPropertyMetadata(typeof(ColorSlider)));
        }
        #endregion
    }
}
