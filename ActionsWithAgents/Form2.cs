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
    public partial class Form2 : Form
    {
        Agent[] agents;
        Fluent[] fluents;
        Action[] actions;
        public Form2(Agent[] a, Fluent[] f, Action[] ac)
        {
            this.agents = a;
            this.fluents = f;
            this.actions = ac;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Agent a in agents)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine("----------");
            foreach (Fluent a in fluents)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine("----------");
            foreach (Action a in actions)
            {
                Console.WriteLine(a.Name);
            }
        }
    }
}
