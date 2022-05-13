using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    class Action
    {
        public string Name;

        public Action(string n)
        {
            this.Name = n.ToUpper();
        }
    }
}
