using DevFlow.Data;
using System.IO;

namespace DevFlow.Finders.Local.Api
{

    internal sealed record RootIcon
    {
        internal static GeoIcon MyPC => GeoIcon.DesktopClassic;
        internal static GeoIcon Folder => GeoIcon.Folder;
        internal static GeoIcon Download => GeoIcon.ArrowDownBox;
        internal static GeoIcon Document => GeoIcon.TextBox;
        internal static GeoIcon Pictures => GeoIcon.Image;

        #region Parse

        internal static GeoIcon Parse(string file)
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
        #endregion
    }
}
