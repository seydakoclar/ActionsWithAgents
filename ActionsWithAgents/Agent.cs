using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
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
