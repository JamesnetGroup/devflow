using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Skins.Views
{
	public class SwitchSkin : BasicWindow
	{
		#region DefaultStyleKey

		static SwitchSkin()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchSkin), new FrameworkPropertyMetadata(typeof(SwitchSkin)));
		}
		#endregion

		#region Constructor

		public SwitchSkin()
		{
		}
		#endregion
	}
}
