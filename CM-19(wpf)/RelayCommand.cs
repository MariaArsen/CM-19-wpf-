using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CM_19_wpf_
{
    class RelayCommand : ICommand
    {
        public readonly Action<object> execute;
        public readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        public RelayCommand(Action<object> Execute,Func<object,bool>CanExecute=null)
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;


        public void Execute(object parameter) => execute(parameter);
      
    }
}
