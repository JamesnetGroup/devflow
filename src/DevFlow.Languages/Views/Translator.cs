using DevFlow.Controls.Primitives;
using System.Windows;

namespace DevFlow.Languages.Views
{
	public class Translator : Widget
	{
		static Translator()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Translator), new FrameworkPropertyMetadata(typeof(Translator)));
		}
	}
}
