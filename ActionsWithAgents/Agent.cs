using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing agents as objects having name as property and
    // two constructors for creating an agent one with the name value and the
    // other from another agent
    public class Agent
    {
        public string Name;
        public Agent(string n)
        {
            Name = n;
        }
        public Agent(Agent a)
        {
            Name = a.Name;
        }
    }
}
