using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevFlow.Data.Theme
{
	public class SkinModel
	{
		public string Name { get; set; }
		public ThemeType Skin { get; set; }
		public ICommand SelectSkinCommand { get; set; }

		public SkinModel(string name, ThemeType themeType)
		{
			Name = name;
			Skin = themeType;
		}
	}
}
