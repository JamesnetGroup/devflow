using DevFlow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Finders.Local.Api
{

	internal sealed record RootIcon
	{
		internal static GeoIcon MyPC => GeoIcon.DesktopClassic;
		internal static GeoIcon Folder => GeoIcon.Folder;
		internal static GeoIcon Download => GeoIcon.ArrowDownBox;
		internal static GeoIcon Document => GeoIcon.TextBox;
		internal static GeoIcon Pictures => GeoIcon.Image;
	}
}
