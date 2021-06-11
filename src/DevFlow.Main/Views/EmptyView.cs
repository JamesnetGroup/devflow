using System.Windows;
using DevFlow.LayoutSupport.Controls;

namespace DevFlow.Main.Views
{
	public class EmptyView : Explorer
	{
		static EmptyView()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(EmptyView), new FrameworkPropertyMetadata(typeof(EmptyView)));
		}
	}
}
