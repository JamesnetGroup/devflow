using DevFlow.Data.Menu;
using DevFlow.Foundation.Mvvm;

namespace DevFlow.Foundation.Flowcore
{
	public interface IFlowElement
	{
		IFlowElement UseViewModel(ObservableObject vm);
		void OnShow(MenuModel menu);
	}
}
