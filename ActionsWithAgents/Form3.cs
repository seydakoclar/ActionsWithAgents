using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        Dictionary<string, Action> agent_action;
        Dictionary<string, Fluent> action_fluent;
        Dictionary<string, Fluent> restrains;
        public Form3(List<Statement> s, List<Agent> a, List<Fluent> f, List<Action> ac, Dictionary<string, Action> ag_ac, Dictionary<string, Fluent> ac_fl, Dictionary<string, Fluent> res)
        {
            agents = a;
            statements = s;
            fluents = f;
            actions = ac;
            agent_action = ag_ac;
            action_fluent = ac_fl;
            restrains = res;
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
        // this is for proceeding to form 4
        private void button4_Click(object sender, EventArgs e)
        {
            //create states here
            List<State> states = new List<State> { };
            List<Fluent> initialStateFluents = new List<Fluent> { };
            /*foreach (Statement s in statements)
            {
                if (s.StatementType == "initially")
                {
                    initialStateFluents.Add(s.f);
                }
            }*/
     
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
                 states.Add(new State(newList, "sigma" + i));
            }
            
            //create transition functions in here

            foreach(State st in states)
            {
                foreach(Agent ag in agents)
                {
                    foreach(Action ac in actions)
                    {
                        State res = create_transition_function(ag, ac, st);
                    }
                }
            }

            //send these as arguments to form4
            Form4 frm4 = new Form4(agents, fluents, states);
            frm4.Show();
            this.Hide();
        }

        private State create_transition_function(Agent ag, Action ac, State st)
        {

            //check agent_actions to see if given agent can peform the action
            Action new_action = agent_action[ag.Name];
            if (new_action != null)
            {
                /*
                 this means that this action can be performed by the agent. 
                 Now we will check if the action effects the fluent.
                 */
                Fluent new_f = action_fluent[ac.Name];
                if (new_f != null)
                {
                    /*
                    This means that this fluent can be changed by this action. 
                    */
                    Console.WriteLine(new_f.Name + " " + new_f.Initial);
                    List<Fluent> sts = st.fluents;
                    foreach(Fluent f in sts)
                    {

                    }

                }

                return st;

            }
            else
            {
                return st;

            }
        }
        
    }
}
