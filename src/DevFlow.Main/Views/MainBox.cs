using System.Windows;
using DevFlow.Controls.Primitives;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
	public class MainBox : MainWindow
	{
		#region DefaultStyleKey

		static MainBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MainBox), new FrameworkPropertyMetadata(typeof(MainBox)));
		}
		#endregion

		#region Constructor

		public MainBox()
		{

		}
		#endregion

		#region OnDesignerMode

		protected override void OnDesignerMode()
		{
			DataContext = new MainBoxViewModel();
		}
		#endregion
	}
}