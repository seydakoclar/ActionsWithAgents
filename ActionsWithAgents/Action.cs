using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    public class Action
    {
        public string Name;

        public Action(string n)
        {
            Name = n.ToUpper();
        }

        public Action(Action a)
        {
            Name = a.Name;
        }
    }
}
