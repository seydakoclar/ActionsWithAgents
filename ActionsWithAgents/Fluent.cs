using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing fluents as objects having name and the initial value as properties and
    // three constructors for creating a fluent one with the name value with default initial as false
    // and the other with name and initial value and the last one is from another fluent

    // Initial value represents whether this fluent is hold or not in the initially statement
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
        // Function for changing the initial value
        public void ChangeInit(bool init)
        {
            Initial = init;
        }
    }
}
