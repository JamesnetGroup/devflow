using DevFlow.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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




