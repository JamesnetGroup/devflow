using DevFlow.Data;
using DevFlow.Finders.Local.Api;
using DevFlow.Finders.Local.Enum;
using DevFlow.Finders.Local.Model;
using DevFlow.Finders.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DevFlow.Finders.Local.Work
{
    internal class LocationWorker
    {
        internal Action<FileModel, MoveType> Refresh = (file, type) => { };


        private readonly Stack<DirModel> Memento;
        private readonly Stack<DirModel> ReMemento;
        private FinderViewModel ViewModel;

        private FileModel Current => ViewModel.Record;

        public bool IsFreezingRecord { get; private set; } = true;


        // Internal Methods.

        #region Constructor

        internal LocationWorker(FinderViewModel vm)
        {
            Memento = new();
            ReMemento = new();
            ViewModel = vm;
        }
        #endregion

        #region UseAllowundo

        internal bool UseAllowUndo(FileModel p)
        {
            return Memento.Count > 1;
        }
        #endregion

        #region UseAllowRedo

        internal bool UseAllowRedo(FileModel p)
        {
            return ReMemento.Count > 0;
        }
        #endregion

        #region UseAllowUp

        internal bool UseAllowUp(FileModel p)
        {
            return RootSupport.TryGetParentDirectory(p?.FullPath, out _);
        }
        #endregion

        #region LoadContent

        internal void LoadContent()
        {
            IList<FileModel> child = GetChildDirectories(Current);
            IList<RootModel> items = GetFilesAndDirectories(Current);

            Current.AddRange(child);
            ViewModel.CurrentItems = new(items);
        }
        #endregion

        #region TryEnqueue

        internal void TryEnqueue(MoveType type)
        {
            bool isEmptyHistory = Memento.Count == 0;
            //bool isDiffHistory = SavedStack.Count > 0 && SavedStack.Peek() != CurrentDirectory.FullPath;
            bool isUseType = type != MoveType.Undo;

            if (isUseType)
            {
                DirModel history = new(Current.FullPath, GeoIcon.Folder);

                Memento.Push(history);
                AddRecord(history);
            }
        }

        #endregion

        #region GotoParent

        internal bool GotoParent()
        {
            bool result = false;
            if (TryParent(Current, out RootModel parent))
            {
                ReMemento.Clear();
                ChangeRecord(parent, MoveType.Up);
                result = true;
            }
            return result;
        }
        #endregion

        #region GotoUndo

        internal bool GotoUndo()
        {
            bool result = false;
            if (UseAllowUndo(null))
            {
                string target = UndoHistory();
                RootModel root = new RootModel(target, RootIcon.Folder);
                ChangeRecord(root, MoveType.Undo);
                result = true;
            }
            return result;
        }
        #endregion

        #region GotoRedo

        internal bool GotoRedo()
        {
            bool result = false;
            if (UseAllowRedo(null))
            {
                var target = ReMemento.Pop();
                RootModel root = new RootModel(target.FullPath, RootIcon.Folder);
                ChangeRecord(root, MoveType.Redo);
                result = true;
            }
            return result;
        }
        #endregion

        #region SetFocusTreeItem

        internal void SetFocusTreeItem()
        {
            //if (type != MoveType.Click)
            {
                if (TryFind(Current, ViewModel.Roots, out RootModel item))
                {
                    item.IsSelected = true;
                }
            }
        }
        #endregion

        #region GetTreeList

        internal List<FileModel> GetTreeList()
        {
            List<FileModel> roots = new();
            int depth = 0;
            //RootModel first = new(depth, "MY PC", RootIcon.MyPC, "", true, false);

            depth += 1;

            RootModel down = new(depth, "Downloads", RootIcon.Download, RootSupport.Downloads, false, true);
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

        internal void HistoryBack(DirModel value)
        {
            while (true)
            {
                if (value == Memento.Peek())
                {
                    break;
                }
                GotoUndo();
            }
        }

        // Private Methods..

        #region UndoHistory

        private string UndoHistory()
        {
            var target = Memento.Pop();
            ReMemento.Push(target);
            var peek = Memento.Peek();

            RemoveHistory();
            return peek.FullPath;
        }
        #endregion

        #region TryParent

        private bool TryParent(FileModel current, out RootModel root)
        {
            root = null;
            bool result = false;

            if (RootSupport.TryGetParentDirectory(current.FullPath, out string parent))
            {
                root = new RootModel(parent, RootIcon.Folder);
                result = true;
            }
            return result;
        }

        #endregion

        #region TryFind

        private bool TryFind(FileModel current, IList<FileModel> roots, out RootModel root)
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

        #region GetFilesAndDirectories

        private List<RootModel> GetFilesAndDirectories(FileModel current)
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

        #region GetChildDirectores

        private List<FileModel> GetChildDirectories(FileModel current)
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

        #region RemoveHistory

        private void RemoveHistory()
        {
            if (ViewModel.Records.First() is DirModel target)
            {
                ViewModel.Records.Remove(target);
            }
        }
        #endregion

        internal void RecordSelect(FileModel dir)
        {
            if (!IsFreezingRecord)
            {
                Dequeue(dir);
                Refresh(dir, MoveType.TreeSelect);
            }
            else
            {
                IsFreezingRecord = false;
            }
        }

		#region TreeSelect

		internal void TreeSelect(FileModel dir)
        {
			MoveType type = MoveType.TreeSelect;

            if (TryAccess(dir))
            {
                var record = Enqueue(dir);
                ChangeRecord(record, type);
                Refresh(record, type);
            }
        }
		#endregion

		#region UndoSelect

		internal void UndoSelect()
		{

		}
        #endregion


        #region Change

        internal void ChangeRecord(FileModel root, MoveType type)
        {
            IsFreezingRecord = true;
            ViewModel.Record = root;
        }
        #endregion

        #region Enqueue

        private DirModel Enqueue(FileModel dir)
        {
            DirModel copyDir = new(dir.FullPath, GeoIcon.Folder);

            PushMemento(copyDir);
            AddRecord(copyDir);

            return copyDir;
        }

        private void Dequeue(FileModel dir)
        {
            while (true)
            {
                if (dir == Memento.Peek())
                {
                    break;
                }
                Undo(dir);
            }
        }

		private void Undo(FileModel dir)
		{
            var pop = Memento.Pop();

            IsFreezingRecord = true;
            ViewModel.Records.RemoveAt(0);
		}

		#endregion

		#region AddRecord

		private void AddRecord(DirModel history)
        {
            ViewModel.Records.Insert(0, history);
        }
		#endregion

		#region PushMemento

		private void PushMemento(DirModel copyDir)
        {
            Memento.Push(copyDir);
        }
		#endregion

		#region TryAccess

		private bool TryAccess(FileModel root)
        {
            bool isAccess = true;

            if (!RootSupport.CheckAccess(root.FullPath))
            {
                isAccess = false;
                root.IsDenied = true;
            }
            return isAccess;
        }
		#endregion
	}
}
