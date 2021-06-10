using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Model;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
		#endregion

		#region ICommands

		public ICommand RootSelectionCommand { get; }
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
			RootSelectionCommand = new RelayCommand<RootModel>(RootChanged);
			Roots = new ObservableCollection<RootModel>();
			LoadRootDirectory();
		}
		#endregion

		#region LoadRootDirectory

		private void LoadRootDirectory()
		{
			int depth = 0;
			RootModel first = new(depth, "MY PC", GeoIcon.DesktopClassic, "", true, false);

			depth += 1;

			RootModel down = new(depth, "Downloads", GeoIcon.ArrowDownBox, SystemDirectory.Downloads, false, true);
			RootModel docs = new(depth, "Documents", GeoIcon.TextBox, SystemDirectory.Documents, false, false);
			RootModel pics = new(depth, "Pictures", GeoIcon.Image, SystemDirectory.Pictures, false, false);

			first.Children.Add(down);
			first.Children.Add(docs);
			first.Children.Add(pics);

			foreach (var device in DriveInfo.GetDrives())
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
			try
			{
				CurrentRoot = current;
				string[] childDirs = Directory.GetDirectories(current.FullPath);
				foreach (string dir in childDirs)
				{
					int depth = current.Depth + 1;
					string fullPath = dir;
					bool isExpanded = false;
					bool isSelected = false;
					GeoIcon icon = GeoIcon.Folder;

					RootModel item = new(depth, Path.GetFileName(dir), icon, fullPath, isExpanded, isSelected);

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
				icon = FileExtensions.FindExtIcon(file);
				RootModel item = new(depth, Path.GetFileName(file), icon, file, false, false);
				items.Add(item);
			}

			CurrentItems = items;
		}
		#endregion
	}
}

