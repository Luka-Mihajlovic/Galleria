using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galerija
{
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();
        }

        SqlConnection conn = Connector.connectPlease();

        private void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private bool t1valid()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Please enter your username.");
                valid = false;
            }

            if (textBox1.Text.Length > 20)
            {
                errorProvider1.SetError(textBox1, "Usernames cannot be longer than 20 characters.");
                valid = false;
            }

            if (valid)
            {
                errorProvider1.SetError(textBox1, null);
            }

            return valid;
        }
        private bool t2valid()
        {
            bool valid = true;
            Regex passregex = new Regex("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$"); //1 number, 1 character, >8

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Please enter your password.");
                valid = false;
            }

            if (passregex.IsMatch(textBox2.Text) == false)
            {
                errorProvider1.SetError(textBox2, "Password must contain a letter, number, and be longer than 8 characters.");
                valid = false;
            }

            if (valid)
            {
                errorProvider1.SetError(textBox2, null);
            }

            return valid;
        }

        private bool t3valid()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Please repeat your password.");
                valid = false;
            }

            if (textBox3.Text != textBox2.Text)
            {
                errorProvider1.SetError(textBox3, "Passwords don't match.");
                valid = false;
            }

            if (valid)
            {
                errorProvider1.SetError(textBox3, null);
            }

            return valid;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            t3valid();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            t1valid();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            t2valid();
        }

        private void registerUser()
        {
            using (SqlCommand cmd = new SqlCommand("insert into Users (username, password, acc_date) values (@name, @pass, @date)", conn))
            {
                openConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                cmd.ExecuteNonQuery();
                closeConnection();
            }
            MessageBox.Show("Registered! You are now able to log in to this acccount.");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t1valid() == true && t2valid() == true && t3valid() == true)
            {
                using (SqlCommand cmd = new SqlCommand("select * from Users where LOWER(username) = @name", conn))
                {
                    openConnection();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@name", textBox1.Text.ToLower());
                    if (cmd.ExecuteScalar() == null)
                    {
                        registerUser();
                    }
                    else
                    {
                        MessageBox.Show("User is already registered.");
                    }
                    closeConnection();
                }
            }
        }
    }
}
