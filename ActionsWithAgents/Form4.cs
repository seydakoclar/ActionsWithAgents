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
        List<State> states;
        public Form4(List<Agent> a, List<Fluent> f, List<State> s)
        {
            agents = a;
            fluents = f;
            states = s;
            InitializeComponent();
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
