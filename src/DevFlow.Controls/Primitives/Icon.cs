using DevFlow.Controls.Util;
using DevFlow.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevFlow.Controls.Primitives
{
	public class Icon : ContentControl
	{
		#region DependencyProperties

		public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(Icon), new PropertyMetadata(Brushes.White));
		public static readonly DependencyProperty IconTypeProperty = DependencyProperty.Register("IconType", typeof(GeoIcon), typeof(Icon), new PropertyMetadata(GeoIcon.None, IconTypePropertyChanged));
		public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(Icon), new PropertyMetadata(null));
		#endregion

		#region Fill

		public Brush Fill
		{
			get => (Brush)GetValue(FillProperty);
			set => SetValue(FillProperty, value);
		}
		#endregion

		#region IconType

		public GeoIcon IconType
		{
			get => (GeoIcon)GetValue(IconTypeProperty);
			set => SetValue(IconTypeProperty, value);
		}
		#endregion

		#region Data

		public Geometry Data
		{
			get => (Geometry)GetValue(DataProperty);
			set => SetValue(DataProperty, value);
		}
		#endregion

		#region IconTypePropertyChanged

		private static void IconTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Icon icon = (Icon)d;

			switch ((GeoIcon)e.NewValue)
			{
				case GeoIcon.Close: icon.Data = IconData.CLOSE.ToGeometry(); break;
				case GeoIcon.CheckCircle: icon.Data = IconData.CHECK_CIRCLE.ToGeometry(); break;
				case GeoIcon.Crop: icon.Data = IconData.CROP.ToGeometry(); break;
				case GeoIcon.MicrosoftVisualStudio: icon.Data = IconData.MICROSOFT_VISUAL_STUDIO.ToGeometry(); break;
				case GeoIcon.MonitorShimmer: icon.Data = IconData.MONITOR_SHIMMER.ToGeometry(); break;
				case GeoIcon.MovieOpenPlay: icon.Data = IconData.MOVIE_OPEN_PLAY.ToGeometry(); break;
				case GeoIcon.GoogleTranslate: icon.Data = IconData.MOVIE_OPEN_PLAY.ToGeometry(); break;
				case GeoIcon.EyedropperVariant: icon.Data = IconData.EYEDROPPER_VARIANT.ToGeometry(); break;
				case GeoIcon.OcgRefreshOutline: icon.Data = IconData.COG_REFRESH_OUTLINE.ToGeometry(); break;
				case GeoIcon.Image: icon.Data = IconData.IMAGE.ToGeometry(); break;
				case GeoIcon.CalendarMonth: icon.Data = IconData.CALENDAR_MONTH.ToGeometry(); break;
				case GeoIcon.Minimize: icon.Data = IconData.WINDOW_MINIMIZE.ToGeometry(); break;
				case GeoIcon.Menu: icon.Data = IconData.MENU.ToGeometry(); break;
				case GeoIcon.Palette: icon.Data = IconData.PALETTE.ToGeometry(); break;
				case GeoIcon.Web: icon.Data = IconData.WEB.ToGeometry(); break;
				case GeoIcon.ContentPaste: icon.Data = IconData.CONTENTPASTE.ToGeometry(); break;
				case GeoIcon.CheckBold: icon.Data = IconData.CHECKBOLD.ToGeometry(); break;
				case GeoIcon.FolderOpenOutline: icon.Data = IconData.FOLDER_OPEN_OUTLINE.ToGeometry(); break;
				case GeoIcon.FolderOpen: icon.Data = IconData.FOLDER_OPEN.ToGeometry(); break;
				case GeoIcon.FolderTable: icon.Data = IconData.FOLDER_TABLE.ToGeometry(); break;
				case GeoIcon.Maximize: icon.Data = IconData.MAXIMIZE.ToGeometry(); break;
				case GeoIcon.Resize: icon.Data = IconData.RESIZE.ToGeometry(); break;
				case GeoIcon.SelectAll: icon.Data = IconData.SELECT_ALL.ToGeometry(); break;
				case GeoIcon.ArrowLeftBold: icon.Data = IconData.ARROW_LEFT_BOLD.ToGeometry(); break;
				case GeoIcon.ArrowRightBold: icon.Data = IconData.ARROW_RIGHT_BOLD.ToGeometry(); break;
				case GeoIcon.ArrowUpBold: icon.Data = IconData.ARROW_UP_BOLD.ToGeometry(); break;
				case GeoIcon.Plus: icon.Data = IconData.PLUS.ToGeometry(); break;
				case GeoIcon.Folder: icon.Data = IconData.FOLDER.ToGeometry(); break;
				case GeoIcon.ConsoleLine: icon.Data = IconData.CONSOLE_LINE.ToGeometry(); break;
				case GeoIcon.ArrowAll: icon.Data = IconData.ARROW_ALL.ToGeometry(); break;
				case GeoIcon.MicrosoftWindows: icon.Data = IconData.MICROSOFT_WINDOWS.ToGeometry(); break;
				case GeoIcon.ArrowDownBox: icon.Data = IconData.ARROW_DOWN_BOX.ToGeometry(); break;
				case GeoIcon.TextBox: icon.Data = IconData.TEXT_BOX.ToGeometry(); break;
				case GeoIcon.Harddisk: icon.Data = IconData.HARDDISK.ToGeometry(); break;
				case GeoIcon.DesktopClassic: icon.Data = IconData.DESKTOP_CLASSIC.ToGeometry(); break;
				case GeoIcon.ChevronRight: icon.Data = IconData.CHEVRON_RIGHT.ToGeometry(); break;
				case GeoIcon.ChevronDown: icon.Data = IconData.CHEVRON_DOWN.ToGeometry(); break;
				case GeoIcon.DotsHorizontalCircle: icon.Data = IconData.DOTS_HORIZONTAL_CIRCLE.ToGeometry(); break;
				case GeoIcon.File: icon.Data = IconData.FILE.ToGeometry(); break;
				case GeoIcon.FileImage: icon.Data = IconData.FILE_IMAGE.ToGeometry(); break;
				case GeoIcon.FilePDF: icon.Data = IconData.FILE_PDF.ToGeometry(); break;
				case GeoIcon.FileZIP: icon.Data = IconData.FILE_ZIP.ToGeometry(); break;
				case GeoIcon.FileCheck: icon.Data = IconData.FILE_CHECK.ToGeometry(); break;
				case GeoIcon.FileWord: icon.Data = IconData.FILE_WORD.ToGeometry(); break;
				case GeoIcon.AlphaR: icon.Data = IconData.ALPHA_R.ToGeometry(); break;
				case GeoIcon.AlphaG: icon.Data = IconData.ALPHA_G.ToGeometry(); break;
				case GeoIcon.AlphaB: icon.Data = IconData.ALPHA_B.ToGeometry(); break;
				case GeoIcon.Check: icon.Data = IconData.CHECK.ToGeometry(); break;
				case GeoIcon.None:
					break;
				default:
					break;
			}
		}
		#endregion
	}
}




