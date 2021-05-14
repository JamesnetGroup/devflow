using DevFlow.LayoutSupport.Controls;
using System.Windows;
using System.Windows.Controls;

namespace DevFlow.Main.Views
{
	public class EmptyView : Widget
	{
		static EmptyView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(EmptyView), new FrameworkPropertyMetadata(typeof(EmptyView)));
		}
	}
}
