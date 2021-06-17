using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.Local.Work;
using DevFlow.Finders.Views;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DevFlow.Finders.ViewModels
{
	public class FinderViewModel : ObservableObject
	{
		#region Variables 

		private ObservableCollection<FileModel> _roots;
		private List<RootModel> _currentItems;
		private FileModel _currentDir;

		private readonly LocationWorker LocWorker;
		#endregion

		#region ICommands

		public ICommand RecordSelectionCommand { get; }
		public ICommand RootSelectionCommand { get; }
		public ICommand PolygonSelectionCommand { get; }
		public ICommand DoubleClickCommand { get; }
		public ICommand UndoCommand { get; }
		public ICommand RedoCommand { get; }
		public ICommand GoUpCommand { get; }
		#endregion

		#region Roots 

		public ObservableCollection<FileModel> Roots
		{
			get => _roots;
			set { _roots = value; OnPropertyChanged(); }
		}
		#endregion

		#region Records

		public ObservableCollection<FileModel> Records { get; }

		public FileModel Record
		{
			get => _currentDir;
			set { _currentDir = value; OnPropertyChanged(); }
		}
		#endregion

		public string MachineName => Environment.MachineName.ToString();

		#region CurrentItems

		public List<RootModel> CurrentItems
		{
			get => _currentItems;
			set { _currentItems = value; OnPropertyChanged(); }
		}
		#endregion

		#region Constructor

		public FinderViewModel()
		{
			LocWorker = new(this);
			LocWorker.Refresh = Refresh;
			Roots = new(LocWorker.GetNodeList());
			CurrentItems = new();
			Records = new();

			RootSelectionCommand = new RelayCommand<FileModel>(TreeSelected);
			RecordSelectionCommand = new RelayCommand<FileModel>(RecordSelected);
			DoubleClickCommand = new RelayCommand<FileModel>(FileClick);
			PolygonSelectionCommand = new RelayCommand<LocatorModel>(PolygonSelected);

			GoUpCommand = new RelayCommand<FileModel>((p) => LocWorker.GoUpSelect(MoveType.GoUp), (p) => LocWorker.IsUsedGoUp);
			UndoCommand = new RelayCommand<FileModel>((p) => LocWorker.UndoSelect(MoveType.Undo), (p) => LocWorker.IsUsedUndo);
			RedoCommand = new RelayCommand<FileModel>((p) => LocWorker.RedoSelect(MoveType.Redo), (p) => LocWorker.IsUsedRedo);
		}
		#endregion

		#region RecordSelected

		private void RecordSelected(FileModel root)
		{
			LocWorker.RecordSelect(root, MoveType.Record);
		}
		#endregion

		#region TreeSelected

		private void TreeSelected(FileModel root)
		{
			LocWorker.TreeSelect(root, MoveType.TreeSelect);
		}
		#endregion

		#region FileClick

		private void FileClick(FileModel file)
		{
			if (file.IconType == Data.GeoIcon.Folder)
			{
				LocWorker.FolderSelect(file, MoveType.File);
			}
		}
		#endregion

		private void PolygonSelected(LocatorModel loc)
		{
			LocWorker.TreeSelect(new RootModel(loc.FullPath, Data.GeoIcon.Folder), MoveType.TreeSelect);
		}

		#region Refresh

		private void Refresh(FileModel obj, MoveType type)
		{
			LocWorker.GetContent();
			LocWorker.SetNodeFocus(type);
		}
		#endregion
	}
}

