using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galerija
{
    public partial class LoginForm : Form
    {
        private MainPage main;

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(MainPage mainMenu)
        {
            main = mainMenu;
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

        private void button1_Click(object sender, EventArgs e)
        {
            openConnection();
            using (SqlCommand cmd = new SqlCommand("select COUNT(1) from Users where username = @uname and password = @pass", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@uname", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                if (Convert.ToBoolean(cmd.ExecuteScalar()))
                {
                    cmd.CommandText = "select user_id from Users where username = @uname and password = @pass";
                    int userid = (int)cmd.ExecuteScalar();
                    LoginToken.loggedIn = true;
                    LoginToken.loginId = userid;
                    this.Close();
                    main.reloadPage();
                }
                else
                {
                    MessageBox.Show("Unable to log in, check your credentials.");
                }
            }
            closeConnection();
        }
    }
}
