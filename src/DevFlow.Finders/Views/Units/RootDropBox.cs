using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Finders.Views
{
	public class RootDropBox : ComboBox
	{
		#region Constructor

		static RootDropBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RootDropBox), new FrameworkPropertyMetadata(typeof(RootDropBox)));
		}
		#endregion
	}
}
