using System.Windows;
using DevFlow.Data.Menu;
using DevFlow.LayoutSupport.Controls;
using DevFlow.Main.ViewModels;

namespace DevFlow.Main.Views
{
	public class Main : MainWindow
	{
		static Main()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Main), new FrameworkPropertyMetadata(typeof(Main)));
		}

		public Main()
		{

		}

		protected override void OnDesignerMode()
		{
			DataContext = new MainViewModel();
		}
	}
}