using System;
using System.Windows.Input;

namespace SupportFiles
{
	/// <summary>
	/// Command that runs on a condition
	/// </summary>
	public class RelayCommand : ICommand
	{
		private Action _execute;
		private Func<bool> _canExecute;
		
		public RelayCommand(Func<bool> canExecute, Action execute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute();
		}

		/// <summary>
		/// Method that executes when the command is called
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_execute();
		}
	}
}