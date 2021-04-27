using DevFlow.Data;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace DevFlow.History.ViewModels
{
    public class HistoryViewModel : ObservableObject
    {
        private HistoryModel _currentImage;

        public List<HistoryModel> Images { get; set; }
        public HistoryModel CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; OnPropertyChanged(); }
        }
        public override void OnInitDesignTime()
        {
            base.OnInitDesignTime();
        }

        public HistoryViewModel()
        {
            var dir = Environment.CurrentDirectory;
            var history = FindDirectoryByParent(dir);

            var files = Directory.GetFiles(history);
            Images = new List<HistoryModel>();
            Images.AddRange(files.Select(x => new HistoryModel { ImagePath = x, Created = new FileInfo(x).CreationTime }));
        }

        private string FindDirectoryByParent(string dir)
        {
            var parentDir = Directory.GetParent(dir);

            var dirs = Directory.GetDirectories(parentDir.FullName);

            foreach (var dir1 in dirs)
            {
                if (dir1.Contains("history"))
                {
                    return dir1;
                }
            }

            return FindDirectoryByParent(parentDir.FullName);
        }
    }
}
