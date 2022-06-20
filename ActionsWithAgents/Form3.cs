using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActionsWithAgents
{
    public partial class Form3 : Form
    {
        //get all agents, fluents, actions and statements
        List<Agent> agents;
        List<Fluent> fluents;
        List<Action> actions;
        List<Statement> statements;
        List<Transition> transitions;
        List<State> states;
        
        public Form3(List<Statement> s, List<Agent> a, List<Fluent> f, List<Action> ac)
        {
            agents = a;
            statements = s;
            fluents = f;
            actions = ac;
            InitializeComponent();
        }

        // when the form is loaded show all the actions, agents and fluents in the left box as signature
        // and show the domain description in the right box
        private void Form3_Load(object sender, EventArgs e)
        {
              /*  foreach(Statement s in statements)
            {
                System.Diagnostics.Debug.WriteLine(s.StatementSentence);
                System.Diagnostics.Debug.WriteLine(s.StatementType);
            }*/

            listView1.Items.Add("ACTIONS:");
            foreach (Action a in actions)
                listView1.Items.Add(a.Name);
            listView1.Items.Add("AGENTS:");
            foreach (Agent a in agents)
                listView1.Items.Add(a.Name);
            listView1.Items.Add("FLUENTS:");
            foreach (Fluent a in fluents)
                listView1.Items.Add(a.Name);

            foreach (Statement s in statements)
                listView4.Items.Add(s.StatementSentence);
        }

        public void printTransitions(List<Transition> transitions)
        {
            foreach(Transition t in transitions)
            {
                Console.WriteLine("Transition function");
                Console.WriteLine("Action " + t.action.Name + " Agent " + t.agent.Name);
                Console.WriteLine("State from: " + t.starting.Name + " State to: " + t.resulting.Name);
            }
        }

        public void printAllStates(List<State> states)
        {
            Console.WriteLine("States");
            foreach (State s in states)
            {
                Console.WriteLine("State name " + s.Name);
                string str = "";
                foreach (Fluent f in s.fluents)
                    str += f.Initial + " " + f.Name + "     ";
                Console.WriteLine(str);
            }
            Console.WriteLine("-----------------");
        }

        public void printAllStatesOfGraph(State[] states)
        {
            Console.WriteLine("States of the graph");
            for(int i=0; i<states.Length; i++)
            {
                Console.WriteLine("State name " + states[i].Name);
            }
        }

        // this is for proceeding to form 4
        public bool checkSecondaryFluentsAreCorrect(List<Fluent> secondary, List<Fluent> sFrom)
        {
            int count = 0;
            foreach(Fluent f in sFrom)
            {
                foreach(Fluent f2 in secondary)
                {
                    if (f2.Name == f.Name && f2.Initial == f.Initial)
                        count++;
                }
            }
            if (count == secondary.Count)
                return true;
            else
                return false;
        }

        public bool compareList(List<Fluent> fl1, List<Fluent> fl2)
        {
            int count = 0;
            foreach(Fluent f1 in fl1)
            {
                foreach(Fluent f2 in fl2)
                {
                    if(f1.Name == f2.Name && f1.Initial == f2.Initial)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == fl1.Count)
                return true;
            else
                return false;
        }

        public State findState(List<Fluent> fluentsList)
        {
            foreach(State s in states)
            {
                if (compareList(s.fluents, fluentsList))
                    return s;
            }
            return null;
        }
        public State evaluateStatements(List<EffectStatement> estatements, State sFrom)
        {
            List<Fluent> fluentList = new List<Fluent> { };
            List<bool> changed = new List<bool> { };
            foreach (Fluent f in sFrom.fluents)
            {
                fluentList.Add(new Fluent(f));
                changed.Add(false);
            }
    
            foreach (EffectStatement es in estatements)
            {
                if (es.StatementType == "effectwithif")
                {
                    if (checkSecondaryFluentsAreCorrect(es.secondaryFluents, sFrom.fluents))
                    {
                        int index = fluentList.FindIndex(delegate (Fluent f1)
                            {
                                return f1.Name == es.firstFluent.Name;
                            });
                        fluentList[index].Initial = es.firstFluent.Initial;
                        if (changed[index])
                            return null;
                        changed[index] = true;
                    }
                }
                if(es.StatementType == "effect")
                {
                    int index = fluentList.FindIndex(delegate (Fluent f1)
                    {
                        return f1.Name == es.firstFluent.Name;
                    });
                    fluentList[index].ChangeInit(es.firstFluent.Initial);
                    if (changed[index])
                        return null;
                    changed[index] = true;
                }
            }

            return findState(fluentList);
        }
        public List<EffectStatement> getEffectStatements(Tuple<Action, Agent> pair )
        {
            List<EffectStatement> sts = new List<EffectStatement> { };
            foreach (Statement s in statements)
            {
                if(s is EffectStatement es)
                {
                    if (pair.Item1.Name == es.action.Name && pair.Item2.Name == es.agent.Name)
                        sts.Add(es);
                }
            }
            return sts;
        }

        public bool checkEmptyPairOrNot(Action ac, Agent ag)
        {
            foreach(Statement s in statements)
            {
                if(s is EffectStatement es)
                {
                    if (es.action.Name == ac.Name && es.agent.Name == ag.Name)
                        return true;
                }
            }
            return false;
        }
        public Tuple<Transition,State> createTransition(State sFrom, Tuple<Action, Agent> pair)
        {
            List<EffectStatement> eStatements = getEffectStatements(pair);

            State sto = evaluateStatements(eStatements, sFrom);
            if (sto != null)
            {
                Transition t = new Transition(pair.Item2, pair.Item1, sFrom, sto);
                return new Tuple<Transition, State>(t,sto);
            }         
            return new Tuple<Transition, State>(null,null);
        }

        bool checkStateNotExists(State s, List<State> statess)
        {
            foreach(State s1 in statess)
                if (s.Name == s1.Name)
                    return false;
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //create states here
            states = new List<State> { };
            
            int len = fluents.Count;
            int count = (int)Math.Pow(2, len);

            for(int i = 0;i<count;i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(len, '0');
                char[] subs = binary.ToCharArray();
                List<Fluent> newList = new List<Fluent> { };

                for (int k = 0; k < subs.Length; k++)
                {
                    bool result = (subs[k].Equals('1')) ? true : false;
                    Fluent f = fluents[k];
                    newList.Add(new Fluent(f.Name, result));
                }
                states.Add(new State(newList, "Sigma "+i));
            }

            printAllStates(states);

            List<Tuple<Action, Agent>> pairsEffect = new List<Tuple<Action, Agent>> { };
            List<Tuple<Action, Agent>> pairsNoEffect = new List<Tuple<Action, Agent>> { };
            foreach (Action ac in actions)
            {
                foreach (Agent ag in agents)
                {
                    if (checkEmptyPairOrNot(ac, ag))
                        pairsEffect.Add(new Tuple<Action, Agent>(ac, ag));
                    else pairsNoEffect.Add(new Tuple<Action, Agent>(ac, ag));
                }
            }
            List<Graph> graphs = new List<Graph> { };

            //get possible initial states and mark their isInitial value as true
            foreach (State s in states)
            {
                List<Fluent> fs = new List<Fluent> { };
                
                foreach (Statement st in statements)
                    if(st is InitiallyStatement ss)
                        fs.Add(ss.fluent);
                count = 0;
                foreach(Fluent f in s.fluents)
                {
                    foreach (Fluent f2 in fs)
                    {
                        if (f.Name == f2.Name && f.Initial == f2.Initial)
                        {
                            count++;
                            break;
                        }
                    }
                }
                if (count == fs.Count){
                    s.isInitial = true;
                    graphs.Add(new Graph(s));
                }
            }


            //create transition functions, i.e, graph in here
            transitions = new List<Transition> { };
            
            foreach (Graph g in graphs)
            {
                List<State> statesOfGraph = new List<State> { };
                statesOfGraph.Add(g.initialState);
                int index = 0;
                g.graphTransitionFunctions = new List<Transition> { };
                
                while(index < statesOfGraph.Count)
                {
                    State sfrom = statesOfGraph[index];
                    //evaluate pairs with effect
                    foreach (Tuple<Action, Agent> pair in pairsEffect)
                    {
                        Tuple<Transition, State> ts = createTransition(sfrom, pair);
                        if (ts.Item1 != null && ts.Item2 != null)
                        {
                            Transition t = new Transition(ts.Item1);
                            State s = new State(ts.Item2);
                            g.graphTransitionFunctions.Add(t);
                            transitions.Add(t);
                            if(checkStateNotExists(s, statesOfGraph))
                                statesOfGraph.Add(s);
                        }
                        else
                        {
                            Transition t = new Transition(pair.Item2, pair.Item1, sfrom, null);
                            g.graphTransitionFunctions.Add(t);
                            transitions.Add(t);
                        }
                    }
                    
                    //evaluate pairs with no effect
                    foreach (Tuple<Action, Agent> pair in pairsNoEffect)
                    {
                        Transition t = new Transition(pair.Item2, pair.Item1, sfrom, sfrom);
                        g.graphTransitionFunctions.Add(t);
                        transitions.Add(t);
                    }
                    index++;
                }
                
               
                Console.WriteLine("--------------------------");
                g.states = statesOfGraph.ToArray();  
                printAllStatesOfGraph(g.states);
            }


            //send these as arguments to form4
            Form4 frm4 = new Form4(agents, fluents, actions, transitions, statements, graphs, states);
            frm4.Show();
            this.Hide();
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
