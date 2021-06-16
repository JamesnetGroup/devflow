using DevFlow.Data;
using System.IO;

namespace DevFlow.Finders.Local.Model
{
	public class FolderModel : FileModel
	{
		public string FileName => Path.GetFileName(FullPath) == "" ? FullPath : Path.GetFileName(FullPath);

		public FolderModel(string fullPath, GeoIcon icon)
		{
			FullPath = fullPath;
			IconType = icon;
		}
	}
}
