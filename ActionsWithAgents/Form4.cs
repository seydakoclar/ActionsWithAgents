using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionsWithAgents
{
    public partial class Form4 : Form
    {
        List<Agent> agents;
        List<Fluent> fluents;
        List<Transition> transitions;
        List<Graph> graphs;
        List<Statement> statements;
        List<Action> actions;
        List<State> states;
        List<Tuple<Action, Agent>> programSequence;
        bool InConsistent = false;

        public Form4(List<Agent> a, List<Fluent> f, List<Action> ac, List<Transition> t,List<Statement> s, List<Graph> g, List<State> st)
        {
            actions = ac;
            agents = a;
            fluents = f;
            transitions = t;
            statements = s;
            graphs = g;
            states = st;
            InitializeComponent();
        }
        public Graph checkInconsistencyOfStateHasNoTransitionFunctionForMultiple()
        {
            foreach(Graph g in graphs)
            {
                foreach (State s in g.states)
                {
                    Transition t = transitions.Find(delegate (Transition f1)
                    {
                        return f1.starting.Name == s.Name && f1.resulting.Name != s.Name;
                    });
                    if (t != null)
                        return g;
                    else
                        return null;
                }
            }
            return null;
        }
        public bool checkInconsistencyOfStateHasNoTransitionFunction()
        {
            foreach(State s in states)
            {
                Transition t = transitions.Find(delegate (Transition f1)
                {
                    return f1.starting.Name == s.Name && f1.resulting.Name != s.Name;
                });
                if (t != null)
                    return false;
                else
                    return true;
            }
            return true;
        }

        public bool checkInitiallyStatementConflict()
        {
            List<Fluent> flus = new List<Fluent> { };
            foreach (Statement s in statements)
            {
                if(s is InitiallyStatement ist)
                {
                    foreach(Fluent f in flus)
                    {
                        if (f.Name == ist.fluent.Name && f.Initial != ist.fluent.Initial)
                            return true;
                        else
                        {
                            flus.Add(ist.fluent);
                            break;
                        }
                    }
                    if(flus.Count == 0)
                        flus.Add(ist.fluent);
                }
            }
            return false;
        }

        public bool checkValueStatementInconsistency()
        {
            foreach(Graph g in graphs)
            {
                State resultingState = g.initialState;
                foreach (Statement s in statements)
                {
                    if (s is ValueStatement vs)
                    {
                        Action[] acts = vs.actions.ToArray();
                        for (int i = 0; i < acts.Length; i++)
                        {
                            Transition t = transitions.Find(delegate (Transition f1)
                            {
                                return f1.action.Name == acts[i].Name && f1.agent.Name == vs.agents[i].Name && f1.starting.Name == resultingState.Name;
                            });
                            resultingState = t.resulting;
                        }
                        Fluent lastFluent = resultingState.fluents.Find(delegate (Fluent f1)
                        {
                            return f1.Name == vs.fluent.Name;
                        });
                        if (lastFluent.Initial != vs.fluent.Initial)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;            
        }

        public string printGraph(Graph g)
        {
            string str = "";
            str += "Initial state: " + g.initialState.Name + "\n";
            foreach(Transition t in g.graphTransitionFunctions)
            {
                str += "Transition (" + t.action.Name + ", " + t.agent.Name + " " + t.starting.Name + ") = " + t.resulting.Name + "\n"; 
            }
            return str;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Agent a in agents)
            {
                comboBox2.Items.Add(a.Name);
            }
            foreach (Fluent a in fluents)
            {
                comboBox1.Items.Add(a.Name);
            }

            if(checkInconsistencyOfStateHasNoTransitionFunction())
            {
                MessageBox.Show("This is an inconsistent domain because there is a state which has no transition function defined for it.");
                InConsistent = true;
            }
            
            else
            {
                if (checkInitiallyStatementConflict())
                {
                    MessageBox.Show("This is an inconsistent domain because there is a state which has no transition function satisfying the contradictory values of the same fluent.");
                    InConsistent = true;
                }
                else
                {
                    if (checkValueStatementInconsistency())
                    {
                        MessageBox.Show("This is an inconsistent domain because there is conflict in the result of one of the value statements");
                        InConsistent = true;
                    }
                }
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //holds after
            foreach(ListViewItem i in listView1.Items)
            {
                listView1.Items.Remove(i);
            }
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Required fields of the query must be chosen");
            }
            else
            {
                //(prepare,Anna),(eat,alex)
                Fluent f = new Fluent(fluents[comboBox1.SelectedIndex]);
                f.ChangeInit(!checkBox5.Checked);
                string[] strArr = textBox1.Text.Split(',');
                programSequence = new List<Tuple<Action, Agent>> { };
                for (int i = 0; i < strArr.Length; i += 2)
                {
                    Action a = new Action(strArr[i].Substring(1));
                    Agent ag = new Agent(strArr[i + 1].Substring(0, strArr[i + 1].Length - 1));
                    programSequence.Add(new Tuple<Action, Agent>(a, ag));
                }
                if (!InConsistent)
                {
                    if (graphs.Count == 1)
                    {
                        State resultingState = graphs[0].initialState;
                        foreach (Tuple<Action, Agent> pair in programSequence)
                        {
                            Transition t = transitions.Find(delegate (Transition f1)
                            {
                                return f1.action.Name == pair.Item1.Name && f1.agent.Name == pair.Item2.Name && f1.starting.Name == resultingState.Name;
                            });
                            resultingState = t.resulting;
                        }
                        Fluent lastFluent = resultingState.fluents.Find(delegate (Fluent f1)
                        {
                            return f1.Name == f.Name;
                        });
                        if (lastFluent.Initial == f.Initial)
                        {
                            listView1.Items.Add("TRUE");
                        }
                        else
                        {
                            listView1.Items.Add("FALSE");
                        }
                    }
                    else
                    {
                        int count = 1;
                        foreach(Graph g in graphs)
                        {
                            State resultingState = g.initialState;
                            foreach (Tuple<Action, Agent> pair in programSequence)
                            {
                                Transition t = g.graphTransitionFunctions.Find(delegate (Transition f1)
                                {
                                    return f1.action.Name == pair.Item1.Name && f1.agent.Name == pair.Item2.Name && f1.starting.Name == resultingState.Name;
                                });
                                resultingState = t.resulting;
                            }
                            Fluent lastFluent = resultingState.fluents.Find(delegate (Fluent f1)
                            {
                                return f1.Name == f.Name;
                            });
                            if (lastFluent.Initial == f.Initial)
                            {
                                listView1.Items.Add("TRUE for graph " + count);
                            }
                            else
                            {
                                listView1.Items.Add("FALSE for graph " + count);
                            }
                            count++;
                        }
                    }
                }
                else
                {
                    listView1.Items.Add("YES");
                }


            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //involves
            foreach (ListViewItem i in listView1.Items)
            {
                listView1.Items.Remove(i);
            }
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Required fields of the query must be chosen");
            }
            else
            {
                Agent agent = agents[comboBox2.SelectedIndex];
                bool isInvolved = false;
                string[] strArr = textBox2.Text.Split(',');
                programSequence = new List<Tuple<Action, Agent>> { };
                for (int i = 0; i < strArr.Length; i += 2)
                {
                    Action a = new Action(strArr[i].Substring(1));
                    Agent ag = new Agent(strArr[i + 1].Substring(0, strArr[i + 1].Length - 1));
                    programSequence.Add(new Tuple<Action, Agent>(a, ag));
                }

                if (!InConsistent)
                {
                    if (graphs.Count == 1)
                    {
                        State resultingState = graphs[0].initialState;
                        foreach (Tuple<Action, Agent> pair in programSequence)
                        {
                            Transition t = transitions.Find(delegate (Transition f1)
                            {
                                return f1.action.Name == pair.Item1.Name && f1.agent.Name == pair.Item2.Name && f1.starting.Name == resultingState.Name;
                            });
                            if (resultingState.Name != t.resulting.Name && t.agent.Name == agent.Name)
                                isInvolved = true;
                            resultingState = t.resulting;
                        }

                        if (isInvolved)
                        {
                            listView1.Items.Add("YES");
                        }
                        else
                        {
                            listView1.Items.Add("NO");
                        }
                    }
                    else
                    {
                        int count = 0;
                        foreach (Graph g in graphs)
                        {
                            State resultingState = g.initialState;
                            foreach (Tuple<Action, Agent> pair in programSequence)
                            {
                                Transition t = g.graphTransitionFunctions.Find(delegate (Transition f1)
                                {
                                    return f1.action.Name == pair.Item1.Name && f1.agent.Name == pair.Item2.Name && f1.starting.Name == resultingState.Name;
                                });
                                if (resultingState.Name != t.resulting.Name && t.agent.Name == agent.Name)
                                    isInvolved = true;
                                resultingState = t.resulting;
                            }

                            if (isInvolved)
                            {
                                listView1.Items.Add("YES for graph " + count);
                            }
                            else
                            {
                                listView1.Items.Add("NO for graph " + count);
                            }
                            count++;
                            isInvolved = false;
                        }
                    }
                }
                else
                {
                    listView1.Items.Add("YES");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
