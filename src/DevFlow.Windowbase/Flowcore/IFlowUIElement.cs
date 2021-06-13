using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;

namespace DevFlow.Windowbase.Flowcore
{
    public interface IFlowElement
    {
        IFlowElement UseViewModel(ObservableObject vm);
        void OnShow(MenuModel menu);
    }
}
