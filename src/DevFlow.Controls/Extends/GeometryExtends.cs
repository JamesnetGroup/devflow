using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DevFlow.Controls.Extends
{
	public static class GeometryExtends
	{
		public static Geometry ToGeometry(this string geometryString)
		{
			return Geometry.Parse(geometryString);
		}
	}
}
