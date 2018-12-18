namespace ZanScore
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
            this.btnFetchNews = new System.Windows.Forms.Button();
            this.wbNewsWebPage = new System.Windows.Forms.WebBrowser();
            this.dgNewsDetails = new System.Windows.Forms.DataGridView();
            this.News = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewsDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFetchNews
            // 
            this.btnFetchNews.Location = new System.Drawing.Point(495, 12);
            this.btnFetchNews.Name = "btnFetchNews";
            this.btnFetchNews.Size = new System.Drawing.Size(103, 23);
            this.btnFetchNews.TabIndex = 0;
            this.btnFetchNews.Text = "Download";
            this.btnFetchNews.UseVisualStyleBackColor = true;
            this.btnFetchNews.Click += new System.EventHandler(this.DownloadNews);
            // 
            // wbNewsWebPage
            // 
            this.wbNewsWebPage.Location = new System.Drawing.Point(495, 50);
            this.wbNewsWebPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNewsWebPage.Name = "wbNewsWebPage";
            this.wbNewsWebPage.ScriptErrorsSuppressed = true;
            this.wbNewsWebPage.Size = new System.Drawing.Size(1239, 645);
            this.wbNewsWebPage.TabIndex = 1;
            // 
            // dgNewsDetails
            // 
            this.dgNewsDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNewsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.News,
            this.NewsURL,
            this.NewsHeader});
            this.dgNewsDetails.Location = new System.Drawing.Point(12, 50);
            this.dgNewsDetails.Name = "dgNewsDetails";
            this.dgNewsDetails.RowTemplate.Height = 24;
            this.dgNewsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNewsDetails.Size = new System.Drawing.Size(451, 645);
            this.dgNewsDetails.TabIndex = 2;
            this.dgNewsDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoadNewsURL);
            // 
            // News
            // 
            this.News.HeaderText = "Stire";
            this.News.Name = "News";
            this.News.ReadOnly = true;
            // 
            // NewsURL
            // 
            this.NewsURL.HeaderText = "Link";
            this.NewsURL.Name = "NewsURL";
            // 
            // NewsHeader
            // 
            this.NewsHeader.HeaderText = "Rezumat";
            this.NewsHeader.Name = "NewsHeader";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1761, 707);
            this.Controls.Add(this.dgNewsDetails);
            this.Controls.Add(this.wbNewsWebPage);
            this.Controls.Add(this.btnFetchNews);
            this.Name = "Form1";
            this.Text = "ZanScore";
            ((System.ComponentModel.ISupportInitialize)(this.dgNewsDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFetchNews;
        private System.Windows.Forms.WebBrowser wbNewsWebPage;
        private System.Windows.Forms.DataGridView dgNewsDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn News;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsHeader;
    }
}

