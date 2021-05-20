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
        private string _reverseColor;
        private object lockObject = new object();

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

        public string ReverseColor
        {
            get { return _reverseColor; }
            set { _reverseColor = value; OnPropertyChanged(); }
        }

        public ColorPickerViewModel()
        {
            DragCaptureCommand = new RelayCommand<byte[]>(DragCapture);

            CurrentColor = "Transparent";
        }

        private void DragCapture(byte[] rgba)
        {

            lock (lockObject)
            {
                var r = rgba[0].ToString("X2");
                var g = rgba[1].ToString("X2");
                var b = rgba[2].ToString("X2");
                var a = rgba[3].ToString("X2");
                byte inv = 255;
                var xr = ((byte)(inv - rgba[0])).ToString("X2");
                var xg = ((byte)(inv - rgba[1])).ToString("X2");
                var xb = ((byte)(inv - rgba[2])).ToString("X2");

                CurrentColor = $"#{a}{r}{g}{b}";
                ReverseColor = $"#{a}{xr}{xg}{xb}";
            }
        }
    }
}