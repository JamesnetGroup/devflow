using DevFlow.Data;
using DevFlow.Finders.Local.Model;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DevFlow.Finders.ViewModels
{
	public class FinderViewModel : ObservableObject
	{
		private ObservableCollection<RootModel> _roots;

		public ICommand RootSelectionCommand { get; }

		public ObservableCollection<RootModel> Roots
		{
			get { return _roots; }
			set { _roots = value; OnPropertyChanged(); }
		}

		public FinderViewModel()
		{
			RootSelectionCommand = new RelayCommand<RootModel>(RootSelectionChanged);
			Roots = new ObservableCollection<RootModel>();
			InitRoots();
		}

		private void InitRoots()
		{
			RootModel myPC = new RootModel(0, "MY PC", GeometryIconStyle.DesktopClassic, true);

			void AddChild(RootModel root)
			{
				myPC.Children.Add(root);
			}

			int lv2 = myPC.Depth + 1;
			AddChild(new RootModel(lv2, "Downloads", GeometryIconStyle.ArrowDownBox, false));
			AddChild(new RootModel(lv2, "Documents", GeometryIconStyle.TextBox, false));
			AddChild(new RootModel(lv2, "Pictures", GeometryIconStyle.Image, false));
			AddChild(new RootModel(lv2, "Windows (C:)", GeometryIconStyle.MicrosoftWindows, false));

			Roots.Add(myPC);
		}

		private void RootSelectionChanged(RootModel obj)
		{
		}
	}
}
