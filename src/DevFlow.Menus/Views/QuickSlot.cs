using DevFlow.Controls.Primitives;
using DevFlow.Menus.ViewModels;
using System.Windows;

namespace DevFlow.Menus.Views
{
	public class QuickSlot : Express
	{
		#region DefaultStyleKey

		static QuickSlot()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickSlot), new FrameworkPropertyMetadata(typeof(QuickSlot)));
		}
		#endregion

		#region Constructor

		public QuickSlot()
		{
		}
		#endregion

		#region OnDesignerMode

		protected override void OnDesignerMode()
		{
			DataContext = new QuickSlotViewModel();
		}
		#endregion
	}
}
