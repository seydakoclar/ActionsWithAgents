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
        List<Agent> agents;
        List<Fluent> fluents;
        List<Action> actions;
        List<Statement> statements = new List<Statement> { };

        public Form2(List<Agent> a, List<Fluent> f, List<Action> ac)
        {
            agents = a;
            fluents = f;
            actions = ac;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("All fields of the statement must be chosen");
            }
            else{
                Action ac = new Action(actions[comboBox1.SelectedIndex]);
                Agent ag = new Agent(agents[comboBox2.SelectedIndex]);
                Fluent f = new Fluent(fluents[comboBox3.SelectedIndex]);
                f.ChangeInit(!checkBox1.Checked);
                string stype = "effect";
                Statement s = new Statement(stype, ag, f, ac);
                listView1.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                checkBox4.Checked = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Agent a in agents)
            {
                comboBox2.Items.Add(a.Name);
                comboBox5.Items.Add(a.Name);
                comboBox9.Items.Add(a.Name);
            }
            foreach (Fluent a in fluents)
            {
                comboBox3.Items.Add(a.Name);
                comboBox4.Items.Add(a.Name);
                comboBox7.Items.Add(a.Name);
                comboBox11.Items.Add(a.Name);
                comboBox8.Items.Add(a.Name);
            }
            foreach (Action a in actions)
            {
                this.comboBox1.Items.Add(a.Name);
                this.comboBox6.Items.Add(a.Name);
                this.comboBox10.Items.Add(a.Name);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == -1 || comboBox5.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 || comboBox7.SelectedIndex == -1)
            {
                MessageBox.Show("All fields of the statement must be chosen");
            }
            else
            {
                Action ac = new Action(actions[comboBox6.SelectedIndex]);
                Agent ag = new Agent(agents[comboBox5.SelectedIndex]);
                Fluent f = new Fluent(fluents[comboBox4.SelectedIndex]);
                f.ChangeInit(!checkBox2.Checked);
                Fluent f2 = new Fluent(fluents[comboBox7.SelectedIndex]);
                f.ChangeInit(!checkBox3.Checked);
                Statement s = new Statement(ag, f, ac, f2);
                listView1.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox6.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                checkBox4.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == -1 || comboBox10.SelectedIndex == -1 || comboBox11.SelectedIndex == -1)
            {
                MessageBox.Show("All fields of the statement must be chosen");
            }
            else
            {
                Action ac = new Action(actions[comboBox10.SelectedIndex]);
                Agent ag = new Agent(agents[comboBox9.SelectedIndex]);
                Fluent f = new Fluent(fluents[comboBox11.SelectedIndex]);
                f.ChangeInit(!checkBox4.Checked);
                string stype = "value";
                Statement s = new Statement(stype, ag, f, ac);
                listView2.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox10.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
                comboBox11.SelectedIndex = -1;
                checkBox4.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listView4.Items.Count > 0 && (listView1.Items.Count > 0 || listView2.Items.Count > 0))
            {
                //redirect form3
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
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
            }
        }

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
                Statement s = new Statement(f);
                listView4.Items.Add(s.StatementSentence);
                statements.Add(s);
                comboBox8.SelectedIndex = -1;
                checkBox5.Checked = false;
            }
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
