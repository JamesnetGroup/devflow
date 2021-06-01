using DevFlow.Data.Colors;
using DevFlow.Serialization.Color;
using DevFlow.Serialization.Data;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DevFlow.Colors.Local.Collection
{
	public class FixedColorCollection : ObservableCollection<ColorStamModel>
	{
		private RelayCommand<ColorStamModel> colorSelected;

		internal void Insert(ColorStruct rgba, Action<ColorStamModel> command)
		{
			colorSelected ??= new RelayCommand<ColorStamModel>(command);

			if (this.FirstOrDefault(x => x.HexColor == ConvertColor.GetHex(rgba)) is null)
			{
				this.Insert(0, new ColorStamModel(rgba, colorSelected));
			}
			RemoveLast();
		}

		private void RemoveLast()
		{
			if (this.Count > 65)
			{
				this.RemoveAt(this.Count - 1);
			}
		}
	}
}
