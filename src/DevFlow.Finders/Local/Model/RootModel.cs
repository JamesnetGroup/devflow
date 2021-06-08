using DevFlow.Data;
using DevFlow.Windowbase.Mvvm;
using System.Collections.ObjectModel;

namespace DevFlow.Finders.Local.Model
{
	public class RootModel : ObservableData
	{
		private bool _isExpanded;

		public string FullPath { get; set; }
		public int Depth { get; }
		public string Name { get; set; }
		public bool IsExpanded
		{
			get => _isExpanded;
			set { _isExpanded = value; OnPropertyChanged(); }
		}

		public GeometryIconStyle IconType { get; }
		public ObservableCollection<RootModel> Children { get; private set; }
		public RootModel(int depth, string name, GeometryIconStyle icon, bool isExpanded, string fullPath)
		{
			FullPath = fullPath;
			Depth = depth;
			Name = name;
			IconType = icon;
			IsExpanded = isExpanded;
			Children = new ObservableCollection<RootModel>();
		}
	}
}
