using DevFlow.Data;
using DevFlow.Data.Theme;
using DevFlow.Foundation.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFlow.Skins.ViewModels
{
	public class SwitchSkinViewModel : ObservableObject
	{
		private SkinModel _currentSkin;

		public List<SkinModel> Skins { get; }

		public SkinModel CurrentSkin
		{
			get => _currentSkin;
			set { _currentSkin = value; OnPropertyChanged(); }
		}

		public SwitchSkinViewModel(Action<SkinModel> SkinSelected, ThemeType nowTheme)
		{
			Skins = GetSkins();
			Skins.ForEach(x => x.SelectSkinCommand = new RelayCommand<SkinModel>(SkinSelected));

			CurrentSkin = Skins.First(x => x.Skin == nowTheme);
		}

		#region GetSkins 

		private List<SkinModel> GetSkins()
		{
			List<SkinModel> source = new List<SkinModel>
			{
				new SkinModel("THEME_WHITE", ThemeType.White),
				new SkinModel("THEME_DARK", ThemeType.Dark),
				new SkinModel("THEME_JAMES", ThemeType.James),
				new SkinModel("THEME_ELENA", ThemeType.Elena)
			};
			return source;
		}
		#endregion
	}
}
