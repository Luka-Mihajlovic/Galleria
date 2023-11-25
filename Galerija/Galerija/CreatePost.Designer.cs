namespace Galerija
{
    partial class CreatePost
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgtestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projketniDataSet = new Galerija.ProjketniDataSet();
            this.imgtestTableAdapter = new Galerija.ProjketniDataSetTableAdapters.imgtestTableAdapter();
            this.imgtestBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uploadButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.tagsBox = new System.Windows.Forms.RichTextBox();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projketniDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 632);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Post!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(312, 12);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(500, 690);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 690);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // imgtestBindingSource
            // 
            this.imgtestBindingSource.DataMember = "imgtest";
            this.imgtestBindingSource.DataSource = this.projketniDataSet;
            // 
            // projketniDataSet
            // 
            this.projketniDataSet.DataSetName = "ProjketniDataSet";
            this.projketniDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(236, 632);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(70, 70);
            this.uploadButton.TabIndex = 2;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 709);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.Size = new System.Drawing.Size(801, 20);
            this.pathBox.TabIndex = 3;
            // 
            // tagsBox
            // 
            this.tagsBox.Location = new System.Drawing.Point(12, 70);
            this.tagsBox.Name = "tagsBox";
            this.tagsBox.Size = new System.Drawing.Size(294, 556);
            this.tagsBox.TabIndex = 4;
            this.tagsBox.Text = "";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(12, 28);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(293, 20);
            this.titleBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Post tags (one per line)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Post title";
            // 
            // CreatePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 743);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.tagsBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreatePost";
            this.Text = "Create post";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projketniDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgtestBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ProjketniDataSet projketniDataSet;
        private System.Windows.Forms.BindingSource imgtestBindingSource;
        private ProjketniDataSetTableAdapters.imgtestTableAdapter imgtestTableAdapter;
        private System.Windows.Forms.BindingSource imgtestBindingSource1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.RichTextBox tagsBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}