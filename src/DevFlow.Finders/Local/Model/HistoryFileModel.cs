using DevFlow.Data;
using System.IO;

namespace DevFlow.Finders.Local.Model
{
	public class HistoryFileModel : FileModel
	{
		public string FileName
		{
			get { return Path.GetFileName(FullPath) == "" ? FullPath : Path.GetFileName(FullPath); }
		}

		public HistoryFileModel(string fullPath, GeoIcon icon)
		{
			FullPath = fullPath;
			IconType = icon;
		}
	}
}
