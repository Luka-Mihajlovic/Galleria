namespace Galerija
{
    partial class PostListing
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.uploaderLabel = new System.Windows.Forms.Label();
            this.tagListBox = new System.Windows.Forms.RichTextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.likeButton = new System.Windows.Forms.Button();
            this.favButton = new System.Windows.Forms.Button();
            this.dlButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(566, 771);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoEllipsis = true;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(585, 12);
            this.titleLabel.MaximumSize = new System.Drawing.Size(550, 100);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(538, 31);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "This is my first ever post :))))))))))))))))))))))))";
            // 
            // uploaderLabel
            // 
            this.uploaderLabel.AutoEllipsis = true;
            this.uploaderLabel.AutoSize = true;
            this.uploaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploaderLabel.Location = new System.Drawing.Point(586, 623);
            this.uploaderLabel.MaximumSize = new System.Drawing.Size(550, 100);
            this.uploaderLabel.Name = "uploaderLabel";
            this.uploaderLabel.Size = new System.Drawing.Size(388, 25);
            this.uploaderLabel.TabIndex = 2;
            this.uploaderLabel.Text = "Posted by: ONLYTWENTYCHARACTERS";
            // 
            // tagListBox
            // 
            this.tagListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagListBox.Location = new System.Drawing.Point(591, 115);
            this.tagListBox.Name = "tagListBox";
            this.tagListBox.ReadOnly = true;
            this.tagListBox.Size = new System.Drawing.Size(539, 505);
            this.tagListBox.TabIndex = 3;
            this.tagListBox.Text = "TAG LIST";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoEllipsis = true;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(586, 648);
            this.dateLabel.MaximumSize = new System.Drawing.Size(550, 100);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(150, 25);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "On: 20/03/2023";
            // 
            // likeButton
            // 
            this.likeButton.Location = new System.Drawing.Point(1070, 723);
            this.likeButton.Name = "likeButton";
            this.likeButton.Size = new System.Drawing.Size(60, 60);
            this.likeButton.TabIndex = 5;
            this.likeButton.Text = "Like";
            this.likeButton.UseVisualStyleBackColor = true;
            this.likeButton.Click += new System.EventHandler(this.likeButton_Click);
            // 
            // favButton
            // 
            this.favButton.Location = new System.Drawing.Point(591, 723);
            this.favButton.Name = "favButton";
            this.favButton.Size = new System.Drawing.Size(60, 60);
            this.favButton.TabIndex = 6;
            this.favButton.Text = "Save";
            this.favButton.UseVisualStyleBackColor = true;
            this.favButton.Click += new System.EventHandler(this.favButton_Click);
            // 
            // dlButton
            // 
            this.dlButton.Location = new System.Drawing.Point(657, 723);
            this.dlButton.Name = "dlButton";
            this.dlButton.Size = new System.Drawing.Size(407, 60);
            this.dlButton.TabIndex = 7;
            this.dlButton.Text = "Download";
            this.dlButton.UseVisualStyleBackColor = true;
            this.dlButton.Click += new System.EventHandler(this.dlButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoEllipsis = true;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(586, 692);
            this.scoreLabel.MaximumSize = new System.Drawing.Size(550, 100);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(108, 25);
            this.scoreLabel.TabIndex = 8;
            this.scoreLabel.Text = "Score: 999";
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(1010, 657);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(120, 60);
            this.delButton.TabIndex = 9;
            this.delButton.Text = "Delete post";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // PostListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 795);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.dlButton);
            this.Controls.Add(this.favButton);
            this.Controls.Add(this.likeButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.tagListBox);
            this.Controls.Add(this.uploaderLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PostListing";
            this.Text = "Post view";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PostListing_FormClosed);
            this.Load += new System.EventHandler(this.PostListing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label uploaderLabel;
        private System.Windows.Forms.RichTextBox tagListBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button likeButton;
        private System.Windows.Forms.Button favButton;
        private System.Windows.Forms.Button dlButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button delButton;
    }
}