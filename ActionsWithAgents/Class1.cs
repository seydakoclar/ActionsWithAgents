using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionsWithAgents
{
    class Statement
    {
        public string StatementType; //initially, value, effectwithif, effect
        public string StatementSentence;
        Agent ag;
        Fluent f;
        Action A;
        Fluent f2;

        public Statement(Fluent _f)
        {
            ag = null;
            A = null;
            f2 = null;
            f = _f;
            StatementType = "initially";
            string sentence = "INITIALLY ";
            if (f.Initial == true)
                sentence += f.Name;
            else
                sentence += "-" + f.Name;
            StatementSentence = sentence;
        }
        public Statement(string type, Agent _ag, Fluent _f, Action _A)
        {
            ag = _ag;
            f = _f;
            A = _A;
       
            if(type == "value")
            {
                if (f.Initial == true)
                    StatementSentence = f.Name;
                else
                    StatementSentence = "-" + f.Name;
                StatementSentence += "after " + _A.Name + " by " + _ag.Name;
            }
            else
            {
                StatementSentence += _A.Name + " by " + _ag.Name + "causes ";
                if (f.Initial == true)
                    StatementSentence = f.Name;
                else
                    StatementSentence = "-" + f.Name;
            }
        }
        public Statement(Agent _ag, Fluent _f, Action _A, Fluent _f2)
        {
            ag = _ag;
            f = _f;
            A = _A;
            f2 = _f2;
            StatementSentence += _A.Name + " by " + _ag.Name + "causes ";
            if (f.Initial == true)
                StatementSentence += f.Name;
            else
                StatementSentence += "-" + f.Name;
            StatementSentence += "if ";
            if (f2.Initial == true)
                StatementSentence += f2.Name;
            else
                StatementSentence += "-" + f2.Name;            
        }
    }
}
