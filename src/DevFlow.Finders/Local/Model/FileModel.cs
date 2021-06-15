using DevFlow.Data;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Finders.Local.Model
{
	public class FileModel : ObservableData
	{
        private bool _isSelected;

        public string Name { get; set; }
        public string FullPath { get; set; }
        public GeoIcon IconType { get; protected set; }

        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }
    }
}
