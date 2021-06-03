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
