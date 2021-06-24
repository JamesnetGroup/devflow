﻿using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.Local.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevFlow.Finders.Local.Work
{
	internal class LocationWork
	{
		#region Variables

		private readonly Stack<FolderModel> Memento;
		private readonly Stack<FolderModel> ReMemento;
		private readonly FinderViewModel ViewModel;
		private FileModel Current => ViewModel.Record;

		internal Action<FileModel, MoveType> Refresh;

		internal bool IsUsedUndo => Memento.Count > 1;
		internal bool IsUsedRedo => ReMemento.Count > 0;
		internal bool IsUsedGoUp => RootSupport.TryParent(Current?.FullPath, out _);
		#endregion

		#region Constructor

		internal LocationWork(FinderViewModel vm)
		{
			Memento = new();
			ReMemento = new();
			ViewModel = vm;
		}
		#endregion

		// Internal..♥

		#region GetContent

		internal void GetContent()
		{
			ViewModel.CurrentItems = new(GetFiles(Current));
		}
		#endregion

		#region GetNodeList

		internal List<FileModel> GetNodeList()
		{
			List<FileModel> roots = new();
			int depth = 0;

			depth += 1;

			RootModel down = new(depth, "Downloads", RootIcon.Download, RootSupport.Downloads, false, false);
			RootModel docs = new(depth, "Documents", RootIcon.Document, RootSupport.Documents, false, false);
			RootModel pics = new(depth, "Pictures", RootIcon.Pictures, RootSupport.Pictures, false, false);

			roots.Add(down);
			roots.Add(docs);
			roots.Add(pics);

			foreach (DriveInfo device in DriveInfo.GetDrives())
			{
				string discName = device.RootDirectory.FullName.Replace(@"\", "");
				string rootName = string.Format("{0} ({1})", device.VolumeLabel, discName);
				string fullPath = device.Name;
				GeoIcon icon = GeoIcon.MicrosoftWindows;

				roots.Add(new RootModel(depth, rootName, icon, fullPath, false, false));
			}
			return roots;
		}
		#endregion

		#region SetNodeFocus

		internal void SetNodeFocus(MoveType type)
		{
			MoveType[] moveTypes = { MoveType.Record, MoveType.Undo, MoveType.Redo, MoveType.GoUp, MoveType.File };

			if (FindNode(Current, ViewModel.Roots, out RootModel item))
			{
				if (moveTypes.Contains(type))
				{
					//IsFreezingRoot = true;
					item.IsSelected = true;
				}
				item.AddRange(GetDirectories(item));
			}

		}
		#endregion

		#region RecordSelect

		internal void Record(FileModel dir, MoveType type)
		{
			GotoBack(dir);
			SwitchRecord(Memento.Peek(), type);
			Refresh(dir, type);
		}
		#endregion

		#region Select

		internal void Select(FileModel dir, MoveType type)
		{
			if (CheckDenied(dir) && CheckSame(dir))
			{
				FolderModel record = GotoMove(dir);
				SwitchRecord(record, type);
				Refresh(record, type);
			}
		}
		#endregion

		#region UndoSelect

		internal void UndoSelect(MoveType type)
		{
			GotoBack();
			SwitchRecord(Memento.Peek(), type);
			Refresh(Current, type);
		}
		#endregion

		#region RedoSelect

		internal void RedoSelect(MoveType type)
		{
			FolderModel dir = ReMemento.Pop();
			FolderModel record = GotoMove(dir);
			SwitchRecord(Memento.Peek(), type);
			Refresh(Current, type);
		}
		#endregion

		#region GoUpSelect

		internal void GoUpSelect(MoveType type)
		{
			if (TryGetParent(Current, out RootModel parent))
			{
				FolderModel record = GotoMove(parent);
				SwitchRecord(record, type);
				Refresh(record, type);
			}
		}
		#endregion

		// Private..♥

		#region GetDirectories

		private List<FileModel> GetDirectories(FileModel current)
		{
			try
			{
				List<FileModel> child = new();

				string[] childDirs = Directory.GetDirectories(current.FullPath);
				foreach (string dir in childDirs)
				{
					int depth = current.Depth + 1;
					string fullPath = dir;
					bool isExpanded = false;
					bool isSelected = false;

					RootModel item = new(depth, Path.GetFileName(dir), RootIcon.Folder, fullPath, isExpanded, isSelected);

					child.Add(item);
				}
				return child;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return new();
			}
		}
		#endregion

		#region GetFiles

		private List<RootModel> GetFiles(FileModel current)
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

			return items;
		}
		#endregion

		#region TryGetParent

		private bool TryGetParent(FileModel current, out RootModel root)
		{
			root = null;
			bool result = false;

			if (RootSupport.TryParent(current.FullPath, out string parent))
			{
				root = new RootModel(parent, RootIcon.Folder);
				result = true;
			}
			return result;
		}

		#endregion

		#region SwitchRecord

		private void SwitchRecord(FileModel root, MoveType _)
		{
			ViewModel.Record = root;
		}
		#endregion

		#region GotoMove

		private FolderModel GotoMove(FileModel dir)
		{
			FolderModel copyDir = new(dir.FullPath, GeoIcon.Folder);

			Memento.Push(copyDir);
			ViewModel.Records.Insert(0, copyDir);

			return copyDir;
		}

		#endregion

		#region GotoBack

		private void GotoBack()
		{
			FolderModel pop = Memento.Pop();
			ReMemento.Push(pop);

			_ = ViewModel.Records.Remove(pop);
		}

		private void GotoBack(FileModel dir)
		{
			// TODO James: While문을 대체할 로직 알고리즘 개선이 필요합니다.
			while (true)
			{
				if (dir == Memento.Peek())
				{
					break;
				}
				GotoBack();
			}
		}
		#endregion

		#region CheckDenied

		private bool CheckDenied(FileModel root)
		{
			bool isAccess = true;

			if (!RootSupport.CheckAccess(root.FullPath) || !Directory.Exists(root.FullPath))
			{
				isAccess = false;
				root.IsDenied = true;
			}
			return isAccess;
		}
		#endregion

		#region FindNode

		private bool FindNode(FileModel current, IList<FileModel> roots, out RootModel root)
		{
			RootModel find = null;

			void Find(FileModel current, IList<FileModel> roots)
			{
				foreach (RootModel item in roots)
				{
					if (item.FullPath == current.FullPath)
					{
						find = item;
						return;
					}
					Find(current, item.Children);
				}
			}

			Find(current, roots);
			root = find;

			return find is RootModel;
		}
		#endregion

		#region CheckSame

		private bool CheckSame(FileModel dir)
		{
			if (Memento.Count > 0 && dir.FullPath == Memento.Peek().FullPath)
			{
				return false;
			}
			return true;
		}
		#endregion
	}
}
