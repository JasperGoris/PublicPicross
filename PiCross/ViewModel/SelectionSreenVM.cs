using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;


namespace ViewModel
{
    public class SelectionScreenVM
    {
        public SelectionScreenVM(StartupVM startup)
        {
            this.vm = startup;
            this.Start = new Button(() => this.vm.StartGame());
            this.GameChoice = new Button(() => this.vm.GameChoice());


        }

        private StartupVM vm { get; }

        public ICommand Start { get; }
        public ICommand GameChoice { get; }


    }
}
