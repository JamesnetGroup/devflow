using DevFlow.Windowbase.Mvvm;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DevFlow.Colors.ViewModels
{
	public class ColorPickerViewModel : ObservableObject
	{
		private BitmapImage _captureImage;

		public ICommand DragCaptureCommand { get; }
        public BitmapImage CaptureImage
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
			Bitmap bitmap = obj[0] as Bitmap;
			Color? color = obj[1] as Color?;

            CaptureImage = Bitmap2BitmapImage(bitmap);
		}

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapImage retval;

            try
            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }
    }
}
