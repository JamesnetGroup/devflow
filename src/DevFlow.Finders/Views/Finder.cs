using DevFlow.Finders.ViewModels;
using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Finders.Views
{
	public class Finder : Preview
	{
		static Finder()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Finder), new FrameworkPropertyMetadata(typeof(Finder)));
		}

		public Finder()
		{
			DataContext = new FinderViewModel();
		}
	}
}
