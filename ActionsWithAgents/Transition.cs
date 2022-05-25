using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing transitions as objects having list of fluents as property and
    // one constructor for creating a transition with two states, one agent and one action. This
    // will be used for simulating graph of the system and then used for executing queries.
    class Transition
    {
        Agent agent;
        Action action;
        State starting;
        State resulting;

        public Transition(Agent ag, Action ac, State s, State r)
        {
            agent = ag;
            action = ac;
            starting = s;
            resulting = r;
        }
    }
}
