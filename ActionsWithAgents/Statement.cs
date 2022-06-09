using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    // This class is for storing statements as objects having agent, fluents, action, statement type and
    // statement sentence as properties and three constructors for creating a statement one with one fluent
    // value which represents the initially statement second with type, agent, fluent and action values which
    // represent the value and effect statements and the last one is with action, agent and two fluents which 
    // represents the effect statement having if in it
    public abstract class Statement
    {
        public string StatementType;//initially, value, effectwithif, effect
        public string StatementSentence; //the sentence of the statement

    }

    public class InitiallyStatement : Statement
    {
        public Fluent fluent;
        public InitiallyStatement(Fluent f)
        {
            StatementType = "initially";
            fluent = f;
            string sentence = "INITIALLY ";
            if (f.Initial == true)
                sentence += f.Name;
            else
                sentence += "-" + f.Name;
            StatementSentence = sentence;
        }
    }

    public class EffectStatement: Statement
    {
        public Agent agent;
        public Action action;
        public Fluent firstFluent;
        public List<Fluent> secondaryFluents;

        public EffectStatement(Agent _ag, Fluent _f, Action _A, List<Fluent> _fluents)
        {
            agent = _ag;
            firstFluent = _f;
            action = _A;
            secondaryFluents = _fluents;
            StatementSentence += _A.Name + " by " + _ag.Name + " causes ";
            if (_f.Initial == true)
                StatementSentence += _f.Name;
            else
                StatementSentence += "-" + _f.Name;

            // effect statement with if
            if (_fluents.Count > 0)
            {
                StatementType = "effectwithif";
                secondaryFluents = _fluents;
                StatementSentence += " if ";
                foreach (Fluent f in _fluents)
                {
                    if(f == _fluents.Last())
                    {
                        if (f.Initial == true)
                            StatementSentence += f.Name;
                        else
                            StatementSentence += "-" + f.Name;
                        
                    }
                    else
                    {
                        if (f.Initial == true)
                            StatementSentence += f.Name + ", ";
                        else
                            StatementSentence += "-" + f.Name + ", ";
                    }
                   
                }
            }
            else //effect statement without if
            {
                StatementType = "effect";
                secondaryFluents = null;
            }
        }
    }

    public class ValueStatement : Statement
    {
        public List<Agent> agents;
        public List<Action> actions;
        public Fluent fluent;

        public ValueStatement(List<Agent> _agents, Fluent _f, List<Action> _actions)
        {
            fluent = _f;
            agents = _agents;
            actions = _actions;
            StatementType = "value";
            if (_f.Initial == true)
                StatementSentence += _f.Name;
            else
                StatementSentence += "-" + _f.Name;
            StatementSentence += " AFTER ";

            Agent[] agentsArr = _agents.ToArray();
            Action[] actionArr = _actions.ToArray();

            for(int i=0; i<agentsArr.Length; i++)
            {
                StatementSentence += "(" + actionArr[i].Name + ", " + agentsArr[i].Name + ")";
                if(i < agentsArr.Length - 1)
                {
                    StatementSentence += ", ";
                }
            }
        }
    }  
}
