using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Finders.Views
{
	public class Finder : Explorer
	{
		static Finder()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Finder), new FrameworkPropertyMetadata(typeof(Finder)));
		}

		public Finder()
		{
		}
	}
}
