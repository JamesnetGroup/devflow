using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DevFlow.Data
{
    public class HistoryModel : ObservableModel
    {
        private BitmapImage _image;

        public int Index { get; set; }
        public string ImagePath { get; set; }
        public BitmapImage Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged(); }
        }

        public DateTime Created { get; set; }
    }
}
