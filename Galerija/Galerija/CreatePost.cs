using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace Galerija
{
    public partial class CreatePost : Form
    {
        private MainPage main;
        private byte[] imgdata;

        public CreatePost(MainPage mainMenu)
        {
            main = mainMenu;
            InitializeComponent();
        }
        public CreatePost()
        {
            InitializeComponent();
        }

        SqlConnection conn = Connector.connectPlease();

        byte[] imgToByte(System.Drawing.Image img)
        {
            using(MemoryStream ms = new MemoryStream()) 
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public System.Drawing.Image byteToImg(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data)) 
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        private void openConnection()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void closeConnection()
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close(); 
            }
        }

        private int insertImg(byte[] data, string hash)
        {
            int newid;
            openConnection();

                using (SqlCommand cmd = new SqlCommand("insert into images (image_data, image_hash) OUTPUT INSERTED.image_id values (@image, @imghash)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@image", data);
                    cmd.Parameters.AddWithValue("@imghash", hash);
                    newid = (int)cmd.ExecuteScalar();
                Console.WriteLine("ID IS " + newid);
                }

            closeConnection();

            return newid;
        }

        /*private int nextId(string tablename)
        {
            int nId;

            openConnection();
            using (SqlCommand cmd = new SqlCommand())
            {

                switch (tablename) //blegh
                {
                    case ("imgtest"):
                        cmd.CommandText = "select max(imgid) from imgtest";
                        break;

                    case ("Images"):
                        cmd.CommandText = "select max(image_id) from Images";
                        break;

                    case ("Posts"):
                        cmd.CommandText = "select max(post_id) from Posts";
                        break;
                }

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                var res = cmd.ExecuteScalar();
                Console.WriteLine(res);
                if (res.GetType() == typeof(System.DBNull))
                {
                    return 1;
                }
                else
                {
                    nId = (int)res;
                }
            }
            closeConnection();

            return nId;
        }*/

        private void insertPost(int imgid, string postTags, string postTitle)
        {
            openConnection();
            using (SqlCommand cmd = new SqlCommand("insert into posts (taglist, points, favcount, upload_date, image_id, uploader_id, post_name) values (@tlist, 0, 0, @udate, @imgid, @uid, @pname)", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@tlist", postTags.ToLower());
                cmd.Parameters.AddWithValue("@udate", DateTime.Today);
                cmd.Parameters.AddWithValue("@imgid", imgid);
                cmd.Parameters.AddWithValue("@uid", LoginToken.loginId);
                cmd.Parameters.AddWithValue("@pname", postTitle);
                cmd.ExecuteNonQuery();
            }
            closeConnection();
        }

        private void insertPostData(byte[] data, string hash)
        {
            //int imgtestid = nextId("imgtest");
            string postTags = getTags();
            string postTitle = titleBox.Text;

            int imgid = insertImg(data, hash); //insert image data and post id into images table
            insertPost(imgid, postTags, postTitle); //insert all info into posts table, including image id from imgid
        }
/*
        private System.Drawing.Image loadImg(int id)
        {
            openConnection();
            byte[] imgdata;
            using (SqlCommand cmd = new SqlCommand("select imgdat from imgtest where imgid = @id", conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                imgdata = (byte[])cmd.ExecuteScalar();
            }
            closeConnection();
            return byteToImg(imgdata);
        }*/

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Activate();

            string file = openFileDialog1.FileName; 
            this.pathBox.Text = file;
            imgdata = System.IO.File.ReadAllBytes(file);
            pictureBox1.Image = byteToImg(imgdata);

 /*           using (SqlCommand cmd = new SqlCommand("select imgid from imgtest where imgdat = @data", conn))
            {
                openConnection();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@data", imgdata);
                pictureBox1.Image = loadImg((int)cmd.ExecuteScalar());
                closeConnection();
            }*/
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private string getTags()
        {
            var sb = new System.Text.StringBuilder();
            bool firstLine = true;
            foreach (string st in tagsBox.Lines)
            {
                if (firstLine)
                {
                    sb.Append("|" + st + "|");
                    firstLine = false;  
                }
                else
                {
                    sb.Append(st + "|");
                }
            }

            return sb.ToString();
        }

        private string CalculateMD5(byte[] stream)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(stream);
                return(BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(titleBox.Text.Length < 50)
            {
                if (imgdata != null && titleBox.Text != string.Empty && tagsBox.Text != string.Empty)
                {
                    bool dupeCheck;
                    string hash = CalculateMD5(imgdata);
                    openConnection();
                    using (SqlCommand cmd = new SqlCommand("select COUNT(1) from Images where image_hash = @imghash", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@imghash", hash);
                        dupeCheck = Convert.ToBoolean(cmd.ExecuteScalar());

                    }
                    closeConnection();

                    if (!dupeCheck)
                    {
                        insertPostData(imgdata, hash);
                        this.Close();
                        main.reloadPage();
                    }
                    else
                    {
                        MessageBox.Show("Image already uploaded >:(");
                    }

                    //insertImg(imgdata);
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields to create a post.");
                }
            }
            else
            {
                MessageBox.Show("Title too long! (max 50 characters)");
            }

        }
    }
}
