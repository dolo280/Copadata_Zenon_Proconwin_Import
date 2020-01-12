using Scada.AddIn.Contracts;
using System;
using System.Windows.Forms;

namespace AddInEditorExample
{
	/// <summary>
	/// Description of frmDescription.
	/// </summary>
	public partial class frmDescription : Form
	{
        public string file_numeric { get; set; }
        public string file_logic { get; set; }
        public string file_alert { get; set; }

        public frmDescription()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
        }
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void button2_Click(object sender, EventArgs e)
        {
            file_numeric = textBox2.Text;
            file_logic = textBox1.Text;
            file_alert = textBox3.Text; 

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void sel_logic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void sel_numeric_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog.FileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
