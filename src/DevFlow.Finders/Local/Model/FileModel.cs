using DevFlow.Data;
using DevFlow.Windowbase.Mvvm;
using System.Collections.Generic;

namespace DevFlow.Finders.Local.Model
{
	public class FileModel : ObservableData
	{
        private bool _isSelected;
        private bool _isDenied;

        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Depth { get; set; }
        public GeoIcon IconType { get; protected set; }

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

        internal virtual void AddRange(IList<FileModel> rootModels)
        {
        }
    }
}
