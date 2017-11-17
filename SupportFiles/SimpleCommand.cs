using System;
using System.Windows.Input;

namespace SupportFiles
{
	public class SimpleCommand : ICommand
	{
		private Action _execute;
		
		public SimpleCommand(Action execute)
		{
			_execute = execute;
		}

		public event EventHandler CanExecuteChanged;
		
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_execute();
		}
	}
}