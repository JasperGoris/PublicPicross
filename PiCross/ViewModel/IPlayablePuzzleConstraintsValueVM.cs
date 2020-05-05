using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class IPlayablePuzzleConstraintsValueVM
    {
        private readonly IPlayablePuzzleConstraintsValue wrapped;

        public IPlayablePuzzleConstraintsValueVM(IPlayablePuzzleConstraintsValue value)
        {
            this.wrapped = value;
        }

        public int Value => wrapped.Value;
        public Cell<bool> IsSatisfied => wrapped.IsSatisfied;

    }
}
