using DevFlow.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            CreateLocalDirectory();
            Instance = new ImageLoader();
        }

        internal async void LoadThumbnailAsync(List<HistoryModel> histories)
        {
            foreach (var item in histories)
            {
                item.Image = await GetImage(item.ImagePath);
            }
        }

        private async Task<BitmapImage> GetImage(string imagePath)
        {
            await Task.Delay(1);

            string name = Path.GetFileName(imagePath);
            string savePath = Path.Combine( GetSavePath(), name);

            bool isExistsThumbnail = false;
            while (!isExistsThumbnail)
            {
                if (!File.Exists(savePath))
                {
                    Bitmap sourceImage = new Bitmap(imagePath);

                    int width = 160;
                    int height = 90;
                    Size resize = new Size(width, height);
                    Bitmap resizeImage = new Bitmap(sourceImage, resize);
                    resizeImage.Save(savePath, ImageFormat.Png);
                    continue;
                }
                isExistsThumbnail = true;
            }
            return new BitmapImage(new Uri(savePath, UriKind.RelativeOrAbsolute));
        }

		internal List<HistoryModel> GetHistories(string currentDirectory)
        {
            var histories = new List<HistoryModel>();
            var dir = Environment.CurrentDirectory;
            var history = FindDirectoryByParent(dir);

            int i = 1;

            var files = Directory.GetFiles(history);
            histories = new List<HistoryModel>();
            histories.AddRange(files.Select(x => new HistoryModel { Index = i++, ImagePath = x, Created = new FileInfo(x).CreationTime, Size = new FileInfo(x).Length }));
            
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

        private static void CreateLocalDirectory()
        {
            var savePath = GetSavePath();
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
        }

        private static string GetSavePath()
        { 
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string devflowPath = Path.Combine(localPath, "DevFlow/Images/HistoryThumbnails");
            return devflowPath;
        }
    }
}
