using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Skins.Views
{
	public class SwitchSkin : ContentControl
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
