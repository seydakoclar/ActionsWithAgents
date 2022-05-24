using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing states as objects having list of fluents as property and
    // one constructor for creating a state with the list of fluents
    public class State
    {
        List<Fluent> fluents;
        public State(List<Fluent> _fluents)
        {
            fluents = _fluents;
        }
    }
}