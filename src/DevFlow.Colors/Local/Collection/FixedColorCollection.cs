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
	public class ExtractedColorCollection : ObservableCollection<ColorStampModel>
	{
		private RelayCommand<ColorStampModel> colorExtracted;

		internal void Insert(ColorStruct rgba, Action<ColorStampModel> command)
		{
			colorExtracted ??= new RelayCommand<ColorStampModel>(command);

			if (this.FirstOrDefault(x => x.HexColor == ConvertColor.Hex(rgba)) is null)
			{
				this.Insert(0, new ColorStampModel(rgba, colorExtracted));
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
