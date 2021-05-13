using DevFlow.LayoutSupport;
using DevFlow.Menus.ViewModels;
using DevFlow.Windowbase.Mvvm;
using System.Windows;
using System.Windows.Input;

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
