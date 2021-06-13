using System.Windows.Media;

namespace DevFlow.Controls.Util
{
    public static class GeometryExtends
    {
        #region ToGeometry

        public static Geometry ToGeometry(this string geometryString)
        {
            return Geometry.Parse(geometryString);
        }
        #endregion
    }
}
