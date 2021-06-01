﻿using DevFlow.Colors.Local.Capture;
using DevFlow.Data.Colors;
using DevFlow.Serialization.Color;
using DevFlow.Serialization.Data;
using DevFlow.Windowbase.Flowbase;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DevFlow.Colors.ViewModels
{
    public class ColorSpoidViewModel : ObservableObject
    {
        private int _red;
        private int _green;
        private int _blue;
        private string _currentColor;
        private string _reverseColor;
        private string _invertColor;
		private bool _isCaptureColor;
        
        private BitmapSource _captureImage;

        private bool WaitCapture;
        private CaptureProvider Capture;

		#region Commands

		public ICommand PasteCommand { get; }
        public ICommand CaptureCommand { get; }
        #endregion

        #region CaptureImage

        public BitmapSource CaptureImage
		{
			get { return _captureImage; }
			set { _captureImage = value; OnPropertyChanged(); }
		}
        #endregion

        #region IsCaptureColor

        public bool IsCaptureColor
        {
            get { return _isCaptureColor; }
            set { _isCaptureColor = value; OnPropertyChanged(); }
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
			set { _red = value; OnPropertyChanged(); RgbChanged(); }
        }
		#endregion

		#region Green

		public int Green
        {
            get { return _green; }
            set { _green = value; OnPropertyChanged(); RgbChanged(); }
        }
        #endregion

        #region Alpha
        public int Alpha { get; set; } = 255;
		#endregion

		#region Blue

		public int Blue
		{
			get { return _blue; }
			set { _blue = value; OnPropertyChanged(); RgbChanged(); }
		}
		#endregion

		#region ColorMap

		public ObservableCollection<ColorStampModel> ColorMap { get; set; }
		#endregion

		#region Constructor

		public ColorSpoidViewModel()
        {
            CaptureCommand = new RelayCommand<object>(BeginCapture);
            PasteCommand = new RelayCommand<object>(Paste);
            ColorMap = new ObservableCollection<ColorStampModel>();

            Capture = new CaptureProvider();
            Capture.Extract = ShowColor;
            Capture.Exit = () => IsCaptureColor = false;

            ColorStruct color = ConvertColor.Parse(FlowConfig.Config.SpoidColor);

            bool isAdd = false;
            if (color.Green > (65 * 2))
            {
                isAdd = true;
            }

            for (int i = 0; i < 65; i++)
            {
                ShowColor(new byte[] { color.Red, color.Green, color.Blue, color.Alpha });
                color.Green = isAdd ? (byte)(color.Green - 2) : (byte)(color.Green +2);
            }
        }
		#endregion

		protected override void OnLoaded(Control view)
		{
			base.OnLoaded(view);
			((FlowView)view).Window.Closed += Window_Closed;
		}

		#region SetRgb

		private void RgbChanged()
        {
            if (!WaitCapture)
            {
                ShowColor(new byte[] { (byte)Red, (byte)Green, (byte)Blue, (byte)Alpha });
            }
        }
		#endregion

		#region ColorSelected

		void ColorSelected(ColorStampModel color)
        {
            ShowColor(new byte[] { color.Red, color.Green, color.Blue, (byte)Alpha });
        }
        #endregion

        #region BeginCapture

        private void BeginCapture(object obj)
        {
            IsCaptureColor = true;
            Capture.Begin();
        }
		#endregion

		#region ShowColor

		private void ShowColor(byte[] rgba)
        {
            WaitCapture = true;

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

            if (ColorMap.FirstOrDefault(x => x.HexColor == CurrentColor) is null)
            {
                ColorMap.Insert(0, new ColorStampModel
                {
                    HexColor = CurrentColor,
                    Red = rgba[0],
                    Green = rgba[1],
                    Blue = rgba[2],
                    ColorClickCommand = new RelayCommand<ColorStampModel>(ColorSelected)
                });
            }

            if (ColorMap.Count == 65)
            {
                ColorMap.RemoveAt(ColorMap.Count - 1);
            }
            WaitCapture = false;
        }
		#endregion

		#region Paste

		private void Paste(object obj)
        {
            if (obj is "COPY")
            {
                Clipboard.SetText(CurrentColor);
            }
        }
		#endregion

		#region Window_Closed

		private void Window_Closed(object sender, EventArgs e)
        {
            FlowConfig.SaveSpoidColor(CurrentColor);
        }
		#endregion
	}
}






