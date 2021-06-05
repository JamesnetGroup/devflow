using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
	public class FlowIcon : Icon
	{
		static FlowIcon()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FlowIcon), new FrameworkPropertyMetadata(typeof(FlowIcon)));
		}
	}
}
