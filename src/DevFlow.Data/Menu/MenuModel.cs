using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevFlow.Data.Menu
{
	public class MenuModel
	{
		public int Seq { get; set; }
		public string Name { get; set; }
		public GeometryIconStyle IconType { get; set; }

		public ICommand MenuClickCommand { get; set; }
	}
}
