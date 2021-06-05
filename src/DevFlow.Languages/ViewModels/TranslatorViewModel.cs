using DevFlow.Data;
using DevFlow.Data.Language;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFlow.Languages.ViewModels
{
    public class TranslatorViewModel : ObservableObject
	{
		private LanguageModel _currentLanguage;

		public List<LanguageModel> Languages { get; }

		public LanguageModel CurrentLanguage
		{
			get => _currentLanguage;
			set { _currentLanguage = value; OnPropertyChanged(); }
		}

		public TranslatorViewModel(Action<LanguageModel> LanguageChanged, LanguageType languageType)
		{
			Languages = GetLanguages();
			Languages.ForEach(x => x.LanguageClickCommand = new RelayCommand<LanguageModel>(LanguageChanged));
			CurrentLanguage = Languages.First(x => x.Language == languageType);
		}

		#region GetLanguages 

		private List<LanguageModel> GetLanguages()
		{
			List<LanguageModel> source = new List<LanguageModel>
			{
				new LanguageModel("UNITED_STATES", LanguageType.UnitedStates),
				new LanguageModel("KOREA", LanguageType.Korea),
				new LanguageModel("CHINA", LanguageType.China),
				new LanguageModel("JAPAN", LanguageType.Japan),
			};
			return source;
		}
		#endregion
	}
}
