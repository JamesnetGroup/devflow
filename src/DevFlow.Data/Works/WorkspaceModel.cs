using DevFlow.Data.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
