using DevFlow.Data;
using System.IO;

namespace DevFlow.Finders.Local.Api
{
	public class FileExtensions
	{
		internal static GeoIcon FindExtIcon(string file)
		{
			GeoIcon ext = GeoIcon.File;
			switch (Path.GetExtension(file).ToUpper())
			{
				case ".JPG":
				case ".JPEG":
				case ".GIF":
				case ".BMP":
				case ".PNG": ext = GeoIcon.FileImage; break;
				case ".PDF": ext = GeoIcon.FilePDF; break;
				case ".ZIP": ext = GeoIcon.FileZIP; break;
				case ".EXE": ext = GeoIcon.FileCheck; break;
				case ".DOCX":
				case ".DOC": ext = GeoIcon.FileWord; break;
			}
			return ext;
		}
	}
}
