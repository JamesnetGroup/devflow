using DevFlow.Windowbase.Mvvm;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DevFlow.Colors.ViewModels
{
	public class ColorPickerViewModel : ObservableObject
	{
		private BitmapSource _captureImage;

		public ICommand DragCaptureCommand { get; }
        public bool IsLock { get; private set; }

        public BitmapSource CaptureImage
        {
            get { return _captureImage; }
			set { _captureImage = value; OnPropertyChanged(); }
        }

		public ColorPickerViewModel()
		{
			DragCaptureCommand = new RelayCommand<object[]>(DragCapture);
		}

		private void DragCapture(object[] obj)
		{
            InteropBitmap bitmap = obj[0] as InteropBitmap;
			Color? color = obj[1] as Color?;
            if (!IsLock && bitmap != null)
            {
                IsLock = true;
                CaptureImage = (BitmapSource)bitmap;
                IsLock = false;
            }
		}

    }
}
