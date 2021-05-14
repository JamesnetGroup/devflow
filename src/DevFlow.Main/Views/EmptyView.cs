using DevFlow.Controls.Primitives;
using System.Windows;

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
