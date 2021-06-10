﻿using DevFlow.Windowbase.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace DevFlow.Windowbase.Flowbase
{
	public class FlowWindow : Window
	{
		//public Action<Window> Closed { get; set; }

		public FlowWindow()
		{
			Loaded += FlowWindow_Loaded;
		}

		//#region UseMvvm

		//public IFlowElement UseViewModel(ObservableObject vm)
		//{
		//	DataContext = vm;
		//	return this;
		//}
		//#endregion

		#region OnDesignerMode

		protected virtual void OnDesignerMode()
		{

		}

		#endregion

		private void FlowWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (DesignerProperties.GetIsInDesignMode(this))
			{
				OnDesignerMode();
			}

			if (DataContext is ObservableObject vm)
			{
				vm.ViewRegister(this);
			}
		}
	}
}