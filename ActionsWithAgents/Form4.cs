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
        List<Tuple<Action, Agent>> programSequence;

        public Form4(List<Agent> a, List<Fluent> f, List<Action> ac, List<Transition> t,List<Statement> s, List<Graph> g)
        {
            actions = ac;
            agents = a;
            fluents = f;
            transitions = t;
            statements = s;
            graphs = g;
            InitializeComponent();
        }

        bool checkInconsistencyOfStateHasNoTransitionFunction()
        {
            return false;
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

            }
            else
            {

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
                for(int i=0; i<strArr.Length; i+=2)
                {
                    Action a = new Action(strArr[i].Substring(1));
                    Agent ag = new Agent(strArr[i+1].Substring(0, strArr[i + 1].Length - 1));
                    programSequence.Add(new Tuple<Action, Agent>(a, ag));
                }
                if(graphs.Count == 1)
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
                    MessageBox.Show("  " + resultingState.Name + " ");
                    Fluent lastFluent = resultingState.fluents.Find(delegate (Fluent f1)
                    {
                        return f1.Name == f.Name;
                    });
                    if(lastFluent.Initial == f.Initial)
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
                    //implement
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
                        listView1.Items.Add("TRUE");
                    }
                    else
                    {
                        listView1.Items.Add("FALSE");
                    }
                }
                else
                {
                    //implement
                }
            }
        }
    }
}
