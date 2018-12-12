namespace MovInfoClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonQuery = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBookmarks = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.releaseLabel = new System.Windows.Forms.Label();
            this.runtimeLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listSearchResults = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.Label();
            this.btnSearchBack = new System.Windows.Forms.Button();
            this.btnSearchForward = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(627, 3);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(57, 28);
            this.buttonQuery.TabIndex = 0;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(544, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(324, 37);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(300, 445);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(50, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 297);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Search",
            "Title",
            "imdbID"});
            this.comboBox1.Location = new System.Drawing.Point(530, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 25);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search Type:";
            // 
            // listBookmarks
            // 
            this.listBookmarks.FormattingEnabled = true;
            this.listBookmarks.ItemHeight = 17;
            this.listBookmarks.Location = new System.Drawing.Point(530, 177);
            this.listBookmarks.Name = "listBookmarks";
            this.listBookmarks.Size = new System.Drawing.Size(154, 157);
            this.listBookmarks.TabIndex = 7;
            this.listBookmarks.DoubleClick += new System.EventHandler(this.listBookmarks_DoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(530, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add To Bookmarks";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 38);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(45, 16);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "TITLE";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // releaseLabel
            // 
            this.releaseLabel.AutoSize = true;
            this.releaseLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseLabel.Location = new System.Drawing.Point(12, 57);
            this.releaseLabel.Name = "releaseLabel";
            this.releaseLabel.Size = new System.Drawing.Size(72, 15);
            this.releaseLabel.TabIndex = 10;
            this.releaseLabel.Text = "placeholder";
            // 
            // runtimeLabel
            // 
            this.runtimeLabel.AutoSize = true;
            this.runtimeLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runtimeLabel.Location = new System.Drawing.Point(169, 54);
            this.runtimeLabel.Name = "runtimeLabel";
            this.runtimeLabel.Size = new System.Drawing.Size(72, 15);
            this.runtimeLabel.TabIndex = 11;
            this.runtimeLabel.Text = "placeholder";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreLabel.Location = new System.Drawing.Point(12, 78);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(72, 15);
            this.genreLabel.TabIndex = 12;
            this.genreLabel.Text = "placeholder";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(297, 238);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Bookmarks:";
            // 
            // listSearchResults
            // 
            this.listSearchResults.FormattingEnabled = true;
            this.listSearchResults.ItemHeight = 17;
            this.listSearchResults.Location = new System.Drawing.Point(690, 41);
            this.listSearchResults.Name = "listSearchResults";
            this.listSearchResults.Size = new System.Drawing.Size(225, 259);
            this.listSearchResults.TabIndex = 15;
            this.listSearchResults.SelectedIndexChanged += new System.EventHandler(this.listSearchResults_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(691, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "No. of Results:";
            // 
            // txtResults
            // 
            this.txtResults.AutoSize = true;
            this.txtResults.Location = new System.Drawing.Point(802, 9);
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(83, 17);
            this.txtResults.TabIndex = 17;
            this.txtResults.Text = "placeholder";
            // 
            // btnSearchBack
            // 
            this.btnSearchBack.Enabled = false;
            this.btnSearchBack.Location = new System.Drawing.Point(691, 307);
            this.btnSearchBack.Name = "btnSearchBack";
            this.btnSearchBack.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBack.TabIndex = 18;
            this.btnSearchBack.Text = "<";
            this.btnSearchBack.UseVisualStyleBackColor = true;
            this.btnSearchBack.Click += new System.EventHandler(this.btnSearchBack_Click);
            // 
            // btnSearchForward
            // 
            this.btnSearchForward.Enabled = false;
            this.btnSearchForward.Location = new System.Drawing.Point(840, 307);
            this.btnSearchForward.Name = "btnSearchForward";
            this.btnSearchForward.Size = new System.Drawing.Size(75, 23);
            this.btnSearchForward.TabIndex = 19;
            this.btnSearchForward.Text = ">";
            this.btnSearchForward.UseVisualStyleBackColor = true;
            this.btnSearchForward.Click += new System.EventHandler(this.btnSearchForward_Click);
            // 
            // txtPage
            // 
            this.txtPage.AutoSize = true;
            this.txtPage.Location = new System.Drawing.Point(793, 310);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(16, 17);
            this.txtPage.TabIndex = 20;
            this.txtPage.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 346);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnSearchForward);
            this.Controls.Add(this.btnSearchBack);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listSearchResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.runtimeLabel);
            this.Controls.Add(this.releaseLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBookmarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonQuery);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Movie Information Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBookmarks;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label releaseLabel;
        private System.Windows.Forms.Label runtimeLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listSearchResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtResults;
        private System.Windows.Forms.Button btnSearchBack;
        private System.Windows.Forms.Button btnSearchForward;
        private System.Windows.Forms.Label txtPage;
    }
}

