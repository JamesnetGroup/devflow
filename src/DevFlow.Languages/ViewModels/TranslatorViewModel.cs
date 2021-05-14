using DevFlow.Data;
using DevFlow.Data.Language;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Languages.ViewModels
{
	public class TranslatorViewModel : ObservableObject
	{
		private LanguageModel _currentLanguage;

		public List<LanguageModel> Languages { get; }

		public LanguageModel CurrentLanguage
		{
			get { return _currentLanguage; }
			set { _currentLanguage = value; OnPropertyChanged(); }
		}

		public TranslatorViewModel()
		{
			Languages = GetLanguages();
		}

		#region GetLanguages 

		private List<LanguageModel> GetLanguages()
		{
			List<LanguageModel> source = new List<LanguageModel>
			{
				new LanguageModel("United States", LanguageType.UnitedStates),
				new LanguageModel("Korea", LanguageType.Korea),
				new LanguageModel("China", LanguageType.China),
				new LanguageModel("Japan", LanguageType.Japan),
			};
			return source;
		}
		#endregion
	}
}
