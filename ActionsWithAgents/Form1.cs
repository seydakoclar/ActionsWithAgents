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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string agentText;
        public string actionText;
        public string fluentText;
        private void button1_Click(object sender, EventArgs e)
        {            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string[] agentNames = agentText.Split(',');
                string[] actionNames = actionText.Split(',');
                string[] fluentNames = fluentText.Split(',');
                if (agentText != "" && actionText != "" && fluentText != "")
                {
                    Agent[] agents = new Agent[agentNames.Length];
                    Fluent[] fluents = new Fluent[fluentNames.Length];
                    Action[] actions = new Action[actionNames.Length];

                    int i = 0;
                    foreach (string agentName in agentNames)
                    {
                        agents[i] = new Agent(agentName);
                        i++;
                    }
                    i = 0;

                    foreach (string fluentName in fluentNames)
                    {
                        fluents[i] = new Fluent(fluentName);
                        i++;
                    }

                    i = 0;
                    foreach (string actionName in actionNames)
                    {
                        actions[i] = new Action(actionName);
                        i++;
                    }

                    Form2 frm2 = new Form2(agents, fluents, actions);
                    frm2.Show();
                    this.Hide();
                }
            }
        }

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

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Actions field should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Agents field should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Fluents field should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textBox3, "");
            }
        }
    }
}
