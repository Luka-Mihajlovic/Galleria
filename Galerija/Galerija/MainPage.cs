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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Galerija
{
    public partial class MainPage : Form
    {
        public MainPage()
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

        private string setLoginText()
        {
            using (SqlCommand cmd = new SqlCommand("select username from Users where user_id = @userid", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userid", LoginToken.loginId);
                return (string)cmd.ExecuteScalar();
            }
        }

        /* private void loadGridView()
         {
             DataTable dat = new DataTable();

             using (SqlCommand cmd = new SqlCommand("SELECT post_name, points, favcount, image_data from POSTS p join IMAGES i on p.image_id = i.image_id", conn))
             {
                 cmd.CommandType = CommandType.Text;
                 SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                 adapt.Fill(dat);
             }

             dataGridView2.DataSource = dat;
         }*/

        public System.Drawing.Image byteToImg(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void insertIntoPanel(string postname, int points, byte[] imagedata, int postid)
        {
            Panel newpanel = new Panel();
            newpanel.Width = 175;
            newpanel.Height = 250;
            newpanel.BorderStyle = BorderStyle.Fixed3D;

            tablePictureBox pic = new tablePictureBox();
            newpanel.Controls.Add(pic);
            pic.Height = 200;
            pic.BackgroundImageLayout = ImageLayout.Zoom;
            pic.Dock = DockStyle.Top;
            pic.BackgroundImage = byteToImg(imagedata);
            pic.Click += new EventHandler(pic_Click);
            pic.pId = postid;

            System.Windows.Forms.Label postInfo = new System.Windows.Forms.Label();
            postInfo.Text = (postname + " | " + points + "pts");
            postInfo.Dock = DockStyle.Bottom;
            newpanel.Controls.Add(postInfo);


            postsPanel.Controls.Add(newpanel);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            tablePictureBox pic = sender as tablePictureBox;
            PostListing pl = new PostListing(pic.pId, this);
            pl.Show();
        }

        private void testPanelShit(string command)
        {
            DataTable dat = new DataTable();

            using (SqlCommand cmd = new SqlCommand(command, conn))
            {
                openConnection();
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dat);
                closeConnection();
            }

            for (int i = 0; i < dat.Rows.Count; i++)
            {
                DataRow dr = dat.Rows[i];
                string postname = dr[0].ToString();
                int points = (int)dr[1];
                byte[] imagedata = (byte[])dr[2];
                int postid = (int)dr[3];

                if(postname.Length > 20)
                {
                    postname = postname.Substring(0, 15) + "...";
                }
                insertIntoPanel(postname, points, imagedata, postid);
            }
        }

        private void applyFilters(string panelCmd = "SELECT post_name, points, image_data, p.post_id from POSTS p join IMAGES i on p.image_id = i.image_id", string cmdDlc = "") //PARAMETERS ARE OPTIONAL !!!
        {
            postsPanel.Controls.Clear();
            string interactionPanelCmd = "SELECT post_name, points, image_data, p.post_id from POSTS_USERS pu join POSTS p on pu.post_id = p.post_id join IMAGES i on p.image_id = i.image_id";

            switch (comboBox1.SelectedIndex)
            {
                case 0: //only fav
                    panelCmd = interactionPanelCmd; //has interactions
                    testPanelShit(panelCmd + " where pu.user_id = " + LoginToken.loginId + " and pu.isfaved = 1 " + cmdDlc + " ORDER BY upload_date ASC");
                    break;

                case 1: //only like
                    panelCmd = interactionPanelCmd; //has interactions
                    testPanelShit(panelCmd + " where pu.user_id = " + LoginToken.loginId + " and pu.isliked = 1 " + cmdDlc + " ORDER BY upload_date ASC");
                    break;

                case 2: //l+f
                    panelCmd = interactionPanelCmd; //has interactions
                    testPanelShit(panelCmd + " where pu.user_id = " + LoginToken.loginId + " and (pu.isliked = 1 or pu.isfaved = 1) " + cmdDlc + " ORDER BY upload_date ASC");
                    break;

                default:
                    testPanelShit(panelCmd + " " + cmdDlc + " ORDER BY upload_date ASC");
                    break;
            }
        }

        private void ReloadForm()
        {
            applyFilters();
            if (LoginToken.loggedIn)
            {
                openConnection();
                this.label1.Text = ("Hello " + setLoginText() + "!");
                this.LoginButton.Visible = false;
                this.RegisterButton.Visible = false;
                this.logoutButton.Visible = true;
                this.createPostButton.Visible = true;
                filterPanel.Visible = true;
                closeConnection();
            }
            else
            {
                this.label1.Text = "Not logged in";
                this.LoginButton.Visible = true;
                this.RegisterButton.Visible = true;
                this.logoutButton.Visible = false;
                this.createPostButton.Visible = false;
                filterPanel.Visible = false;
                comboBox1.SelectedIndex = 3;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projketniDataSet.Posts' table. You can move, or remove it, as needed.
            //this.postsTableAdapter.Fill(this.projketniDataSet.Posts);
            // TODO: This line of code loads data into the 'projketniDataSet.Images' table. You can move, or remove it, as needed.
            ReloadForm();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            LoginRegister loginRegister = new LoginRegister();
            loginRegister.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.Show();
        }
        public void reloadPage()
        {
            ReloadForm();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LoginToken.loggedIn = false;
            LoginToken.loginId = 0;
            reloadPage();
        }

        /*private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) //FIX - ITS NOT IMGTEST ITS IMAGES NOW
        {
            using (SqlCommand cmd = new SqlCommand("select imgid from imgtest where imgdat = @imgdata", conn))
            {
                openConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@imgdata", dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                PostListing pl = new PostListing((int)cmd.ExecuteScalar());
                pl.Show();
                closeConnection();
            }
        }*/

        private void createPostButton_Click(object sender, EventArgs e)
        {
            CreatePost cpostForm = new CreatePost(this);
            cpostForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void searchForTags(List<String> tags)
        {
            List<int> idList = new List<int>();
            DataTable dat = new DataTable();

            openConnection();
            foreach(String tag in tags)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT post_id from posts where taglist like '%|" + tag + "|%'", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dat);
                }
                
                for(int i=0; i < dat.Rows.Count; i++)
                {
                    DataRow dr = dat.Rows[i];
                    if (!idList.Contains((int)dr[0]))
                    {
                        idList.Add((int)dr[0]);
                    }
                }
            }
            closeConnection();

            if(idList.Count != 0)
            {
                string panelQuery = ("AND (");
                for (int i = 0; i < idList.Count; i++)
                {
                    if (i == idList.Count - 1) //if last
                    {
                        panelQuery += ("p.post_id =" + idList[i] + ")");
                    }
                    else
                    {
                        panelQuery += ("p.post_id =" + idList[i] + " or ");
                    }
                }
                applyFilters(cmdDlc: panelQuery);
            }
            else
            {
                MessageBox.Show("No posts with those filters have been found");
                applyFilters();
            }       
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(searchBar.Text != string.Empty)
            {
                List<String> searchList = new List<String>();
                foreach (string tag in searchBar.Text.Split(','))
                {
                    searchList.Add(tag.Trim().ToLower());
                }

                foreach (string tag in searchList)
                {
                    Console.WriteLine(tag);
                }

                searchForTags(searchList);
            }
            else
            {
                applyFilters();
            }
        }
    }
}
