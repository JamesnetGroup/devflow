using DevFlow.Data.Menu;
using System.Windows;

namespace DevFlow.Data.Works
{
    public class WorkspaceModel
	{
		public MenuModel Menu { get; set; }
		public IInputElement Content { get; set; }

		public WorkspaceModel(MenuModel menu, IInputElement content)
		{
			Menu = menu;
			Content = content;
		}

	}
}
