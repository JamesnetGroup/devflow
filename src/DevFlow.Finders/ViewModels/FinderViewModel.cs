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

        private ObservableCollection<RootModel> _roots;
        private List<RootModel> _currentItems;
        private RootModel _current;

        private readonly LocationWorker LocWorker;
        #endregion

        #region ICommands

        public ICommand RootSelectionCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand UpCommand { get; }
        #endregion

        #region Roots 

        public ObservableCollection<RootModel> Roots
        {
            get => _roots;
            set { _roots = value; OnPropertyChanged(); }
        }
        #endregion

        #region CurrentItems

        public List<RootModel> CurrentItems
        {
            get => _currentItems;
            set { _currentItems = value; OnPropertyChanged(); }
        }
        #endregion

        #region Current

        public RootModel Current
        {
            get => _current;
            set { _current = value; OnPropertyChanged(); }
        }
        #endregion

        #region Constructor

        public FinderViewModel()
        {
            LocWorker = new(this);
            Roots = LocWorker.GetRootList();
            CurrentItems = new();

            RootSelectionCommand = new RelayCommand<RootModel>(RootSelected);
            UpCommand = new RelayCommand<RootModel>((p) => GotoParent(MoveType.Up));
            UndoCommand = new RelayCommand<RootModel>((p) => GotoUndo(MoveType.Undo));
        }
        #endregion

        #region RootSelected

        private void RootSelected(RootModel root)
        {
            Current = root;
            ChangeDirectory(MoveType.Click);
        }
        #endregion

        #region DirectoryChange

        private void ChangeDirectory(MoveType type)
        {
            LocWorker.TryEnqueue(type);
            LocWorker.LoadContent();
            LocWorker.ForceFocus(type);
        }
        #endregion

        #region GotoParent

        private void GotoParent(MoveType type)
        {
            if (LocWorker.TryGotoParent())
            {
                ChangeDirectory(type);
            }
        }
        #endregion

        #region GotoUndo

        private void GotoUndo(MoveType type)
        {
            if (LocWorker.TryGotoUndo())
            {
                ChangeDirectory(type);
            }
        }
        #endregion
    }
}

