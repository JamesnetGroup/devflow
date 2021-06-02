using DevFlow.LayoutSupport.Controls;
using System.Windows;

namespace DevFlow.Reflects.Views
{
	public class Reflector : Preview
	{
		static Reflector()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Reflector), new FrameworkPropertyMetadata(typeof(Reflector)));
		}
	}
}
