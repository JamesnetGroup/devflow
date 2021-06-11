using DevFlow.Colors.Local.Capture;
using DevFlow.Colors.Local.Collection;
using DevFlow.Data.Colors;
using DevFlow.Serialization.Color;
using DevFlow.Serialization.Data;
using DevFlow.Windowbase.Flowbase;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DevFlow.Colors.ViewModels
{
	public class ColorSpoidViewModel : ObservableObject
	{
		#region Variables

		private int _red;
		private int _green;
		private int _blue;
		private string _currentColor;
		private string _reverseColor;
		private string _contrastColor;
		private bool _isCaptureColor;

		private BitmapSource _captureImage;

		private bool IsCaptureActivated;
		private readonly PixelExtractWorker Capture;
		#endregion

		#region Commands

		public ICommand PasteCommand { get; }
		public ICommand CaptureCommand { get; }
		#endregion

		#region CaptureImage

		public BitmapSource CaptureImage
		{
			get => _captureImage;
			set { _captureImage = value; OnPropertyChanged(); }
		}
		#endregion

		#region IsCaptureColor

		public bool IsColorCapturing
		{
			get => _isCaptureColor;
			set { _isCaptureColor = value; OnPropertyChanged(); }
		}
		#endregion

		#region CurrentColor

		public string CurrentColor
		{
			get => _currentColor;
			set { _currentColor = value; OnPropertyChanged(); }
		}
		#endregion

		#region ReverseColor 

		public string ReverseColor
		{
			get => _reverseColor;
			set { _reverseColor = value; OnPropertyChanged(); }
		}
		#endregion

		#region ContrastColor 

		public string ContrastColor
		{
			get => _contrastColor;
			set { _contrastColor = value; OnPropertyChanged(); }
		}
		#endregion

		#region Red

		public int Red
		{
			get => _red;
			set { _red = value; OnPropertyChanged(); RgbChanged(); }
		}
		#endregion

		#region Green

		public int Green
		{
			get => _green;
			set { _green = value; OnPropertyChanged(); RgbChanged(); }
		}
		#endregion

		#region Alpha
		public int Alpha { get; set; } = 255;
		#endregion

		#region Blue

		public int Blue
		{
			get => _blue;
			set { _blue = value; OnPropertyChanged(); RgbChanged(); }
		}
		#endregion

		#region ExtractedColorSet

		public ExtractedColorCollection ExtractedColorSet { get; set; }
		#endregion

		#region Constructor

		public ColorSpoidViewModel()
		{
			CaptureCommand = new RelayCommand<object>(BeginCapture);
			PasteCommand = new RelayCommand<object>(Paste);
			ExtractedColorSet = new ExtractedColorCollection();

			Capture = new PixelExtractWorker
			{
				StartExtract = ExtractColor,
				FinishExtract = () => IsColorCapturing = false
			};

			ColorStruct color = ConvertColor.Parse(FlowConfig.Config.SpoidColor);

			if (color.Blue < 128)
			{
				_ = color.SetAddBlue(128);
				for (int i = 0; i < 64; i++)
				{
					ExtractColor(color.SetAddBlue(-2));
				}
			}
			else
			{
				_ = color.SetAddBlue(-128);
				for (int i = 0; i < 64; i++)
				{
					ExtractColor(color.SetAddBlue(2));
				}
			}

		}

		#endregion

		#region OnLoaded

		protected override void OnLoaded(Control view)
		{
			base.OnLoaded(view);
			((Window)UIView).Closed += Window_Closed;
		}
		#endregion

		#region RgbChanged

		private void RgbChanged()
		{
			if (!IsCaptureActivated)
			{
				ExtractColor(new ColorStruct(Red, Green, Blue, Alpha));
			}
		}
		#endregion

		#region ColorSelected

		private void ColorSelected(ColorStampModel color)
		{
			ExtractColor(new ColorStruct(color.Red, color.Green, color.Blue, (byte)255));
		}
		#endregion

		#region BeginCapture

		private void BeginCapture(object obj)
		{
			IsColorCapturing = true;
			Capture.Begin();
		}
		#endregion

		#region ExtractColor

		private void ExtractColor(ColorStruct rgba)
		{
			IsCaptureActivated = true;

			CurrentColor = ConvertColor.Hex(rgba);
			ReverseColor = ConvertColor.ReverseHex(rgba);
			ContrastColor = ConvertColor.Contrast(rgba);

			Red = rgba.Red;
			Green = rgba.Green;
			Blue = rgba.Blue;

			ExtractedColorSet.Insert(rgba, ColorSelected);

			IsCaptureActivated = false;
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






