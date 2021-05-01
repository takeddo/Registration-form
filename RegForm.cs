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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();

            this.passRegBox.AutoSize = false;
            this.passRegBox.Size = new Size(this.passRegBox.Size.Width, 45);
            this.confpassRegBox.AutoSize = false;
            this.confpassRegBox.Size = new Size(this.confpassRegBox.Size.Width, 45);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogForm logform = new LogForm();
            logform.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegNameBox.Clear();
            surnameRegBox.Clear();
            passRegBox.Clear();
            confpassRegBox.Clear();
            RegNameBox.Focus();
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
            if(RegNameBox.Text == "Enter name")
            {
                MessageBox.Show("Enter name!");
                return;
            } 
            if(surnameRegBox.Text == "Enter login")
            {
                MessageBox.Show("Enter login!");
                return;
            }
            if(passRegBox.Text == "")
            {
                MessageBox.Show("Enter password!");
                return;
            }
            if(confpassRegBox.Text == "")
            {
                MessageBox.Show("Confirm password!");
                return;
            }


            if (isUserExists())
                return;


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`name`,`login`, `password`, `passconfirm`) VALUES (@name,@log,@pass,@passconfirm)", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = RegNameBox.Text;
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = surnameRegBox.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passRegBox.Text;
            command.Parameters.Add("@passconfirm", MySqlDbType.VarChar).Value = confpassRegBox.Text;

            if (passRegBox.Text != confpassRegBox.Text)
            {
                MessageBox.Show("Check passwords! And try again:D");
                return;
            }

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Excellent,Account has been created");
                this.Hide();
                LogForm logform = new LogForm();
                logform.Show();
            } else
            {
                MessageBox.Show("Account hasn't been created,try again");
            }

            db.closeConnection();
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL",db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = surnameRegBox.Text;



            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Such an account already exists");
                return true;
            }
            else
                return false;
        }

        private void RegNameBox_Enter(object sender, EventArgs e)
        {
            if(RegNameBox.Text == "Enter name")
            {
                RegNameBox.Text = "";
                RegNameBox.ForeColor = Color.SteelBlue;
            }
        }

        private void RegNameBox_Leave(object sender, EventArgs e)
        {
            if(RegNameBox.Text == "")
            {
                RegNameBox.Text = "Enter name";
                RegNameBox.ForeColor = Color.Gray;
            }
        }

        private void surnameRegBox_Enter(object sender, EventArgs e)
        {
            if(surnameRegBox.Text == "Enter login")
            {
                surnameRegBox.Text = "";
                surnameRegBox.ForeColor = Color.SteelBlue;
            }
        }

        private void surnameRegBox_Leave(object sender, EventArgs e)
        {
            if(surnameRegBox.Text == "")
            {
                surnameRegBox.Text = "Enter login";
                surnameRegBox.ForeColor = Color.Gray;
            }
        }
    }
}
