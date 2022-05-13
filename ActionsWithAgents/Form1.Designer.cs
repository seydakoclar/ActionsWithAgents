
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
            this.statements = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.actions = new System.Windows.Forms.Label();
            this.agents = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.fluents = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // statements
            // 
            this.statements.Location = new System.Drawing.Point(664, 318);
            this.statements.Name = "statements";
            this.statements.Size = new System.Drawing.Size(97, 30);
            this.statements.TabIndex = 0;
            this.statements.Text = "Statements";
            this.statements.UseVisualStyleBackColor = true;
            this.statements.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(123, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(638, 22);
            this.textBox2.TabIndex = 2;
            // 
            // actions
            // 
            this.actions.AutoSize = true;
            this.actions.Location = new System.Drawing.Point(46, 91);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(49, 20);
            this.actions.TabIndex = 4;
            this.actions.Text = "Actions";
            this.actions.UseCompatibleTextRendering = true;
            this.actions.Click += new System.EventHandler(this.initially_Click);
            // 
            // agents
            // 
            this.agents.AutoSize = true;
            this.agents.Location = new System.Drawing.Point(43, 157);
            this.agents.Name = "agents";
            this.agents.Size = new System.Drawing.Size(52, 17);
            this.agents.TabIndex = 6;
            this.agents.Text = "Agents";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(123, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(638, 22);
            this.textBox3.TabIndex = 8;
            // 
            // fluents
            // 
            this.fluents.AutoSize = true;
            this.fluents.Location = new System.Drawing.Point(43, 221);
            this.fluents.Name = "fluents";
            this.fluents.Size = new System.Drawing.Size(54, 17);
            this.fluents.TabIndex = 9;
            this.fluents.Text = "Fluents";
            this.fluents.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(638, 22);
            this.textBox1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fluents);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.agents);
            this.Controls.Add(this.actions);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.statements);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button statements;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label actions;
        private System.Windows.Forms.Label agents;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label fluents;
        private System.Windows.Forms.TextBox textBox1;
    }
}

