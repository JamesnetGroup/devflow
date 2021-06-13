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

namespace DevFlow.Finders.Local.Work
{
    internal class LocationWorker
    {
        private readonly Stack<string> _history;
        private FinderViewModel ViewModel;

        private RootModel CurrentDirectory => ViewModel.Current;

        #region LocationWorker

        internal LocationWorker(FinderViewModel vm)
        {
            _history = new();
            ViewModel = vm;
        }
        #endregion

        #region Load

        internal void LoadContent()
        {
            IList<RootModel> child = GetChildDirectories(CurrentDirectory);
            IList<RootModel> items = GetFilesAndDirectories(CurrentDirectory);
            CurrentDirectory.AddRange(child);
            ViewModel.CurrentItems.AddRange(items);
        }
        #endregion

        #region ChangeDirectory

        internal void ChangeDirectory(RootModel root)
        {
            ViewModel.Current = root;
        }
        #endregion

        #region UseAllowundo

        internal bool UseAllowUndo(RootModel p)
        {
            return _history.Count > 1;
        }
        #endregion

        #region UseAllowUp

        internal bool UseAllowUp(RootModel p)
        {
            return RootSupport.TryGetParentDirectory(p?.FullPath, out _);
        }
        #endregion

        #region TryEnqueue

        internal void TryEnqueue(MoveType type)
        {
            bool isEmptyHistory = _history.Count == 0;
            bool isDiffHistory = _history.Count > 0 && _history.Peek() != CurrentDirectory.FullPath;
            bool isUseType = type != MoveType.Undo;

            if (isUseType && (isEmptyHistory || isDiffHistory))
            {
                _history.Push(CurrentDirectory.FullPath);
            }
        }

        #endregion

        #region GetPopByPeek

        private string GetPopByPeek()
        {
            _history.Pop();
            return _history.Peek();
        }

        #endregion
        #region IsCanMoveUp
        #endregion

        #region IsCanMoveUp

        internal bool TryGotoParent()
        {
            bool result = false;
            if (TryParent(CurrentDirectory, out RootModel parent))
            {
                ChangeDirectory(parent);
                result = true;
            }
            return result;
        }
        #endregion

        #region TryParent

        internal bool TryParent(RootModel current, out RootModel root)
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

        #region TryGotoUndo

        internal bool TryGotoUndo()
        {
            bool result = false;
            if (_history.Count > 1)
            {
                string target = GetPopByPeek();
                RootModel root = new RootModel(target, RootIcon.Folder);
                ChangeDirectory(root);
                result = true;
            }
            return result;
        }
        #endregion

        #region TryFind

        private bool TryFind(RootModel current, IList<RootModel> roots, out RootModel root)
        {
            RootModel find = null;

            void Find(RootModel current, IList<RootModel> roots)
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

        #region ForceFocus

        internal void ForceFocus(MoveType type)
        {
            if (type == MoveType.Undo || type == MoveType.Up)
            {
                if (TryFind(CurrentDirectory, ViewModel.Roots, out RootModel item))
                {
                    item.IsSelected = true;
                }
            }
        }
        #endregion

        #region GetRootList

        internal ObservableCollection<RootModel> GetRootList()
        {
            ObservableCollection<RootModel> roots = new();
            int depth = 0;
            RootModel first = new(depth, "MY PC", RootIcon.MyPC, "", true, false);

            depth += 1;

            RootModel down = new(depth, "Downloads", RootIcon.Download, RootSupport.Downloads, false, true);
            RootModel docs = new(depth, "Documents", RootIcon.Document, RootSupport.Documents, false, false);
            RootModel pics = new(depth, "Pictures", RootIcon.Pictures, RootSupport.Pictures, false, false);

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
            roots.Add(first);

            return roots;
        }
        #endregion

        #region GetFilesAndDirectories

        internal List<RootModel> GetFilesAndDirectories(RootModel current)
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

        internal List<RootModel> GetChildDirectories(RootModel current)
        {
            try
            {
                List<RootModel> child = new();

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
    }
}
