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
        // this is for proceeding to form 4
        private void button4_Click(object sender, EventArgs e)
        {
            //create states here
            List<State> states = new List<State> { };
            List<Fluent> initialStateFluents = new List<Fluent> { };
            foreach (Statement s in statements)
            {
                if (s.StatementType == "initially")
                {
                    initialStateFluents.Add(s.f);
                }
            }
            
            //states.Add(new State(initialStateFluents, true));
            int len = initialStateFluents.Count;
            int iter = 0, count = (int)Math.Pow(2, len);
            //int i = 0;
            /*while(iter < count)
            {
                int k = 0;
                *//*Fluent f = initialStateFluents[i];*//*
                initialStateFluents.ForEach((c) =>
                {
                   
                });

            }*/

            for(int i = 0;i<count;i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(len, '0');
                char[] subs = binary.ToCharArray();
                List<Fluent> newList = new List<Fluent> { };

                for (int k = 0; k < subs.Length; k++)
                {
                    bool result = (subs[k].Equals('1')) ? true : false;
                    Fluent f = initialStateFluents[k];
                    newList.Add(new Fluent(f.Name, result));
                }
                states.Add(new State(newList));
            }
            
            //create transition functions in here
            //send these as arguments to form4
            Form4 frm4 = new Form4(agents, fluents, states);
            frm4.Show();
            this.Hide();
        }
    }
}
