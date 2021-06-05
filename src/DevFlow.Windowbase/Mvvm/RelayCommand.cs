using System;
using System.Windows.Input;

namespace DevFlow.Windowbase.Mvvm
{
	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> _execute = null;
		private readonly Predicate<T> _canExecute = null;

		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException("execute");
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute((T)parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			_execute((T)parameter);
		}
	}
}


