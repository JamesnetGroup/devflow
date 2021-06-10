using System.Windows;
using DevFlow.LayoutSupport.Controls;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
	public class MainBox : MainWindow
	{
		static MainBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MainBox), new FrameworkPropertyMetadata(typeof(MainBox)));
		}

		public MainBox()
		{

		}

		protected override void OnDesignerMode()
		{
			DataContext = new MainBoxViewModel();
		}
	}
}