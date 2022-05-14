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
            Name = n;
            Initial = false;
        }

        public Fluent(string n, bool init)
        {
            Name = n;
            Initial = init;
        }

        public Fluent(Fluent f)
        {
            Name = f.Name;
            Initial = f.Initial;

        }
        public void ChangeInit(bool init)
        {
            Initial = init;
        }
    }
}
