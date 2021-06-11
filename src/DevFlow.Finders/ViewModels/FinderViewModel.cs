using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Model;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace DevFlow.Finders.ViewModels
{
	public class FinderViewModel : ObservableObject
	{
		#region Variables 
		private readonly Stack<string> History;

		private ObservableCollection<RootModel> _roots;
		private List<RootModel> _currentItems;
		private RootModel _currentRoot;
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
			Roots = new();
			History = new();
			RootSelectionCommand = new RelayCommand<RootModel>(RootChanged);
			UpCommand = new RelayCommand<RootModel>(MoveUp, (p) => DirectorySupport.TryParent(p?.FullPath, out _));
			UndoCommand = new RelayCommand<RootModel>(Undo, (p) => History.Count > 1);
			LoadRootDirectory();
		}
		#endregion

		#region LoadRootDirectory

		private void LoadRootDirectory()
		{
			int depth = 0;
			RootModel first = new(depth, "MY PC", RootIcon.MyPC, "", true, false);

			depth += 1;

			RootModel down = new(depth, "Downloads", RootIcon.Download, DirectorySupport.Downloads, false, true);
			RootModel docs = new(depth, "Documents", RootIcon.Document, DirectorySupport.Documents, false, false);
			RootModel pics = new(depth, "Pictures", RootIcon.Pictures, DirectorySupport.Pictures, false, false);

			first.Children.Add(down);
			first.Children.Add(docs);
			first.Children.Add(pics);

			foreach (DriveInfo device in DriveInfo.GetDrives())
			{
				string discName = device.RootDirectory.FullName.Replace(@"\", "");
				string rootName = string.Format("{0} ({1})", device.VolumeLabel, discName);
				string fullPath = device.Name;
				GeoIcon icon = GeoIcon.MicrosoftWindows;

				first.Children.Add(new(depth, rootName, icon, fullPath, false, false));
			}
			Roots.Add(first);
		}
		#endregion

		#region RootChanged

		private void RootChanged(RootModel current)
		{
			if ( History.Count == 0 || (History.Count > 0 && History.Peek() != current.FullPath))
			{
				Enqueue(current);
			}

			CurrentRoot = current;
			LoadChild(current);
		}
		#endregion

		#region LoadChild

		private void LoadChild(RootModel current)
		{
			try
			{
				string[] childDirs = Directory.GetDirectories(current.FullPath);
				foreach (string dir in childDirs)
				{
					int depth = current.Depth + 1;
					string fullPath = dir;
					bool isExpanded = false;
					bool isSelected = false;

					RootModel item = new(depth, Path.GetFileName(dir), RootIcon.Folder, fullPath, isExpanded, isSelected);

					current.Children.Add(item);
				}
				LoadCurrentList(current);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region LoadCurrentList

		private void LoadCurrentList(RootModel current)
		{
			int depth = current.Depth + 1;
			GeoIcon icon = GeoIcon.Folder;
			List<RootModel> items = new();

			string[] dirs = Directory.GetDirectories(current.FullPath);
			string[] files = Directory.GetFiles(current.FullPath);

			foreach (string dir in dirs)
			{
				RootModel item = new(depth, Path.GetFileName(dir), icon, dir, false, false);
				items.Add(item);
			}

			foreach (string file in files)
			{
				icon = RootIcon.Parse(file);
				RootModel item = new(depth, Path.GetFileName(file), icon, file, false, false);
				item.Length = new FileInfo(file).Length;
				items.Add(item);
			}

			CurrentItems = items;
		}
		#endregion

		#region MoveUp

		private void MoveUp(RootModel current)
		{
			if (DirectorySupport.TryParent(current.FullPath, out string parent))
			{
				var root = new RootModel(0, Path.GetFileName(parent), RootIcon.Folder, parent, false, false);
				RootChanged(root);
			}
		}
		#endregion

		#region Undo 

		private void Undo(RootModel current)
		{
			var target = PopNext();
			var root = new RootModel(0, Path.GetFileName(target), RootIcon.Folder, target, false, false);
			CurrentRoot = root;
			LoadChild(root);

			try
			{
				FindRoot(root, Roots);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Enqueue

		private void Enqueue(RootModel current)
		{
			History.Push(current.FullPath);
		}
		#endregion

		#region PopNext

		private string PopNext()
		{
			History.Pop();
			return History.Peek();
		}
		#endregion

		private void FindRoot(RootModel current, IList<RootModel> roots)
		{
			foreach (var item in roots)
			{
				if(item.FullPath == current.FullPath)
				{
					item.IsSelected = true;
				}
				FindRoot(current, item.Children);
			}
		}
	}
}

