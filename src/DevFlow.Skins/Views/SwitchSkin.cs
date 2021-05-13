using DevFlow.LayoutSupport;
using System.Windows;
using System.Windows.Controls;

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
				
		}

	}
}
