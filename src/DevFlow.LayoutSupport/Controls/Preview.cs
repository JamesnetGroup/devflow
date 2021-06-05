using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
    public class Preview : Widget
	{

		static Preview()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Preview), new FrameworkPropertyMetadata(typeof(Preview)));
		}

		public Preview()
		{
		}
	}
}




