<<<<<<< HEAD
﻿using System.Windows.Input;
=======
﻿using DevFlow.Serialization.Color;
using DevFlow.Serialization.Data;
using System.Windows.Input;
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d

namespace DevFlow.Data.Colors
{
    public class ColorStampModel
	{

		public string HexColor { get; set; }
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }
		public ICommand ColorClickCommand { get; set; }

		public ColorStampModel(ColorStruct rgba, ICommand command)
		{
			HexColor = ConvertColor.Hex(rgba);
			Red = rgba.Red;
			Green = rgba.Green;
			Blue = rgba.Blue;
			ColorClickCommand = command;
		}
	}
}
