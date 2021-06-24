using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Finders.UI.Views
{
	public class Finder : Explorer
	{
		#region DefaultStyleKey

		static Finder()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Finder), new FrameworkPropertyMetadata(typeof(Finder)));
		}
		#endregion

		#region Constructor

		public Finder()
		{
		}
		#endregion
	}
}
