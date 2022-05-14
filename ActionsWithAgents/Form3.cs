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

        private void Form3_Load(object sender, EventArgs e)
        {
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Redirect to Last Form
        }
    }
}
