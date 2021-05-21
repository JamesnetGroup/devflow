using DevFlow.Windowbase.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
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
        private string _invertColor;
        private readonly object lockObject = new object();

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

        #region InvertColor 

        public string InvertColor
        {
            get { return _invertColor; }
            set { _invertColor = value; OnPropertyChanged(); }
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
                string r = rgba[0].ToString("X2");
                string g = rgba[1].ToString("X2");
                string b = rgba[2].ToString("X2");
                string a = rgba[3].ToString("X2");
                byte inv = 255;
                string xr = ((byte)(inv - rgba[0])).ToString("X2");
                string xg = ((byte)(inv - rgba[1])).ToString("X2");
                string xb = ((byte)(inv - rgba[2])).ToString("X2");

                CurrentColor = $"#{a}{r}{g}{b}";
                InvertColor = $"#{a}{xr}{xg}{xb}";

                if ((rgba[0] * 0.299 + rgba[1] * 0.587 + rgba[2] * 0.114) > 142)
                {
                    ReverseColor = "#FF000000";
                }
                else
                {
                    ReverseColor = "#FFFFFFFF";
                }

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






