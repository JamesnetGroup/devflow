using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;
using System.Windows;

namespace DevFlow.Windowbase.Flowcore
{
	public interface IFlowElement : IInputElement
	{
		IFlowElement UseViewModel(ObservableObject vm);
		void Show(MenuModel menu);
	}
}
