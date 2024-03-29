﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActionsWithAgents
{
    // This form is to get all the statements in the domain description
    public partial class Form2 : Form
    {
        // the created agents, fluents and actions
        List<Agent> agents;
        List<Fluent> fluents;
        List<Action> actions;
        // store all the statements in a string
        List<Statement> statements = new List<Statement> { };
        Dictionary<Agent, Action> agent_action= new Dictionary<Agent, Action> { };
        Dictionary<Action, Fluent> action_fluent = new Dictionary<Action, Fluent> { };

        // store the text values of agent, action and fluent in case user wants to go back to the form 1
        string[] texts = new string[3];
        public Form2(List<Agent> a, List<Fluent> f, List<Action> ac, string t1, string t2, string t3)
        {
            agents = a;
            fluents = f;
            actions = ac;
            texts[0] = t1;
            texts[1] = t2;
            texts[2] = t3;
            InitializeComponent();
        }   

        // when the form is loading this function fills the data of the combo boxes with the created agent, fluent
        // and action values.
        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Agent a in agents)
            {
                comboBox5.Items.Add(a.Name);
                comboBox9.Items.Add(a.Name);
            }
            foreach (Fluent a in fluents)
            {
                comboBox4.Items.Add(a.Name);
                comboBox7.Items.Add(a.Name);
                comboBox11.Items.Add(a.Name);
                comboBox8.Items.Add(a.Name);
            }
            foreach (Action a in actions)
            {
                comboBox6.Items.Add(a.Name);
                comboBox10.Items.Add(a.Name);
            }
            
        }

        // this is for creating effect statement, first checks whether any of the box values are empty or not
        // then if they all are selected creates effect statement and adds it to statements. It also shows the 
        // sentence of the statement in the box called effect statements right next to it
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1 || comboBox5.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Required fields of the statement must be chosen");
            }
            else
            {
                Action ac = new Action(actions[comboBox6.SelectedIndex]);
                Agent ag = new Agent(agents[comboBox5.SelectedIndex]);
                Fluent f = new Fluent(fluents[comboBox4.SelectedIndex]);
                f.ChangeInit(!checkBox2.Checked);

                List <Fluent> secondaryFluents = new List<Fluent> { };
                foreach (ListViewItem eachItem in listView5.Items)
                {
                    string str = eachItem.Text.ToString();
                    string name = str;
                    bool init = true;
                    if (str[0] == '-')
                    {
                        init = false;
                        name = str.Substring(2);
                    }
                    secondaryFluents.Add(new Fluent(name, init));    
                }

                EffectStatement s = new EffectStatement(ag, f, ac, secondaryFluents);
                listView1.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox6.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                foreach (ListViewItem item in listView5.Items)
                    listView5.Items.Remove(item);
            }
        }

        // this is for creating value statement, first checks whether any of the box values are empty or not
        // then if they all are selected creates value statement and adds it to statements. It also shows the 
        // sentence of the statement in the box called value statements right next to it
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == -1 || listView3.Items.Count == 0)
            {
                MessageBox.Show("All fields of the statement must be chosen");
            }
            else
            {
                Fluent f = new Fluent(fluents[comboBox11.SelectedIndex]);
                f.ChangeInit(!checkBox4.Checked);
                List<Action> _actions = new List<Action> { };
                List<Agent> _agents = new List<Agent> { };
                foreach (ListViewItem eachItem in listView3.Items)
                {
                    string str = eachItem.Text.ToString();
                    string[] splittedStr = str.Split(',');
                    string actionName = splittedStr[0].Substring(1);
                    int len = splittedStr[1].Length - 2;
                    string agentName = splittedStr[1].Substring(1,len);
                    _actions.Add(new Action(actionName));
                    _agents.Add(new Agent(agentName));
                }
                ValueStatement s = new ValueStatement(_agents, f, _actions);
                listView2.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox10.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
                comboBox11.SelectedIndex = -1;
                checkBox4.Checked = false;
                foreach (ListViewItem item in listView3.Items)
                    listView3.Items.Remove(item);
            }
        }

        // this is for creating the language and domain description if the initially list and one of the lists
        // showing the effect and value statements have at least one value it accepts this language and moves
        // forward to form 3
        private void button4_Click(object sender, EventArgs e)
        {
            if(listView4.Items.Count > 0 && (listView1.Items.Count > 0 || listView2.Items.Count > 0))
            {
                Form3 frm3 = new Form3(statements, agents, fluents, actions);
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("At least one initially statement and one of the other statements must be entered");
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
                statements.Remove(findAndDeleteFromStatements(eachItem));
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
                statements.Remove(findAndDeleteFromStatements(eachItem));
            }
        }

        // this is click event for button ADD for initially statement it checks whether a fluent is chosen and
        // if not gives warning, if so creates a new statement object and add it to the list of statements and shows 
        // the sentence of the statement in the box right next to it
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("All fields of the statement must be chosen");
            }
            else
            {
                Fluent f = new Fluent(fluents[comboBox8.SelectedIndex]);
                f.ChangeInit(!checkBox5.Checked);
                InitiallyStatement s = new InitiallyStatement(f);
                listView4.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox8.SelectedIndex = -1;
                checkBox5.Checked = false;
            }
        }

        public Statement findAndDeleteFromStatements(ListViewItem item)
        {
            foreach(Statement s in statements)
            {
                if(s.StatementSentence == item.Text)
                {
                    return s;
                }
            }
            return null;
        }

        // this is for deleting the initially statement when user clicks on the sentence
        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView4.SelectedItems)
            {
                listView4.Items.Remove(eachItem);
                statements.Remove(findAndDeleteFromStatements(eachItem));
            }
        }

        // for going back to form 1
        private void button5_Click(object sender, EventArgs e)
        {            
            Form1 frm1 = new Form1(texts);
            frm1.Show();
            this.Hide();
        }
        private void checkBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(checkBox2, "Click to make negation of fluent.");
        }

        private void checkBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(checkBox5, "Click to make negation of fluent.");
        }

        private void checkBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(checkBox3, "Click to make negation of fluent.");
        }

        private void checkBox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(checkBox4, "Click to make negation of fluent.");
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

        private void listView1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(listView1, "Click on the item to remove it.");
        }

        private void listView2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(listView2, "Click on the item to remove it.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str = "";
            if (checkBox3.Checked)
                str += "- ";
            if(comboBox7.SelectedIndex != -1)
            {
                str += fluents[comboBox7.SelectedIndex].Name;
                listView5.Items.Add(str);
                comboBox7.SelectedIndex = -1;
                checkBox3.Checked = false;
            } 
        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView5.SelectedItems)
            {
                listView5.Items.Remove(eachItem);
            }
        }

        private void listView5_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(listView5, "Click on the item to remove it.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == -1 || comboBox10.SelectedIndex == -1)
            {
                MessageBox.Show("You have to chose one action and one agent.");
            }
            else
            {
                string str = "(" + actions[comboBox10.SelectedIndex].Name + ", " + agents[comboBox9.SelectedIndex].Name + ")";
                listView3.Items.Add(str);
                comboBox10.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
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
    }
}
