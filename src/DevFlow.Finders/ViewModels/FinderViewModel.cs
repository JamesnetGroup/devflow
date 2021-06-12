using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.Local.Work;
using DevFlow.Windowbase.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace DevFlow.Finders.ViewModels
{
    public class FinderViewModel : ObservableObject
	{
		#region Variables 

		private ObservableCollection<RootModel> _roots;
		private List<RootModel> _currentItems;
		private RootModel _currentRoot;

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

		#region CurrentRoot

		public RootModel CurrentRoot
		{
			get => _currentRoot;
			set { _currentRoot = value; OnPropertyChanged(); }
		}
		#endregion

		#region Constructor

		public FinderViewModel()
		{
			LocWorker = new(this);
			Roots = LocWorker.GetRootList();

			RootSelectionCommand = new RelayCommand<RootModel>(TreeViewSelected);
			UpCommand = new RelayCommand<RootModel>(MoveUp, (p) => LocWorker.UseAllowUp(p));
			UndoCommand = new RelayCommand<RootModel>(MoveUndo, (p) => LocWorker.UseAllowUndo(p));	
		}
		#endregion

		#region TreeViewSelected

		private void TreeViewSelected(RootModel current)
		{
			TreeViewSelected(current, MoveType.Click);
		}

		private void TreeViewSelected(MoveType type)
		{
			TreeViewSelected(CurrentRoot, type);
		}

		private void TreeViewSelected(RootModel current, MoveType type)
		{			
			LocWorker.TryEnqueue(type, current);
			LocWorker.RootSelection(current);
			LocWorker.Load(current);
			LocWorker.ForceFocus(type);
		}
		#endregion

		#region MoveUp

		private void MoveUp(RootModel current)
		{
			if (LocWorker.IsCanMoveUp)
			{
				TreeViewSelected(MoveType.Up);
			}
		}
		#endregion

		#region MoveUndo

		private void MoveUndo(RootModel data)
		{
			if (LocWorker.IsCanMoveUndo)
			{
				TreeViewSelected(MoveType.Undo);
			}
		}
		#endregion
    }
}

