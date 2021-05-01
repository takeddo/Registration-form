using MySql.Data.MySqlClient;
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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();

            this.passTxtBox.AutoSize = false;
            this.passTxtBox.Size = new Size(this.passTxtBox.Size.Width, 45);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UserTxtbox.Clear();
            passTxtBox.Clear();
            UserTxtbox.Focus();
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

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = UserTxtbox.Text;
            String passUser = passTxtBox.Text;

            DB db = new DB();

            DataTable tablo = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(tablo);

            db.closeConnection();

            if (tablo.Rows.Count > 0)
            {
                MessageBox.Show("Welcome!");
                DialogResult dialogResult = MessageBox.Show("If you press ok,you will be on main form programm", "Go main window?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Hide();
                    MainForm main = new MainForm();
                    main.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            else
                MessageBox.Show("No,user not found");
        }

        private void LogForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UserTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void passTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegForm regform = new RegForm();
            regform.Show();
        }
    }
    
}
