using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing actions as objects having name as property and
    // two constructors for creating an action one with the name value and the other
    // from another action
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
