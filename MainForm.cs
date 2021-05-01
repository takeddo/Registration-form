using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRegForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

                                
        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("If you press ok,you exit programm", "Sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void instLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.instLabel.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.instagram.com/takeddo/?hl=ru");
        }

        private void vkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.vkLabel.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://vk.com/the.vagulik");
        }
    }
}
