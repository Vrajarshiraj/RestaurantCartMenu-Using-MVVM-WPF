using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RestaurantMenuCart.Command
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action action;

        public RelayCommand(Action actionInput)
        {
            action = actionInput;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
