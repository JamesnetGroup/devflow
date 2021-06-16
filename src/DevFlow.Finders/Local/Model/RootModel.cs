using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using System.Collections.ObjectModel;
using System.IO;

namespace DevFlow.Finders.Local.Model
{
	public class RootModel : FileModel
	{
		public RootModel(int depth, string name, GeoIcon icon, string fullPath, bool isExpanded, bool isSelected)
		{
			FullPath = fullPath;
			Depth = depth;
			Name = name;
			IconType = icon;
			IsExpanded = isExpanded;
			IsSelected = isSelected;
			Children = new ObservableCollection<FileModel>();
		}

		public RootModel(string target, GeoIcon icon) : this(0, Path.GetFileName(target), RootIcon.Folder, target, false, false)
		{

		}
	}
}
