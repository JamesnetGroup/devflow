using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevFlow.Data;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowCulture
	{
		public string BaseAssemblyPath;

		private readonly FlowApp App;
		private readonly Collection<ResourceDictionary> Resources;
		private readonly Dictionary<LanguageType, ResourceDictionary> Cultures;
		private ResourceDictionary CurrentResource;
		private LanguageType CurrentCulture;


		internal FlowCulture(FlowApp app)
		{
			App = app;
			Resources = App.Resources.MergedDictionaries;
			Cultures = new();
		}

		internal void SetDefault(LanguageType lang)
		{
			CurrentResource = Cultures[lang];
			CurrentCulture = lang;
			Switch(lang);
		}

		public void Switch(LanguageType lang)
		{
			if (Resources.Contains(CurrentResource))
			{
				_ = Resources.Remove(CurrentResource);
			}
			CurrentResource = Cultures[lang];
			CurrentCulture = lang;
			Resources.Add(CurrentResource);
		}

		internal void Add(LanguageType type, ResourceDictionary source)
		{
			Cultures.Add(type, source);
		}

		public LanguageType GetCurrentLanguage()
		{
			return CurrentCulture;
		}

		internal void Add(LanguageType type, string source, UriKind kind)
		{
			Add(type, new ResourceDictionary { Source = new Uri(source, kind) });
		}

		internal void Add(LanguageType type, string source)
		{
			Add(type, source, UriKind.RelativeOrAbsolute);
		}
	}
}
