using DevFlow.Finders.Local.Model;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevFlow.Finders.ViewModels
{
	public class FinderViewModel : ObservableObject
	{
		private ObservableCollection<RootModel> _roots;
		public ObservableCollection<RootModel> Roots
		{
			get { return _roots; }
			set { _roots = value; OnPropertyChanged(); }
		}

		public FinderViewModel()
		{
			Roots = new ObservableCollection<RootModel>();
			InitRoots();
		}

		private void InitRoots()
		{
			var myPC = new RootModel("MY PC");
			myPC.Children.Add(new RootModel("Downloads"));
			myPC.Children.Add(new RootModel("Documents"));
			myPC.Children.Add(new RootModel("Pictures"));
			myPC.Children.Add(new RootModel("Windows (C:)"));

			Roots.Add(myPC);
		}
	}
}
