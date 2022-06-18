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
        //public Graph checkInconsistencyOfStateHasNoTransitionFunctionForMultiple()
        //{
        //    foreach(Graph g in graphs)
        //    {
        //        foreach (State s in g.states)
        //        {
        //            Transition t = transitions.Find(delegate (Transition f1)
        //            {
        //                return f1.starting.Name == s.Name && f1.resulting.Name != s.Name;
        //            });
        //            if (t != null)
        //                return g;
        //            else
        //                return null;
        //        }
        //    }
        //    return null;
        //}
        //public bool checkInconsistencyOfStateHasNoTransitionFunction()
        //{
        //    foreach(State s in states)
        //    {
        //        Transition t = transitions.Find(delegate (Transition f1)
        //        {
        //            return f1.starting.Name == s.Name && f1.resulting.Name != s.Name;
        //        });
        //        if (t != null)
        //            return false;
        //        else
        //            return true;
        //    }
        //    return true;
        //}

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

        public string printGraph(Graph g, int num)
        {
            string str = "Graph " + num + "\n";
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
                comboBox4.Items.Add(a.Name);
                comboBox5.Items.Add(a.Name);
            }
            foreach (Fluent a in fluents)
            {
                comboBox1.Items.Add(a.Name);
            }
            foreach(Action a in actions)
            {
                comboBox3.Items.Add(a.Name);
                comboBox6.Items.Add(a.Name);
            }

           /* if(checkInconsistencyOfStateHasNoTransitionFunction())
            {
                MessageBox.Show("This is an inconsistent domain because there is a state which has no transition function defined for it.");
                InConsistent = true;
            }*/
            
           /* else
            {*/
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
            //}

            printTransitions();
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
                
                programSequence = new List<Tuple<Action, Agent>> { };
                foreach(ListViewItem item in listView3.Items)
                {
                    string str = item.Text;
                    string[] strArr = str.Split(',');
                    Action a = new Action(strArr[0].Substring(1));
                    Agent ag = new Agent(strArr[1].Substring(1, strArr[1].Length - 2));
                    programSequence.Add(new Tuple<Action, Agent>(a, ag));
                }
                if (!InConsistent)
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
                            if(graphs.Count > 1)
                                listView1.Items.Add("TRUE for graph " + count);
                            else
                                listView1.Items.Add("TRUE");
                        }
                        else
                        {
                            if(graphs.Count > 1)
                                listView1.Items.Add("FALSE for graph " + count);
                            else
                                listView1.Items.Add("FALSE");
                        }
                        count++;
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
                programSequence = new List<Tuple<Action, Agent>> { };
                foreach (ListViewItem item in listView4.Items)
                {
                    string str = item.Text;
                    string[] strArr = str.Split(',');
                    Action a = new Action(strArr[0].Substring(1));
                    Agent ag = new Agent(strArr[1].Substring(1, strArr[1].Length - 2));
                    programSequence.Add(new Tuple<Action, Agent>(a, ag));
                }

                if (!InConsistent)
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
                            if (graphs.Count > 1)
                                listView1.Items.Add("TRUE for graph " + count);
                            else
                                listView1.Items.Add("TRUE");
                        }
                        else
                        {
                            if (graphs.Count > 1)
                                listView1.Items.Add("FALSE for graph " + count);
                            else
                                listView1.Items.Add("FALSE");
                        }
                        count++;
                        isInvolved = false;
                    }
                    
                }
                else
                {
                    listView1.Items.Add("YES");
                }
            }
        }

        private void printTransitions()
        {
            foreach(Graph g in graphs)
            {
                List<Transition> l = g.graphTransitionFunctions;
                foreach(Transition t in l)
                {
                    listView2.Items.Add("Ψ (" + t.agent.Name + "," + t.action.Name + "," + t.starting.Name+ ") = " + t.resulting.Name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            checkBox5.Checked = false;
            listView1.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1)
            {
                string str = "(";
                str += actions[comboBox3.SelectedIndex].Name + ", " + agents[comboBox4.SelectedIndex].Name + ")";
                listView3.Items.Add(str);
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1 && comboBox6.SelectedIndex != -1)
            {
                string str = "(";
                str += actions[comboBox6.SelectedIndex].Name + ", " + agents[comboBox5.SelectedIndex].Name + ")";
                listView4.Items.Add(str);
                comboBox6.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView3.SelectedItems)
            {
                listView3.Items.Remove(eachItem);
            }
        }

        private void listView3_MouseHover(object sender, EventArgs e)
        {
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 5000;
                toolTip1.ReshowDelay = 500;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;

                toolTip1.SetToolTip(listView3, "Click on the item to remove it.");
        
        }

        private void listView4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(listView4, "Click on the item to remove it.");
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView4.SelectedItems)
            {
                listView4.Items.Remove(eachItem);
            }
        }
    }
}
