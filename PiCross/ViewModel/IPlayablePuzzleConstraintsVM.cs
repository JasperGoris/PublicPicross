using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class IPlayablePuzzleConstraintsVM
    {
        private readonly IPlayablePuzzleConstraints wrapped;

        public IPlayablePuzzleConstraintsVM(IPlayablePuzzleConstraints constraints)
        {
            this.wrapped = constraints;
        }

        public ISequence<IPlayablePuzzleConstraintsValueVM> Values => wrapped.Values.Map(constraint => new IPlayablePuzzleConstraintsValueVM(constraint)).Copy();

        public Cell<bool> IsSatisfied => wrapped.IsSatisfied;

    }
}
