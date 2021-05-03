using DevFlow.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace DevFlow.History.Helper
{
    public class ImageLoader
    {
        public static ImageLoader Instance;

        static ImageLoader()
        {
            Instance = new ImageLoader();
        }

        internal async void LoadAsync(List<HistoryModel> histories)
        {
            foreach (var item in histories)
            {
                item.Image = await GetImage(item.ImagePath);
            }
        }

        private async Task<BitmapImage> GetImage(string imagePath)
        {
            await Task.Delay(1);
            return new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        internal List<HistoryModel> GetHistories(string currentDirectory)
        {
            var histories = new List<HistoryModel>();
            var dir = Environment.CurrentDirectory;
            var history = FindDirectoryByParent(dir);

            int i = 1;

            var files = Directory.GetFiles(history);
            histories = new List<HistoryModel>();
            histories.AddRange(files.Select(x => new HistoryModel { Index = i++, ImagePath = x, Created = new FileInfo(x).CreationTime }));
            
            return histories;
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
