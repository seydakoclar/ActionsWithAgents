
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.initially = new System.Windows.Forms.Label();
            this.action = new System.Windows.Forms.Label();
            this.BY = new System.Windows.Forms.Label();
            this.agent = new System.Windows.Forms.Label();
            this.causes = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(595, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(49, 127);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            // 
            // initially
            // 
            this.initially.AutoSize = true;
            this.initially.Location = new System.Drawing.Point(46, 40);
            this.initially.Name = "initially";
            this.initially.Size = new System.Drawing.Size(70, 17);
            this.initially.TabIndex = 3;
            this.initially.Text = "INITIALLY";
            this.initially.Click += new System.EventHandler(this.initially_Click);
            // 
            // action
            // 
            this.action.AutoSize = true;
            this.action.Location = new System.Drawing.Point(49, 101);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(42, 20);
            this.action.TabIndex = 4;
            this.action.Text = "Action";
            this.action.UseCompatibleTextRendering = true;
            this.action.Click += new System.EventHandler(this.initially_Click);
            // 
            // BY
            // 
            this.BY.AutoSize = true;
            this.BY.Location = new System.Drawing.Point(155, 130);
            this.BY.Name = "BY";
            this.BY.Size = new System.Drawing.Size(26, 17);
            this.BY.TabIndex = 5;
            this.BY.Text = "BY";
            this.BY.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // agent
            // 
            this.agent.AutoSize = true;
            this.agent.Location = new System.Drawing.Point(184, 101);
            this.agent.Name = "agent";
            this.agent.Size = new System.Drawing.Size(45, 17);
            this.agent.TabIndex = 6;
            this.agent.Text = "Agent";
            // 
            // causes
            // 
            this.causes.AutoSize = true;
            this.causes.Location = new System.Drawing.Point(293, 128);
            this.causes.Name = "causes";
            this.causes.Size = new System.Drawing.Size(63, 17);
            this.causes.TabIndex = 7;
            this.causes.Text = "CAUSES";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(187, 125);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(362, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.causes);
            this.Controls.Add(this.agent);
            this.Controls.Add(this.BY);
            this.Controls.Add(this.action);
            this.Controls.Add(this.initially);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label initially;
        private System.Windows.Forms.Label action;
        private System.Windows.Forms.Label BY;
        private System.Windows.Forms.Label agent;
        private System.Windows.Forms.Label causes;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}

