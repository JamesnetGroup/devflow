using System;
using System.IO;

namespace DevFlow.Finders.Local.Api
{
	public class SystemDirectory
	{
		public static string Downloads => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads");
		public static string Documents => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public static string Pictures => Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
	}
}
