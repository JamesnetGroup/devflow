using System.Windows;
using System.Windows.Controls;

namespace DevFlow.LayoutSupport.Controls
{
	public class ColorSpoid : Slider
	{
		static ColorSpoid()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSpoid), new FrameworkPropertyMetadata(typeof(ColorSpoid)));
		}
	}
}
