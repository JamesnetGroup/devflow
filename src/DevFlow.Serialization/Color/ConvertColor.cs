using DevFlow.Serialization.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Serialization.Color
{
	public static class ConvertColor
	{
		public static ColorStruct Parse(string hex)
		{
			hex = hex.Replace("#", "");
			var data = Enumerable.Range(0, hex.Length)
					.Where(x => x % 2 == 0)
					.Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
					.ToArray();

			var color = new ColorStruct();
			color.Red = data[1];
			color.Green = data[2];
			color.Blue= data[3];
			color.Alpha = data[0];
			return color;
		}

		public static string GetHex(ColorStruct rgba)
		{
			string r = rgba.Red.ToString("X2");
			string g = rgba.Green.ToString("X2");
			string b = rgba.Blue.ToString("X2");
			string a = rgba.Alpha.ToString("X2");

			return $"#{a}{r}{g}{b}";
		}

		public static string GetInvertHex(ColorStruct rgba)
		{
			byte max = 255;
			
			string xr = ((byte)(max - rgba.Red)).ToString("X2");
			string xg = ((byte)(max - rgba.Green)).ToString("X2");
			string xb = ((byte)(max - rgba.Blue)).ToString("X2");
			return $"#FF{xr}{xg}{xb}";
		}

		public static string GetReverseColor(ColorStruct rgba, int standard = 142)
		{
			string reverse = "#FFFFFFFF";
			if ((rgba.Red * 0.299 + rgba.Green * 0.587 + rgba.Blue * 0.114) > standard)
			{
				reverse = "#FF000000";
			}
			return reverse;
		}
	}
}
