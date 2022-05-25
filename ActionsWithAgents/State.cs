using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing states as objects having list of fluents and a value to control if it is the initial
    // state or not as property, one constructor for creating a state with the list of fluents and default false initial
    // and other to set fluents and isInitial
    public class State
    {
        public bool isInitial;
        public List<Fluent> fluents;
        public State(List<Fluent> _fluents)
        {
            isInitial = false;
            fluents = _fluents;
        }
        public State(List<Fluent> _fluents, bool initial)
        {
            isInitial = initial;
            fluents = _fluents;
        }
    }
}