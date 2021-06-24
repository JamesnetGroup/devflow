using DevFlow.Foundation.Mvvm;
using System;
using System.Windows.Input;

namespace DevFlow.Finders.Local.Model
{
	public class LocatorModel : FileModel
	{
		public int Zindex { get; set; }
		public string Color { get; set; }
		public bool IsRoot { get; set; }
		public bool IsLast { get; set; }

		public ICommand PolygonClick { get; }

		public LocatorModel(string name, string fullName, Action<FileModel> polygonClick)
		{
			Name = name;
			FullPath = fullName;
			PolygonClick = new RelayCommand<FileModel>(polygonClick); 
			IconType = Data.GeoIcon.Folder;
		}
	}
}
