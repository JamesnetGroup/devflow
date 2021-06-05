using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Finders.Local.Model
{
	public class RootModel
	{
		public string Name { get; set; }
		public ObservableCollection<RootModel> Children { get; private set; }
		public RootModel(string name)
		{
			Name = name;
			Children = new ObservableCollection<RootModel>();
		}
	}
}
