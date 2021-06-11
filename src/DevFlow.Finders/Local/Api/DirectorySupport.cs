using System;
using System.IO;

namespace DevFlow.Finders.Local.Api
{
	public class DirectorySupport
	{
		public static string Downloads => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads");
		public static string Documents => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public static string Pictures => Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

		public static bool TryParent(string path, out string parentPath)
		{
			try
			{
				DirectoryInfo info = Directory.GetParent(path);
				parentPath = info.FullName;
				return true;
			}
			catch (Exception ex)
			{
				parentPath = null;
				return false;
			}
		}
	}
}
