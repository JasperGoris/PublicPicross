using PiCross;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class GameChoiceVM
    {
        public StartupVM StartupVM { get; }



        public GameChoiceVM(StartupVM startup)
        {
            this.StartupVM = startup;

            Puzzle puzzle1 = Puzzle.FromRowStrings(
               "xxxxx",
               "x...x",
               "x...x",
               "x...x",
               "xxxxx"
               );

            Puzzle puzzle2 = Puzzle.FromRowStrings(
               "x.x.x",
               ".x.x.",
               "x.x.x",
               ".x.x.",
               "x.x.x"
               );

            Puzzle puzzle3 = Puzzle.FromRowStrings(
               ".....",
               "..x..",
               ".xxx.",
               "..x..",
               "....."
               );


            this.Puzzles = new ArrayList();

            this.Puzzles.Add(this.StartupVM.PiCrossFacade.CreatePlayablePuzzle(puzzle1));
            this.Puzzles.Add(this.StartupVM.PiCrossFacade.CreatePlayablePuzzle(puzzle2));
            this.Puzzles.Add(this.StartupVM.PiCrossFacade.CreatePlayablePuzzle(puzzle3));




            this.ChoiceSelectedClicked = new ChoiceSelected(StartupVM);



        }

        public ArrayList Puzzles { get; }
        
        public ICommand ChoiceSelectedClicked { get; }
        

        


    }

    public class ChoiceSelected : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private StartupVM Startup { get; }

        public ChoiceSelected(StartupVM startup)
        {
            this.Startup = startup;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var puzzle = parameter as IPlayablePuzzle;
            this.Startup.Newgame(puzzle);
        }
    }
}
