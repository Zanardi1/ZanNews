namespace ZanScore
{
    partial class OptionsWindow
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
            this.StartWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.AppStartGB = new System.Windows.Forms.GroupBox();
            this.StartMaximized = new System.Windows.Forms.RadioButton();
            this.StartMinimized = new System.Windows.Forms.RadioButton();
            this.StartNormal = new System.Windows.Forms.RadioButton();
            this.DisableBadSources = new System.Windows.Forms.CheckBox();
            this.DownloadNewsAtStartup = new System.Windows.Forms.CheckBox();
            this.AcceptChanges = new System.Windows.Forms.Button();
            this.DiscardChanges = new System.Windows.Forms.Button();
            this.AppStartGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartWithWindowsCheckBox
            // 
            this.StartWithWindowsCheckBox.AutoSize = true;
            this.StartWithWindowsCheckBox.Location = new System.Drawing.Point(34, 43);
            this.StartWithWindowsCheckBox.Name = "StartWithWindowsCheckBox";
            this.StartWithWindowsCheckBox.Size = new System.Drawing.Size(148, 21);
            this.StartWithWindowsCheckBox.TabIndex = 0;
            this.StartWithWindowsCheckBox.Tag = "1";
            this.StartWithWindowsCheckBox.Text = "Start with Windows";
            this.StartWithWindowsCheckBox.UseVisualStyleBackColor = true;
            this.StartWithWindowsCheckBox.CheckedChanged += new System.EventHandler(this.StartWithWindowsToggle);
            // 
            // MinimizeToTrayCheckBox
            // 
            this.MinimizeToTrayCheckBox.AutoSize = true;
            this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(34, 83);
            this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
            this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(128, 21);
            this.MinimizeToTrayCheckBox.TabIndex = 1;
            this.MinimizeToTrayCheckBox.Tag = "2";
            this.MinimizeToTrayCheckBox.Text = "Minimize to tray";
            this.MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeToTrayToggle);
            // 
            // AppStartGB
            // 
            this.AppStartGB.Controls.Add(this.StartMaximized);
            this.AppStartGB.Controls.Add(this.StartMinimized);
            this.AppStartGB.Controls.Add(this.StartNormal);
            this.AppStartGB.Location = new System.Drawing.Point(34, 128);
            this.AppStartGB.Name = "AppStartGB";
            this.AppStartGB.Size = new System.Drawing.Size(207, 150);
            this.AppStartGB.TabIndex = 2;
            this.AppStartGB.TabStop = false;
            this.AppStartGB.Tag = "3";
            this.AppStartGB.Text = "Application start options";
            // 
            // StartMaximized
            // 
            this.StartMaximized.AutoSize = true;
            this.StartMaximized.Location = new System.Drawing.Point(6, 113);
            this.StartMaximized.Name = "StartMaximized";
            this.StartMaximized.Size = new System.Drawing.Size(128, 21);
            this.StartMaximized.TabIndex = 4;
            this.StartMaximized.Text = "Start maximized";
            this.StartMaximized.UseVisualStyleBackColor = true;
            this.StartMaximized.CheckedChanged += new System.EventHandler(this.Assign3ToVar);
            // 
            // StartMinimized
            // 
            this.StartMinimized.AutoSize = true;
            this.StartMinimized.Location = new System.Drawing.Point(6, 34);
            this.StartMinimized.Name = "StartMinimized";
            this.StartMinimized.Size = new System.Drawing.Size(125, 21);
            this.StartMinimized.TabIndex = 3;
            this.StartMinimized.Text = "Start minimized";
            this.StartMinimized.UseVisualStyleBackColor = true;
            this.StartMinimized.CheckedChanged += new System.EventHandler(this.Assign1ToVar);
            // 
            // StartNormal
            // 
            this.StartNormal.AutoSize = true;
            this.StartNormal.Location = new System.Drawing.Point(6, 73);
            this.StartNormal.Name = "StartNormal";
            this.StartNormal.Size = new System.Drawing.Size(106, 21);
            this.StartNormal.TabIndex = 3;
            this.StartNormal.Text = "Start normal";
            this.StartNormal.UseVisualStyleBackColor = true;
            this.StartNormal.CheckedChanged += new System.EventHandler(this.Assign2ToVar);
            // 
            // DisableBadSources
            // 
            this.DisableBadSources.AutoSize = true;
            this.DisableBadSources.Location = new System.Drawing.Point(306, 43);
            this.DisableBadSources.Name = "DisableBadSources";
            this.DisableBadSources.Size = new System.Drawing.Size(300, 21);
            this.DisableBadSources.TabIndex = 3;
            this.DisableBadSources.Tag = "4";
            this.DisableBadSources.Text = "Disable news sources with invalid RSS files";
            this.DisableBadSources.UseVisualStyleBackColor = true;
            this.DisableBadSources.CheckedChanged += new System.EventHandler(this.DisableNewsSourcesToggle);
            // 
            // DownloadNewsAtStartup
            // 
            this.DownloadNewsAtStartup.AutoSize = true;
            this.DownloadNewsAtStartup.Location = new System.Drawing.Point(306, 83);
            this.DownloadNewsAtStartup.Name = "DownloadNewsAtStartup";
            this.DownloadNewsAtStartup.Size = new System.Drawing.Size(347, 21);
            this.DownloadNewsAtStartup.TabIndex = 4;
            this.DownloadNewsAtStartup.Tag = "5";
            this.DownloadNewsAtStartup.Text = "Download news automatically when program starts";
            this.DownloadNewsAtStartup.UseVisualStyleBackColor = true;
            this.DownloadNewsAtStartup.CheckedChanged += new System.EventHandler(this.DownloadAtStartupToggle);
            // 
            // AcceptChanges
            // 
            this.AcceptChanges.Location = new System.Drawing.Point(240, 308);
            this.AcceptChanges.Name = "AcceptChanges";
            this.AcceptChanges.Size = new System.Drawing.Size(75, 23);
            this.AcceptChanges.TabIndex = 5;
            this.AcceptChanges.Text = "OK";
            this.AcceptChanges.UseVisualStyleBackColor = true;
            this.AcceptChanges.Click += new System.EventHandler(this.SaveChanges);
            // 
            // DiscardChanges
            // 
            this.DiscardChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardChanges.Location = new System.Drawing.Point(370, 308);
            this.DiscardChanges.Name = "DiscardChanges";
            this.DiscardChanges.Size = new System.Drawing.Size(75, 23);
            this.DiscardChanges.TabIndex = 6;
            this.DiscardChanges.Text = "Cancel";
            this.DiscardChanges.UseVisualStyleBackColor = true;
            this.DiscardChanges.Click += new System.EventHandler(this.CloseWindow);
            // 
            // OptionsWindow
            // 
            this.AcceptButton = this.AcceptChanges;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.DiscardChanges;
            this.ClientSize = new System.Drawing.Size(658, 373);
            this.ControlBox = false;
            this.Controls.Add(this.DiscardChanges);
            this.Controls.Add(this.AcceptChanges);
            this.Controls.Add(this.DownloadNewsAtStartup);
            this.Controls.Add(this.DisableBadSources);
            this.Controls.Add(this.AppStartGB);
            this.Controls.Add(this.MinimizeToTrayCheckBox);
            this.Controls.Add(this.StartWithWindowsCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.ShowOptions);
            this.AppStartGB.ResumeLayout(false);
            this.AppStartGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StartWithWindowsCheckBox;
        private System.Windows.Forms.CheckBox MinimizeToTrayCheckBox;
        private System.Windows.Forms.GroupBox AppStartGB;
        private System.Windows.Forms.RadioButton StartMinimized;
        private System.Windows.Forms.RadioButton StartMaximized;
        private System.Windows.Forms.RadioButton StartNormal;
        private System.Windows.Forms.CheckBox DisableBadSources;
        private System.Windows.Forms.CheckBox DownloadNewsAtStartup;
        private System.Windows.Forms.Button AcceptChanges;
        private System.Windows.Forms.Button DiscardChanges;
    }
}