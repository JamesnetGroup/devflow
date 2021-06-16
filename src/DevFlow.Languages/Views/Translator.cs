using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Languages.Views
{
	public class Translator : BasicWindow
	{
		#region DefaultStyleKey

		static Translator()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Translator), new FrameworkPropertyMetadata(typeof(Translator)));
		}
		#endregion
	}
}
