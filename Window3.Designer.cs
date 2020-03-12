namespace Ex1
{
    partial class Window3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window3));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.YES = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Escape = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(36)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.YES);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Escape);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 488);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(46, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(810, 27);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // YES
            // 
            this.YES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(72)))), ((int)(((byte)(4)))));
            this.YES.FlatAppearance.BorderSize = 0;
            this.YES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(45)))), ((int)(((byte)(4)))));
            this.YES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(143)))), ((int)(((byte)(10)))));
            this.YES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YES.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YES.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.YES.Location = new System.Drawing.Point(740, 416);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(150, 60);
            this.YES.TabIndex = 7;
            this.YES.Text = "Далее";
            this.YES.UseVisualStyleBackColor = false;
            this.YES.Click += new System.EventHandler(this.YES_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(271, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Выберите себя в списке сотрудников";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Escape
            // 
            this.Escape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Escape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.Escape.FlatAppearance.BorderSize = 0;
            this.Escape.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.Escape.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.Escape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Escape.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Escape.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Escape.Location = new System.Drawing.Point(12, 416);
            this.Escape.Name = "Escape";
            this.Escape.Size = new System.Drawing.Size(150, 60);
            this.Escape.TabIndex = 4;
            this.Escape.Text = "Назад";
            this.Escape.UseVisualStyleBackColor = false;
            this.Escape.Click += new System.EventHandler(this.Escape_Click);
            // 
            // Window3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 488);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window3";
            this.Text = "ChooseSurname";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Escape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button YES;
        private System.Windows.Forms.TextBox textBox1;
    }
}