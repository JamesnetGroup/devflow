using System.Windows;
using System.Windows.Controls;

namespace DevFlow.LayoutSupport.Controls
{
	public class ColorSlider : Slider
	{
		static ColorSlider()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSlider), new FrameworkPropertyMetadata(typeof(ColorSlider)));
		}
	}
}
