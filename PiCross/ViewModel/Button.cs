﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class Button : ICommand
    {
        private readonly Action action;

        public event EventHandler CanExecuteChanged;

        public Button(Action action)
        {
            this.action = action;
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