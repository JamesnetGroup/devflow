using DevFlow.Windowbase.Mvvm;
using System.Windows;

namespace DevFlow.Windowbase.Flowcore
{
    public interface IFlowUIElement : IInputElement
	{
		public IFlowUIElement UseMvvm(ObservableObject vm);
	}
}
