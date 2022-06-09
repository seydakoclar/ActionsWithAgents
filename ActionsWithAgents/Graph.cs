using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsWithAgents
{
    public class Graph
    {
        public List<Transition> graphTransitionFunctions;
        public State initialState;
        public State[] states;
        public Graph(State i)
        {
            initialState = i;
            graphTransitionFunctions = null;
            states = null;
        }
        public Graph(List<Transition> g, State[] s)
        {
            states = s;
            graphTransitionFunctions = g;
        }
    }
}
