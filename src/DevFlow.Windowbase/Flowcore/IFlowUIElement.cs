<<<<<<< HEAD
﻿using DevFlow.Windowbase.Mvvm;
=======
﻿using DevFlow.Data.Menu;
using DevFlow.Windowbase.Mvvm;
using System;
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
using System.Windows;

namespace DevFlow.Windowbase.Flowcore
{
<<<<<<< HEAD
    public interface IFlowUIElement : IInputElement
=======
	public interface IFlowElement : IInputElement
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d
	{
		IFlowElement UseViewModel(ObservableObject vm);
		void Show(MenuModel menu);
		Action<Window> Closed { get; set; }
	}
}
