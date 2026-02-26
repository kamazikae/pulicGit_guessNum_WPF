using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace pulicGit_guessNum_WPF.Classes
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> _execute, Func<object, bool> _canExecute = null)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
