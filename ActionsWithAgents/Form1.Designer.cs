
namespace ActionsWithAgents
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actions = new System.Windows.Forms.Label();
            this.agents = new System.Windows.Forms.Label();
            this.fluents = new System.Windows.Forms.Label();
            this.statements = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // actions
            // 
            this.actions.AutoSize = true;
            this.actions.Location = new System.Drawing.Point(58, 91);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(54, 17);
            this.actions.TabIndex = 0;
            this.actions.Text = "Actions";
            // 
            // agents
            // 
            this.agents.AutoSize = true;
            this.agents.Location = new System.Drawing.Point(58, 165);
            this.agents.Name = "agents";
            this.agents.Size = new System.Drawing.Size(52, 17);
            this.agents.TabIndex = 1;
            this.agents.Text = "Agents";
            // 
            // fluents
            // 
            this.fluents.AutoSize = true;
            this.fluents.Location = new System.Drawing.Point(58, 243);
            this.fluents.Name = "fluents";
            this.fluents.Size = new System.Drawing.Size(54, 17);
            this.fluents.TabIndex = 2;
            this.fluents.Text = "Fluents";
            // 
            // statements
            // 
            this.statements.Location = new System.Drawing.Point(647, 329);
            this.statements.Name = "statements";
            this.statements.Size = new System.Drawing.Size(102, 40);
            this.statements.TabIndex = 3;
            this.statements.Text = "Statements";
            this.statements.UseVisualStyleBackColor = true;
            this.statements.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(623, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(126, 240);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(623, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(623, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Please enter each values with comma seperated";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.statements);
            this.Controls.Add(this.fluents);
            this.Controls.Add(this.agents);
            this.Controls.Add(this.actions);
            this.Name = "Form1";
            this.Text = "Actions with Agents";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label actions;
        private System.Windows.Forms.Label agents;
        private System.Windows.Forms.Label fluents;
        private System.Windows.Forms.Button statements;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}