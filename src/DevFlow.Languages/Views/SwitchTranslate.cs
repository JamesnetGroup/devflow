using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Languages.Views
{
	public class SwitchTranslate : Control
	{
		static SwitchTranslate()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchTranslate), new FrameworkPropertyMetadata(typeof(SwitchTranslate)));
		}
	}
}
