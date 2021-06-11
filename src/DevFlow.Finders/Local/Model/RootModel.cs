using DevFlow.Data;
using DevFlow.Windowbase.Mvvm;
using System.Collections.ObjectModel;

namespace DevFlow.Finders.Local.Model
{
	public class RootModel : ObservableData
	{
		private bool _isExpanded;
		private bool _isSelected;

		public string FullPath { get; set; }

		public int Depth { get; }

		public string Name { get; set; }

		public long Length { get; set; }

		public bool IsExpanded
		{
			get => _isExpanded;
			set { _isExpanded = value; OnPropertyChanged(); }
		}

		public bool IsSelected
		{
			get => _isSelected;
			set { _isSelected = value; OnPropertyChanged(); }
		}

		public GeoIcon IconType { get; }

		public ObservableCollection<RootModel> Children { get; private set; }

		public RootModel(int depth, string name, GeoIcon icon, string fullPath, bool isExpanded, bool isSelected)
		{
			FullPath = fullPath;
			Depth = depth;
			Name = name;
			IconType = icon;
			IsExpanded = isExpanded;
			IsSelected = isSelected;
			Children = new ObservableCollection<RootModel>();
		}
	}
}
