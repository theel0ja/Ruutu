using System;
using System.Windows.Forms;

namespace Ruutu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets focus to TextBox named urlboksi
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Automatically focus to urlboksi
            this.ActiveControl = urlboksi;
        }

        /// <summary>
        /// Runs this when avaabtn is clicked
        /// </summary>
        private void Avaabtn_Click(object sender, EventArgs e)
        {
            URLParser.Parse(urlboksi.Text);
        }
    }
}
