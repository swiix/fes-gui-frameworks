using System;
using System.Windows.Input;

namespace fes_gui_wpf.Utils
{
    /// <summary>
    /// DelegateCommand Klasse um Button Aktionen zu vereinfachen
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
