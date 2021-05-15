using DevFlow.Data.History;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DevFlow.Histories.Local
{
    public class HistoryImageManager
    {
        public static HistoryImageManager Instance;

        #region Constructor

        static HistoryImageManager()
        {
            Instance = new HistoryImageManager();
            Instance.CreateLocalDirectory("Thumbnail");
            Instance.CreateLocalDirectory("Preview");
        }

        private HistoryImageManager()
        {
        }
        #endregion

        #region Internal

        internal void ThumbnailLoadAsync(List<HistoryModel> histories)
        {
            histories.ForEach(async x => x.Image = await GetImage(x, "Thumbnail", 160, 90));
        }

        internal async void PreviewLoadAsync(HistoryModel value)
        {
            value.PreviewImage = await GetImage(value, "Preview", 836, 470);
        }

        internal List<HistoryModel> GetHistories(string currentDirectory)
        {
            var histories = new List<HistoryModel>();
            var dir = Environment.CurrentDirectory;
            var history = FindDirectoryByParent(dir);

            int i = 0;

            var files = Directory.GetFiles(history);
            histories = new List<HistoryModel>();
            histories.AddRange(files.Select(x => new HistoryModel(i++, x)));

            return histories;
        }
        #endregion

        #region GetImage 

        private async Task<BitmapImage> GetImage(HistoryModel image, string directory, int width, int height)
        {
            await Task.Delay(1);

            string name = Path.GetFileName(image.FileName);
            string savePath = Path.Combine(GetSavePath(directory), name);

            bool isExistsThumbnail = false;
            while (!isExistsThumbnail)
            {
                if (!File.Exists(savePath))
                {
                    Bitmap sourceImage = new Bitmap(image.ImagePath);

                    Size resize = new Size(width, height);
                    Bitmap resizeImage = new Bitmap(sourceImage, resize);
                    resizeImage.Save(savePath, ImageFormat.Png);
                    continue;
                }
                isExistsThumbnail = true;
            }
            return new BitmapImage(new Uri(savePath, UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region FindDirectoryByParent

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
        #endregion

        #region CreateLocalDirectory 

        private void CreateLocalDirectory(string directory)
        {
            var savePath = GetSavePath(directory);
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
        }
        #endregion

        #region GetSavePath 

        private string GetSavePath(string directory)
        {
            string basePath = "DevFlow/Images/History";
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string devflowPath = Path.Combine(localPath, basePath, directory);
            return devflowPath;
        }
        #endregion
    }
}
