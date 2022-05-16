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
    // This form is to get the action, agent and fluents that will be used in the domain description
    // These values must be written without any space only with comma seperated
    public partial class Form1 : Form
    {
        //for getting the text value of text boxes
        public string agentText = "";
        public string actionText = "";
        public string fluentText = "";
        
        //for storing agents, fluents and actions as list of objects
        List<Agent> _agents = new List<Agent> { };
        List<Fluent> _fluents = new List<Fluent> { };
        List<Action> _actions = new List<Action> { };

        public Form1(string[] texts)
        {
            agentText = texts[1];
            actionText = texts[0];
            fluentText = texts[2];
            InitializeComponent();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.AppendText(agentText);
            textBox1.AppendText(actionText);
            textBox3.AppendText(fluentText);
        }
        //if statement button is clicked this function checks whether any of the fields is empty
        //gives warning if so, if not creates all actions, agents, and fluents then proceeds with the second form
        private void button1_Click(object sender, EventArgs e)
        {            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string[] agentNames = agentText.Split(',');
                string[] actionNames = actionText.Split(',');
                string[] fluentNames = fluentText.Split(',');
                if (agentText != "" && actionText != "" && fluentText != "")
                {
                    _agents = new List<Agent> { };
                    _fluents = new List<Fluent> { };
                    _actions = new List<Action> { };
                    int i = 0;
                    foreach (string agentName in agentNames)
                    {
                        _agents.Add(new Agent(agentName));
                        i++;
                    }
                    i = 0;

                    foreach (string fluentName in fluentNames)
                    {
                        _fluents.Add(new Fluent(fluentName));
                        i++;
                    }

                    i = 0;
                    foreach (string actionName in actionNames)
                    {
                        _actions.Add(new Action(actionName));
                        i++;
                    }

                    Form2 frm2 = new Form2(_agents, _fluents, _actions, actionText, agentText, fluentText);
                    frm2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter all actions, agents and fluents");
            }
        }
        //below functions are for getting the text value when user changes the text
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            fluentText = textBox3.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            agentText = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actionText = textBox1.Text;
        }

    }
}
