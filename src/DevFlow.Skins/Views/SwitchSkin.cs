using DevFlow.LayoutSupport;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevFlow.Skins.Views
{
	public class SwitchSkin : Widget
	{
		static SwitchSkin()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchSkin), new FrameworkPropertyMetadata(typeof(SwitchSkin)));
		}

		public SwitchSkin()
		{
			RenderTransform = new TranslateTransform(100, 100);
		}

	}
}
