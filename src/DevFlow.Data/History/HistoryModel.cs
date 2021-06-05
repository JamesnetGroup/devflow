using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace DevFlow.Data.History
{
    public class HistoryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private BitmapImage _image;
        private BitmapImage _previewImage;

        #region Index

        public int Index { get; set; }
        #endregion

        #region ImagePath

        public string ImagePath { get; set; }
        #endregion

        #region Image 

        public BitmapImage Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged(); }
        }
        #endregion

        #region PreviewImage

        public BitmapImage PreviewImage
        {
            get { return _previewImage; }
            set { _previewImage = value; OnPropertyChanged(); }
        }
        #endregion

        #region Created

        public DateTime Created { get; set; }
        #endregion

        #region Size

        public long Size { get; set; }
        #endregion

        #region FileName

        public string FileName { get; set; }
        #endregion

        #region Constructor

        public HistoryModel(int index, string x)
        {
            var fi = new FileInfo(x);

            Index = index;
            ImagePath = x;
            FileName = fi.Name;
            Created = fi.CreationTime;
            Size = fi.Length;
        }
        #endregion
    }
}
