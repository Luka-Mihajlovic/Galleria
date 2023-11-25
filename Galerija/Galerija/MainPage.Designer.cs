namespace Galerija
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.projketniDataSet = new Galerija.ProjketniDataSet();
            this.imagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imagesTableAdapter = new Galerija.ProjketniDataSetTableAdapters.ImagesTableAdapter();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.imgtestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imgtestTableAdapter = new Galerija.ProjketniDataSetTableAdapters.imgtestTableAdapter();
            this.imgtestBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.createPostButton = new System.Windows.Forms.Button();
            this.fKPostsimagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postsTableAdapter = new Galerija.ProjketniDataSetTableAdapters.PostsTableAdapter();
            this.postsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.projketniDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPostsimagesBindingSource)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // projketniDataSet
            // 
            this.projketniDataSet.DataSetName = "ProjketniDataSet";
            this.projketniDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imagesBindingSource
            // 
            this.imagesBindingSource.DataMember = "Images";
            this.imagesBindingSource.DataSource = this.projketniDataSet;
            // 
            // imagesTableAdapter
            // 
            this.imagesTableAdapter.ClearBeforeFill = true;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(0, 64);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(447, 36);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(0, 22);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(447, 36);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 718);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(0, 64);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(447, 36);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Visible = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // imgtestBindingSource
            // 
            this.imgtestBindingSource.DataMember = "imgtest";
            this.imgtestBindingSource.DataSource = this.projketniDataSet;
            // 
            // imgtestTableAdapter
            // 
            this.imgtestTableAdapter.ClearBeforeFill = true;
            // 
            // imgtestBindingSource1
            // 
            this.imgtestBindingSource1.DataMember = "imgtest";
            this.imgtestBindingSource1.DataSource = this.projketniDataSet;
            // 
            // createPostButton
            // 
            this.createPostButton.Location = new System.Drawing.Point(0, 22);
            this.createPostButton.Name = "createPostButton";
            this.createPostButton.Size = new System.Drawing.Size(447, 36);
            this.createPostButton.TabIndex = 8;
            this.createPostButton.Text = "Create post";
            this.createPostButton.UseVisualStyleBackColor = true;
            this.createPostButton.Click += new System.EventHandler(this.createPostButton_Click);
            // 
            // fKPostsimagesBindingSource
            // 
            this.fKPostsimagesBindingSource.DataMember = "FK_Posts_images";
            this.fKPostsimagesBindingSource.DataSource = this.imagesBindingSource;
            // 
            // postsTableAdapter
            // 
            this.postsTableAdapter.ClearBeforeFill = true;
            // 
            // postsPanel
            // 
            this.postsPanel.AutoScroll = true;
            this.postsPanel.Location = new System.Drawing.Point(465, 12);
            this.postsPanel.Name = "postsPanel";
            this.postsPanel.Size = new System.Drawing.Size(591, 737);
            this.postsPanel.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Show only favorites",
            "Show only liked",
            "Show liked + favorites",
            "No filter"});
            this.comboBox1.Location = new System.Drawing.Point(0, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(447, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filters:";
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.comboBox1);
            this.filterPanel.Controls.Add(this.label2);
            this.filterPanel.Location = new System.Drawing.Point(12, 135);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(447, 43);
            this.filterPanel.TabIndex = 12;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(381, 182);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(12, 184);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(363, 20);
            this.searchBar.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createPostButton);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.RegisterButton);
            this.panel1.Controls.Add(this.LoginButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 117);
            this.panel1.TabIndex = 13;
            // 
            // MainPage
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1068, 761);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.postsPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Main page";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projketniDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKPostsimagesBindingSource)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ProjketniDataSet projketniDataSet;
        private System.Windows.Forms.BindingSource imagesBindingSource;
        private ProjketniDataSetTableAdapters.ImagesTableAdapter imagesTableAdapter;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.BindingSource imgtestBindingSource;
        private ProjketniDataSetTableAdapters.imgtestTableAdapter imgtestTableAdapter;
        private System.Windows.Forms.BindingSource imgtestBindingSource1;
        private System.Windows.Forms.Button createPostButton;
        private System.Windows.Forms.BindingSource fKPostsimagesBindingSource;
        private ProjketniDataSetTableAdapters.PostsTableAdapter postsTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel postsPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Panel panel1;
    }
}

