using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galerija
{
    public partial class PostListing : Form
    {
        private MainPage main;
        private readonly int postid;
        private int postPoints;
        private int uploaderId; // get id, convert to string by selecting from users later
        private int imgid;

        public PostListing()
        {
            InitializeComponent();
        }

        public PostListing(int id, MainPage mainMenu)
        {
            postid = id;
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

        public System.Drawing.Image byteToImg(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void CalculateMD5(byte[] stream)
        {
            using (var md5 = MD5.Create())
            {
                    var hash = md5.ComputeHash(stream);
                Console.WriteLine(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower());
            }
        }

        private System.Drawing.Image loadImg(int id)
        {
            openConnection();
            byte[] imgdata;
            using (SqlCommand cmd = new SqlCommand("select image_data from images where image_id = @id", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                imgdata = (byte[])cmd.ExecuteScalar();
            }
            closeConnection();
            CalculateMD5(imgdata);
            return byteToImg(imgdata);
        }

        private int getImgIdFromPostId()
        {
            int imgid;
            openConnection();
            using (SqlCommand cmd = new SqlCommand("select image_id from posts where post_id = @id", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", postid);
                imgid = (int)cmd.ExecuteScalar();
            }
            closeConnection();
            return imgid;
        }

        private bool hasInteracted()
        {
            bool ans;

            openConnection();
            using (SqlCommand cmd = new SqlCommand("select COUNT(1) from posts_users where user_id = @uid AND post_id = @pid", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@uid", LoginToken.loginId);
                cmd.Parameters.AddWithValue("@pid", postid);

                ans = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            closeConnection();
            return ans;
        }

        private void createInteraction()
        {
            openConnection();
            using (SqlCommand cmd = new SqlCommand("insert into posts_users (user_id, post_id, isliked, isfaved) values (@uid, @pid, 0, 0)", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@uid", LoginToken.loginId);
                cmd.Parameters.AddWithValue("@pid", postid);

                cmd.ExecuteNonQuery();
            }
            closeConnection();
        }

        private void fillPostListing(string postTitle, string tagList, DateTime uploadDate)
        {
            titleLabel.Text = postTitle;
            tagListBox.Text = tagList.Replace("|", Environment.NewLine).Trim();

            using (SqlCommand cmd2 = new SqlCommand("select username from Users where user_id = @id", conn))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@id", uploaderId);
                uploaderLabel.Text = ("By: " + cmd2.ExecuteScalar().ToString());
            }

            dateLabel.Text = ("On: " + uploadDate.ToString("dd/MM/yyyy"));
            scoreLabel.Text = ("Score: " + postPoints);
        }

        private int[] getVotes()
        {
            openConnection();
            int[] votes = new int[2]; //like,fav   

            using (SqlCommand cmd2 = new SqlCommand("select isliked from posts_users where user_id = @uid and post_id = @pid", conn))
            {
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@uid", LoginToken.loginId);
                cmd2.Parameters.AddWithValue("@pid", postid);

                votes[0] = (int)cmd2.ExecuteScalar();

                cmd2.CommandText = "select isfaved from posts_users where user_id = @uid and post_id = @pid";

                votes[1] = (int)cmd2.ExecuteScalar();
            }
            closeConnection();
            return (votes);
        }

        private void labelButtons()
        {
            if (!LoginToken.loggedIn)
            {
                likeButton.Visible = false;
                favButton.Visible = false;
                delButton.Visible = false;
            }
            else
            {
                if (hasInteracted())
                {
                    int[] votes = getVotes();
                    int currPoints;

                    if (votes[0] == 0)
                    {
                        likeButton.Text = "Like";
                    }
                    else
                    {
                        likeButton.Text = "Unlike";
                    }

                    if (votes[1] == 0)
                    {
                        favButton.Text = "Save";
                    }
                    else
                    {
                        favButton.Text = "Unsave";
                    }

                    openConnection();
                    using (SqlCommand cmd = new SqlCommand("select points from posts where post_id = @pid", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@pid", postid);
                        currPoints = (int)cmd.ExecuteScalar();
                    }
                    closeConnection();

                    scoreLabel.Text = ("Score: " + currPoints);
                }

                if(uploaderId == LoginToken.loginId)
                {
                    delButton.Visible = true;
                }
                else
                {
                    delButton.Visible = false;
                }
            }
        }

        private void PostListing_Load(object sender, EventArgs e)
        {
            string postTitle = string.Empty;
            string tagList = string.Empty;
            DateTime uploadDate = DateTime.Now;

            imgid = getImgIdFromPostId();
            Console.WriteLine(imgid);
            pictureBox1.Image = loadImg(imgid);

            openConnection();

            SqlCommand cmd = new SqlCommand("SELECT post_name, taglist, uploader_id, upload_date, points FROM posts where post_id = @id", conn);
            openConnection();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", postid);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {                      
                postTitle = reader.GetString(0);                   
                tagList = reader.GetString(1);              
                uploaderId = reader.GetInt32(2);               
                uploadDate = reader.GetDateTime(3);
                postPoints = reader.GetInt32(4);
            }

            reader.Close();
            Console.WriteLine("uploader id: " + uploaderId);
            Console.WriteLine("login sesh id: " + LoginToken.loginId);
            fillPostListing(postTitle, tagList, uploadDate);
            labelButtons();
            closeConnection();
        }

        private void dlButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName); //works but you need admin lol
                }
            }
        }

        private void changePostVote(string property)
        {
            int newVote;
            string updateCommand;
            string updateServerCommand;
            int[] votes = getVotes();

            if (property == "like")
            {
                updateCommand = "update posts_users set isliked = @vote where user_id = @uid and post_id = @pid";
                updateServerCommand = "update posts set points = points+@inc where post_id = @pid";
                if (votes[0] == 0)
                {
                    newVote = 1;
                }
                else
                {
                    newVote = 0;
                }
            }
            else
            {
                updateCommand = "update posts_users set isfaved = @vote where user_id = @uid and post_id = @pid";
                updateServerCommand = "update posts set favcount = favcount+@inc where post_id = @pid";
                if (votes[1] == 0)
                {
                    newVote = 1;
                }
                else
                {
                    newVote = 0;
                }
            }

            openConnection();
            using (SqlCommand cmd = new SqlCommand(updateCommand, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@vote", newVote);
                cmd.Parameters.AddWithValue("@uid", LoginToken.loginId);
                cmd.Parameters.AddWithValue("@pid", postid);

                cmd.ExecuteNonQuery();
            }

            using (SqlCommand cmd = new SqlCommand(updateServerCommand, conn))
            {
                cmd.CommandType = CommandType.Text;
                if(newVote == 1)
                {
                    cmd.Parameters.AddWithValue("@inc", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@inc", -1);
                }
                
                cmd.Parameters.AddWithValue("@pid", postid);

                cmd.ExecuteNonQuery();
            }

            closeConnection();

            labelButtons();
        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            if (!hasInteracted())
            {
                createInteraction();
            }

            changePostVote("like");
        }

        private void favButton_Click(object sender, EventArgs e)
        {
            if (!hasInteracted())
            {
                createInteraction();
            }

            changePostVote("fav");
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to delete this post?", "Delete confirmation", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                        openConnection();
                        using (SqlCommand cmd = new SqlCommand("delete from posts where post_id = @pid", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@pid", postid);

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "delete from images where image_id = @iid";
                            cmd.Parameters.AddWithValue("@iid", imgid);
                            cmd.ExecuteNonQuery();
                        }
                        closeConnection();
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void PostListing_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.reloadPage();
        }
    }
}
