using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;
using DataStructures;
using PiCross;

namespace ViewModel
{
    public class SquareVM
    {
        public IPlayablePuzzleSquare Wrapped { get; }

        public ICommand CycleCommand { get; }


        public SquareVM(IPlayablePuzzleSquare square)
        {
            this.Wrapped = square;
            this.CycleCommand = new CycleCommand(this);
        }

        public Cell<Square> Contents => Wrapped.Contents;

        public Vector2D Position => Wrapped.Position;

    }

    public class CycleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private SquareVM vm;
        private bool canExcecute;

        public CycleCommand(SquareVM playablePuzzleSquareViewModel)
        {
            vm = playablePuzzleSquareViewModel;
            canExcecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var square = parameter as IPlayablePuzzleSquare;

            if (square.Contents.Value == Square.EMPTY || square.Contents.Value == Square.UNKNOWN)
            {
                square.Contents.Value = Square.FILLED;
            }
            else
            {
                square.Contents.Value = Square.EMPTY;
            }
        }
    }
}
