using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StartupVM :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private object currentWindow;

        public object CurrentWindow
        {
            get
            {
                return currentWindow;
            }
            private set
            {
                currentWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentWindow)));
            }
        }

        internal void StartGame()
        {
            this.CurrentWindow = new PuzzleVM(this);
        }

        internal void GameChoice()
        {
            this.CurrentWindow = new GameChoiceVM(this);
        }

       
        internal void Newgame(IPlayablePuzzle puzzle)
        {
            this.CurrentWindow = new PuzzleVM(this, puzzle);
        }


        public PiCrossFacade PiCrossFacade { get; }


        public StartupVM()
        {
            this.currentWindow = new SelectionScreenVM(this);
            this.PiCrossFacade = new PiCrossFacade();
        }




    }
}
