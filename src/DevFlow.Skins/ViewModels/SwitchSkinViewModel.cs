using DevFlow.Data;
using DevFlow.Data.Theme;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFlow.Skins.ViewModels
{
	public class SwitchSkinViewModel : ObservableObject
	{
		private SkinModel _currentSkin;

		public List<SkinModel> Skins { get; }

		public SkinModel CurrentSkin
		{
			get { return _currentSkin; }
			set { _currentSkin = value; OnPropertyChanged(); }
		}

		public SwitchSkinViewModel(Action<SkinModel> SkinSelected, ThemeType nowTheme)
		{
			Skins = GetSkins();
			Skins.ForEach(x => x.SelectSkinCommand = new RelayCommand<SkinModel>(SkinSelected));

			CurrentSkin = Skins.First(x=>x.Skin == nowTheme);
		}

		private List<SkinModel> GetSkins()
		{
			List<SkinModel> source = new List<SkinModel>
			{
				new SkinModel("White", ThemeType.White),
				new SkinModel("Dark", ThemeType.Dark),
				new SkinModel("Dimmed", ThemeType.Dark)
			};
			return source;
		}
	}
}
