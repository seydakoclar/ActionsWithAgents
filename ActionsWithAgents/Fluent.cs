using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    public class Fluent
    {
        public string Name;
        public bool Initial;

        public Fluent(string n)
        {
            this.Name = n;
            this.Initial = false;
        }
    }
}
