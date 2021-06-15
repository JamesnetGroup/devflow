using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.Local.Work;
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
        private FileModel _currentDirectory;
        private HistoryFileModel _currentHistory;

        private readonly LocationWorker LocWorker;
        #endregion

        #region ICommands

        public ICommand RootSelectionCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand UpCommand { get; }
        #endregion

        #region Roots 

        public ObservableCollection<FileModel> Roots
        {
            get => _roots;
            set { _roots = value; OnPropertyChanged(); }
        }
        public FileModel CurrentDirectory
        {
            get => _currentDirectory;
            set { _currentDirectory = value; OnPropertyChanged(); }
        }
        #endregion

		#region History

		public ObservableCollection<HistoryFileModel> History { get; }

        public HistoryFileModel CurrentHistory
        {
            get => _currentHistory;
            set { _currentHistory = value; OnPropertyChanged(); HistoryBack(value); }
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
            Roots = new(LocWorker.GetTreeList());
            CurrentItems = new();
            History = new();

            RootSelectionCommand = new RelayCommand<RootModel>(RootSelected);
            UpCommand = new RelayCommand<FileModel>((p) => TryGotoParent(MoveType.Up), LocWorker.UseAllowUp);
            UndoCommand = new RelayCommand<FileModel>((p) => TryGotoUndo(MoveType.Undo), LocWorker.UseAllowUndo);
            RedoCommand = new RelayCommand<FileModel>((p) => TryGotoRedo(MoveType.Redo), LocWorker.UseAllowRedo);
        }
		#endregion

		#region HistoryBack

		private void HistoryBack(HistoryFileModel value)
        {
            if (CurrentDirectory.FullPath != value.FullPath)
            {
                CurrentDirectory = value;
                ChangeDirectory(MoveType.Click);
            }
        }
		#endregion

		#region RootSelected

		private void RootSelected(RootModel root)
        {
            if (RootSupport.CheckAccess(root.FullPath))
            {
                CurrentDirectory = root;
                ChangeDirectory(MoveType.Click);
            }
            else
            {
                root.IsDenied = true;
            }
        }
        #endregion

        #region DirectoryChange

        private void ChangeDirectory(MoveType type)
        {
            LocWorker.TryEnqueue(type);
            LocWorker.LoadContent();
            LocWorker.SetFocusTreeItem(type);
        }
        #endregion

        #region TryGotoParent

        private void TryGotoParent(MoveType type)
        {
            if (LocWorker.GotoParent())
            {
                ChangeDirectory(type);
            }
        }
        #endregion

        #region TryGotoUndo

        private void TryGotoUndo(MoveType type)
        {
			if (LocWorker.GotoUndo())
            {
                ChangeDirectory(type);
            }
        }
        #endregion

        #region TryGotoRedo

        private void TryGotoRedo(MoveType type)
        {
            if (LocWorker.GotoRedo())
            {
                ChangeDirectory(type);
            }
        }
        #endregion
    }
}

