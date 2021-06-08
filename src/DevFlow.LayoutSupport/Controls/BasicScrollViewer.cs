using System.Windows;
using System.Windows.Controls;

namespace DevFlow.LayoutSupport.Controls
{
	public class BasicScrollViewer : ScrollViewer
	{
		static BasicScrollViewer()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicScrollViewer), new FrameworkPropertyMetadata(typeof(BasicScrollViewer)));
		}
	}
}
