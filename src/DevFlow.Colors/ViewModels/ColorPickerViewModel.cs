using DevFlow.Windowbase.Mvvm;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DevFlow.Colors.ViewModels
{
    public class ColorPickerViewModel : ObservableObject
    {
        private string _currentColor;

        private BitmapSource _captureImage;

        public ICommand DragCaptureCommand { get; }
        public bool IsLock { get; private set; }

        public BitmapSource CaptureImage
        {
            get { return _captureImage; }
            set { _captureImage = value; OnPropertyChanged(); }
        }

        public string CurrentColor
        {
            get { return _currentColor; }
            set { _currentColor = value; OnPropertyChanged(); }
        }

        public ColorPickerViewModel()
        {
            DragCaptureCommand = new RelayCommand<object[]>(DragCapture);

            CurrentColor = "Transparent";
        }

        private void DragCapture(object[] obj)
        {
            InteropBitmap bitmap = obj[0] as InteropBitmap;
            object color = obj[1];
            if (!IsLock && bitmap != null && color != null)
            {
                IsLock = true;
                CaptureImage = (BitmapSource)bitmap;
                CurrentColor = color.ToString();
                IsLock = false;
            }
        }
    }
}