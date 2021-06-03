using DevFlow.Controls.Primitives;
using DevFlow.Menus.ViewModels;
using System.Windows;

namespace DevFlow.Menus.Views
{
	public class QuickSlot : Widget
	{
		static QuickSlot()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickSlot), new FrameworkPropertyMetadata(typeof(QuickSlot)));
		}

		public QuickSlot()
		{
		}

		protected override void OnDesignerMode()
		{
			DataContext = new QuickSlotViewModel();
		}
	}
}
