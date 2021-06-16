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
        private FileModel _currentDir;

        private readonly LocationWorker LocWorker;
        #endregion

        #region ICommands

        public ICommand RecordSelectionCommand { get; }
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
        #endregion

		#region History

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
            Roots = new(LocWorker.GetTreeList());
            CurrentItems = new();
            Records = new();

            RootSelectionCommand = new RelayCommand<FileModel>(RootSelected);
            RecordSelectionCommand = new RelayCommand<FileModel>(RecordSelected);
            UpCommand = new RelayCommand<FileModel>((p) => TryGotoParent(MoveType.Up), LocWorker.UseAllowUp);
            UndoCommand = new RelayCommand<FileModel>((p) => TryGotoUndo(MoveType.Undo), LocWorker.UseAllowUndo);
            RedoCommand = new RelayCommand<FileModel>((p) => TryGotoRedo(MoveType.Redo), LocWorker.UseAllowRedo);
        }
        #endregion

        #region RecordSelected

        private void RecordSelected(FileModel root)
        {
            LocWorker.RecordSelect(root);
        }
        #endregion

        #region RootSelected

        private void RootSelected(FileModel root)
        {
            LocWorker.TreeSelect(root);
        }
        #endregion

        #region DirectoryChange

        private void ChangeDirectory(MoveType type)
        {
            LocWorker.TryEnqueue(type);
        }
        #endregion

        private void Refresh(FileModel obj, MoveType type)
        {
            LocWorker.LoadContent();
            LocWorker.SetFocusTreeItem();
        }

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
            LocWorker.UndoSelect();
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

