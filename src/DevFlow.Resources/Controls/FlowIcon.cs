using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.Resources.Controls
{
	public class FlowIcon : Icon
    {
        static FlowIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlowIcon), new FrameworkPropertyMetadata(typeof(FlowIcon)));
        }
    }
}
