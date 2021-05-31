using DevFlow.Windowbase.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevFlow.Windowbase.Flowcore
{
	public interface IFlowUIElement : IInputElement
	{
		IFlowUIElement UseMvvm(ObservableObject vm);
		void Show();
	}
}
