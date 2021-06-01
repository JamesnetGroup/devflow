using DevFlow.Serialization.Color;
using DevFlow.Serialization.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevFlow.Data.Colors
{
	public class ColorStamModel
	{

		public string HexColor { get; set; }
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }
		public ICommand ColorClickCommand { get; set; }

		public ColorStamModel(ColorStruct rgba, ICommand command)
		{
			HexColor = ConvertColor.GetHex(rgba);
            Red = rgba.Red;
			Green = rgba.Green;
			Blue = rgba.Blue;
			ColorClickCommand = command;
		}
	}
}
