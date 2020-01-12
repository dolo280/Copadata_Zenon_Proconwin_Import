namespace AddInEditorExample
{
	partial class frmDescription
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblName;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.sel_logic = new System.Windows.Forms.Button();
            this.sel_numeric = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 391);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Beenden";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(13, 9);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(1111, 31);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Bitte wählen sie die \"VAREXPL.CSV\" aus:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1012, 391);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(984, 26);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1111, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bitte wählen sie die \"VAREXPN.CSV\" aus:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 106);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(984, 26);
            this.textBox2.TabIndex = 5;
            // 
            // sel_logic
            // 
            this.sel_logic.Location = new System.Drawing.Point(1012, 43);
            this.sel_logic.Name = "sel_logic";
            this.sel_logic.Size = new System.Drawing.Size(112, 26);
            this.sel_logic.TabIndex = 6;
            this.sel_logic.Text = "Auswählen";
            this.sel_logic.UseVisualStyleBackColor = true;
            this.sel_logic.Click += new System.EventHandler(this.sel_logic_Click);
            // 
            // sel_numeric
            // 
            this.sel_numeric.Location = new System.Drawing.Point(1012, 106);
            this.sel_numeric.Name = "sel_numeric";
            this.sel_numeric.Size = new System.Drawing.Size(112, 26);
            this.sel_numeric.TabIndex = 7;
            this.sel_numeric.Text = "Auswählen";
            this.sel_numeric.UseVisualStyleBackColor = true;
            this.sel_numeric.Click += new System.EventHandler(this.sel_numeric_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1012, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Auswählen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(17, 169);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(984, 26);
            this.textBox3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1111, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bitte wählen sie die \"ALERTS.CSV\" aus:";
            // 
            // frmDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.sel_numeric);
            this.Controls.Add(this.sel_logic);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDescription";
            this.Text = "Description";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button sel_logic;
        private System.Windows.Forms.Button sel_numeric;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
    }
}
