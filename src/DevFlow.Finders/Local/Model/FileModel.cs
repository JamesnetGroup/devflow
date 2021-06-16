using DevFlow.Data;
using DevFlow.Extensions;
using DevFlow.Windowbase.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevFlow.Finders.Local.Model
{
	public class FileModel : ObservableData
	{
		private bool _isSelected;
		private bool _isDenied;
		private bool _isExpanded;

		public string Name { get; set; }
		public string FullPath { get; set; }
		public int Depth { get; set; }
		public long Length { get; set; }
		public GeoIcon IconType { get; protected set; }
		public ObservableCollection<FileModel> Children { get; set; }

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

		public bool IsDenied
		{
			get => _isDenied;
			set { _isDenied = value; OnPropertyChanged(); }
		}

		internal void AddRange(List<FileModel> rootModels)
		{
			Children.AddRange(rootModels);
		}
	}
}
