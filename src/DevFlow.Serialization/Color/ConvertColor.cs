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
	}
}
