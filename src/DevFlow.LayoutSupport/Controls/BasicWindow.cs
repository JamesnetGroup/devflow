using System.Windows;

namespace DevFlow.LayoutSupport.Controls
{
	public class BasicWindow : Explorer
	{
		#region DefaultStyleKey

		static BasicWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicWindow), new FrameworkPropertyMetadata(typeof(BasicWindow)));
		}
		#endregion

		#region COnstructor

		public BasicWindow()
		{
		}
		#endregion
	}
}




