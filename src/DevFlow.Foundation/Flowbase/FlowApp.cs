using System.IO;
using System.Windows;
using DevFlow.Data;

namespace DevFlow.Foundation.Flowbase
{
	public class FlowApp : Application
	{
		protected FlowTheme Theme;
		protected FlowCulture Culture;

		public FlowApp()
		{
			InitilizeTheme();
			InitilizeCulture();
		}

		private void InitilizeTheme()
		{
			Theme = new FlowTheme(this)
			{
				BaseAssemblyPath = "/DevFlow.Resources;component/Themes/"
			};
			OnApplyThemeManager();
			Theme.SetDefault(OnSetDefaultTheme(ThemeType.White));
		}

		private void InitilizeCulture()
		{
			Culture = new FlowCulture(this)
			{
				BaseAssemblyPath = "/DevFlow.Resources;component/Themes/Languages"
			};
			OnApplyCultureManager();
			Culture.SetDefault(OnSetDefaultCulture(LanguageType.Korea));
		}

		protected virtual void OnApplyThemeManager()
		{
		}

		protected virtual void OnApplyCultureManager()
		{
		}

		protected virtual ThemeType OnSetDefaultTheme(ThemeType type)
		{
			return type;
		}

		protected virtual LanguageType OnSetDefaultCulture(LanguageType type)
		{
			return type;
		}

		protected void AddTheme(ThemeType type, string fileName)
		{
			AddTheme(type, Theme.BaseAssemblyPath, fileName);
		}

		protected void AddTheme(ThemeType type, string baseAssemblyPath, string fileName)
		{
			Theme.Add(type, Path.Combine(baseAssemblyPath, fileName));
		}

		protected void AddThemeResource(ThemeType type, ResourceDictionary source)
		{
			Theme.Add(type, source);
		}

		protected void AddLanguage(LanguageType type, string fileName)
		{
			AddLanguage(type, Culture.BaseAssemblyPath, fileName);
		}

		protected void AddLanguage(LanguageType type, string baseAssemblyPath, string fileName)
		{
			Culture.Add(type, Path.Combine(baseAssemblyPath, fileName));
		}

		protected void AddLanguageResource(LanguageType type, ResourceDictionary source)
		{
			Culture.Add(type, source);
		}
	}
}
