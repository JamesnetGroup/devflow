using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;
using System;
using System.Windows;

namespace DevFlow.Windowbase.Flowcore
{
	public interface IFlowElement : IInputElement
	{
		IFlowElement UseViewModel(ObservableObject vm);
		void Show(MenuModel menu);
		Action<Window> Closed { get; set; }
	}
}
