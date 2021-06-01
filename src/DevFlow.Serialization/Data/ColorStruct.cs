using System;
using System.Drawing;

namespace DevFlow.Serialization.Data
{
	public struct ColorStruct
	{
		public byte Red { get; set; }
		public byte Green{ get; set; }
		public byte Blue { get; set; }
		public byte Alpha{ get; set; }

		public ColorStruct(byte red, byte green, byte blue, byte alpha)
		{
			Red = red;
			Green = green;
			Blue = blue;
			Alpha = alpha;
		}
		public ColorStruct(int red, int green, int blue, int alpha)
		{
			Red = (byte)red;
			Green = (byte)green;
			Blue = (byte)blue;
			Alpha = (byte)alpha;
		}

		public ColorStruct(System.Drawing.Color color)
		{
			Red = color.R;
			Green = color.G;
			Blue = color.B;
			Alpha = color.A;
		}

		public ColorStruct SetAddBlue(int value)
		{
			Blue = (byte)((int)Blue + (int)value);
			return this;
		}
	}
}
