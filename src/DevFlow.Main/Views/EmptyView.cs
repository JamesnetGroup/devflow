using System.Windows;
using DevFlow.Controls.Primitives;

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
