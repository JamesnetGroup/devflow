using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Colors.Views
{
	public class ExtractColorBox : Control
	{
		static ExtractColorBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtractColorBox), new FrameworkPropertyMetadata(typeof(ExtractColorBox)));
		}
	}
}
