using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.Local.Work;
using DevFlow.Windowbase.Mvvm;
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
			GoUpCommand = new RelayCommand<FileModel>((p) => LocWorker.GoUpSelect(MoveType.GoUp), LocWorker.UseAllowGoUp);
			UndoCommand = new RelayCommand<FileModel>((p) => LocWorker.UndoSelect(MoveType.Undo), LocWorker.UseAllowUndo);
			RedoCommand = new RelayCommand<FileModel>((p) => LocWorker.RedoSelect(MoveType.Redo), LocWorker.UseAllowRedo);
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

		#region Refresh

		private void Refresh(FileModel obj, MoveType type)
		{
			LocWorker.GetContent();
			LocWorker.SetNodeFocus(type);
		}
		#endregion
	}
}

