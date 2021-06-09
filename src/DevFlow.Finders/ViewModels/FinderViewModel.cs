using DevFlow.Data;
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
		private ObservableCollection<RootModel> _roots;
		private List<RootModel> _currentItems;
		private RootModel _currentRoot;

		public ICommand RootSelectionCommand { get; }

		public ObservableCollection<RootModel> Roots
		{
			get { return _roots; }
			set { _roots = value; OnPropertyChanged(); }
		}

		public List<RootModel> CurrentItems
		{
			get { return _currentItems; }
			set { _currentItems = value; OnPropertyChanged(); }
		}

		public RootModel CurrentRoot
		{
			get { return _currentRoot; }
			set { _currentRoot = value; OnPropertyChanged(); }
		}

		public FinderViewModel()
		{
			RootSelectionCommand = new RelayCommand<RootModel>(RootSelectionChanged);
			Roots = new ObservableCollection<RootModel>();
			InitRoots();
		}

		private void InitRoots()
		{
			RootModel myPC = new RootModel(0, "MY PC", GeometryIconStyle.DesktopClassic, true, "");

			void AddChild(RootModel root)
			{
				myPC.Children.Add(root);
			}

			int lv2 = myPC.Depth + 1;
			string downPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads");
			string docuPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string pictPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			AddChild(new RootModel(lv2, "Downloads", GeometryIconStyle.ArrowDownBox, false, downPath));
			AddChild(new RootModel(lv2, "Documents", GeometryIconStyle.TextBox, false, docuPath));
			AddChild(new RootModel(lv2, "Pictures", GeometryIconStyle.Image, false, pictPath));

			var devices = DriveInfo.GetDrives();

			foreach (var device in devices)
			{ 
				AddChild(new RootModel(lv2, $"{device.VolumeLabel} ({device.RootDirectory.FullName.Replace(@"\", "")})", GeometryIconStyle.MicrosoftWindows, false, device.Name));
			}
			Roots.Add(myPC);
		}

		private void RootSelectionChanged(RootModel data)
		{
			CurrentRoot = data;

			if (!string.IsNullOrWhiteSpace(data.FullPath)
				&& Directory.Exists(data.FullPath))
			{
				try
				{
					var dirs = Directory.GetDirectories(data.FullPath);

					foreach (var dir in dirs)
					{
						var item = new RootModel(data.Depth + 1, Path.GetFileName(dir), GeometryIconStyle.Folder, false, dir);
						data.Children.Add(item);
					}

					InitCurrentItems(data);
				}
				catch(Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
		}

		private void InitCurrentItems(RootModel data)
		{
			List<RootModel> items = new();

			var dirs = Directory.GetDirectories(data.FullPath);

			foreach (var dir in dirs)
			{
				var item = new RootModel(data.Depth + 1, Path.GetFileName(dir), GeometryIconStyle.Folder, false, dir);
				items.Add(item);
			}

			var files = Directory.GetDirectories(data.FullPath);

			foreach (var file in files)
			{
				var item = new RootModel(data.Depth + 1, Path.GetFileName(file), GeometryIconStyle.Folder, false, file);
				items.Add(item);
			}

			CurrentItems = items;
		}
	}
}
