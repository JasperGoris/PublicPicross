using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PuzzleVM 
    {
        private readonly IPlayablePuzzle wrapped;

        public StartupVM StartupVM { get; }
        public PiCrossFacade PiCrossFacade { get; }


        public PuzzleVM(StartupVM startup)
        {
            var puzzle = Puzzle.FromRowStrings(
               "xxxxx",
               "x...x",
               "x...x",
               "x...x",
               "xxxxx"
               );
            this.StartupVM = startup;


            this.PiCrossFacade = new PiCrossFacade();
            this.wrapped = PiCrossFacade.CreatePlayablePuzzle(puzzle);
            this.Grid = this.wrapped.Grid.Map(puzzleSquare => new SquareVM(puzzleSquare)).Copy();
        }

        public PuzzleVM(StartupVM startup, Puzzle playablePuzzle)
        {
            var puzzle = playablePuzzle;
            this.StartupVM = startup;


            this.PiCrossFacade = new PiCrossFacade();
            this.wrapped = PiCrossFacade.CreatePlayablePuzzle(puzzle);
            this.Grid = this.wrapped.Grid.Map(puzzleSquare => new SquareVM(puzzleSquare)).Copy();
        }

        public PuzzleVM(StartupVM startup, IPlayablePuzzle IplayablePuzzle)
        {

            this.wrapped = IplayablePuzzle;
            this.StartupVM = startup;
            this.PiCrossFacade = new PiCrossFacade();
            this.Grid = this.wrapped.Grid.Map(puzzleSquare => new SquareVM(puzzleSquare)).Copy();
        }
        public Cell<bool> IsSolved => wrapped.IsSolved;

        public Action Exit { get; set; }

        public IGrid<SquareVM> Grid { get; private set; }

        public IPlayablePuzzle Wrapped { get; private set; }



        public ISequence<IPlayablePuzzleConstraintsVM> ColumnConstraints => wrapped.ColumnConstraints.Map(constraint => new IPlayablePuzzleConstraintsVM(constraint)).Copy();

        public ISequence<IPlayablePuzzleConstraintsVM> RowConstraints => wrapped.RowConstraints.Map(constraint => new IPlayablePuzzleConstraintsVM(constraint)).Copy();

        
    }
}
