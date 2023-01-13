using System;
using System.Windows.Input;

namespace AvaloniaMVVMExplorer.ViewModels.Commands
{
    internal class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<object> command;

        public DelegateCommand(Action<object> command)
        {
            this.command = command;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                command?.Invoke(parameter);
            }
        }
    }
}