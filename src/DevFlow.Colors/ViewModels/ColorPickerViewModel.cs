using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.ObjectModel;
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
        private int _red;
        private int _green;
        private int _blue;
        private string _currentColor;
        private string _reverseColor;
        private object lockObject = new object();

        private BitmapSource _captureImage;

		#region Commands

		public ICommand DragCaptureCommand { get; }
		#endregion

		#region CaptureImage

		public BitmapSource CaptureImage
        {
            get { return _captureImage; }
            set { _captureImage = value; OnPropertyChanged(); }
        }
		#endregion

		#region CurrentColor

		public string CurrentColor
        {
            get { return _currentColor; }
            set { _currentColor = value; OnPropertyChanged(); }
        }
		#endregion

		#region ReverseColor 

		public string ReverseColor
        {
            get { return _reverseColor; }
            set { _reverseColor = value; OnPropertyChanged(); }
        }
		#endregion

		#region Red

        public int Red
        {
			get { return _red; }
			set { _red = value; OnPropertyChanged(); }
        }
        #endregion

        #region Green

        public int Green
        {
            get { return _green; }
            set { _green = value; OnPropertyChanged(); }
        }
        #endregion

        #region Blue

        public int Blue
        {
            get { return _blue; }
            set { _blue = value; OnPropertyChanged(); }
        }
        #endregion

        public ObservableCollection<string> Colors { get; set; }

		#region Constructor

		public ColorPickerViewModel()
        {
            DragCaptureCommand = new RelayCommand<byte[]>(DragCapture);
            Colors = new ObservableCollection<string>();

            CurrentColor = "Transparent";
        }
		#endregion

		#region DragCapture

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

                Red = rgba[0];
                Green = rgba[1];
                Blue = rgba[2];

                if (!Colors.Contains(CurrentColor))
                {
                    Colors.Add(CurrentColor);
                }
                if (Colors.Count == 50)
                {
                    Colors.RemoveAt(0);
                }
            }
        }
		#endregion
	}
}