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
            this.AcceptChanges = new System.Windows.Forms.Button();
            this.DiscardChanges = new System.Windows.Forms.Button();
            this.ManageTabs = new System.Windows.Forms.TabControl();
            this.StartupTab = new System.Windows.Forms.TabPage();
            this.NewsSourcesTab = new System.Windows.Forms.TabPage();
            this.AppStartGB = new System.Windows.Forms.GroupBox();
            this.StartMaximized = new System.Windows.Forms.RadioButton();
            this.StartMinimized = new System.Windows.Forms.RadioButton();
            this.StartNormal = new System.Windows.Forms.RadioButton();
            this.MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.StartWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadNewsAtStartup = new System.Windows.Forms.CheckBox();
            this.DisableBadSources = new System.Windows.Forms.CheckBox();
            this.NewsDownloadTab = new System.Windows.Forms.TabPage();
            this.TimeInterval = new System.Windows.Forms.ComboBox();
            this.NumericValue = new System.Windows.Forms.NumericUpDown();
            this.DownlInterval = new System.Windows.Forms.Label();
            this.AutomaticalDownload = new System.Windows.Forms.CheckBox();
            this.ManageTabs.SuspendLayout();
            this.StartupTab.SuspendLayout();
            this.NewsSourcesTab.SuspendLayout();
            this.AppStartGB.SuspendLayout();
            this.NewsDownloadTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericValue)).BeginInit();
            this.SuspendLayout();
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
            // ManageTabs
            // 
            this.ManageTabs.Controls.Add(this.StartupTab);
            this.ManageTabs.Controls.Add(this.NewsSourcesTab);
            this.ManageTabs.Controls.Add(this.NewsDownloadTab);
            this.ManageTabs.Location = new System.Drawing.Point(22, 12);
            this.ManageTabs.Name = "ManageTabs";
            this.ManageTabs.SelectedIndex = 0;
            this.ManageTabs.Size = new System.Drawing.Size(624, 281);
            this.ManageTabs.TabIndex = 11;
            // 
            // StartupTab
            // 
            this.StartupTab.Controls.Add(this.AppStartGB);
            this.StartupTab.Controls.Add(this.MinimizeToTrayCheckBox);
            this.StartupTab.Controls.Add(this.StartWithWindowsCheckBox);
            this.StartupTab.Location = new System.Drawing.Point(4, 25);
            this.StartupTab.Name = "StartupTab";
            this.StartupTab.Padding = new System.Windows.Forms.Padding(3);
            this.StartupTab.Size = new System.Drawing.Size(616, 252);
            this.StartupTab.TabIndex = 0;
            this.StartupTab.Text = "Startup";
            this.StartupTab.UseVisualStyleBackColor = true;
            // 
            // NewsSourcesTab
            // 
            this.NewsSourcesTab.Controls.Add(this.DownloadNewsAtStartup);
            this.NewsSourcesTab.Controls.Add(this.DisableBadSources);
            this.NewsSourcesTab.Location = new System.Drawing.Point(4, 25);
            this.NewsSourcesTab.Name = "NewsSourcesTab";
            this.NewsSourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsSourcesTab.Size = new System.Drawing.Size(616, 252);
            this.NewsSourcesTab.TabIndex = 1;
            this.NewsSourcesTab.Text = "News Sources";
            this.NewsSourcesTab.UseVisualStyleBackColor = true;
            // 
            // AppStartGB
            // 
            this.AppStartGB.Controls.Add(this.StartMaximized);
            this.AppStartGB.Controls.Add(this.StartMinimized);
            this.AppStartGB.Controls.Add(this.StartNormal);
            this.AppStartGB.Location = new System.Drawing.Point(6, 91);
            this.AppStartGB.Name = "AppStartGB";
            this.AppStartGB.Size = new System.Drawing.Size(207, 150);
            this.AppStartGB.TabIndex = 5;
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
            // MinimizeToTrayCheckBox
            // 
            this.MinimizeToTrayCheckBox.AutoSize = true;
            this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(6, 46);
            this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
            this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(208, 21);
            this.MinimizeToTrayCheckBox.TabIndex = 4;
            this.MinimizeToTrayCheckBox.Tag = "2";
            this.MinimizeToTrayCheckBox.Text = "Minimize to Notification Area";
            this.MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeToTrayToggle);
            // 
            // StartWithWindowsCheckBox
            // 
            this.StartWithWindowsCheckBox.AutoSize = true;
            this.StartWithWindowsCheckBox.Location = new System.Drawing.Point(6, 6);
            this.StartWithWindowsCheckBox.Name = "StartWithWindowsCheckBox";
            this.StartWithWindowsCheckBox.Size = new System.Drawing.Size(148, 21);
            this.StartWithWindowsCheckBox.TabIndex = 3;
            this.StartWithWindowsCheckBox.Tag = "1";
            this.StartWithWindowsCheckBox.Text = "Start with Windows";
            this.StartWithWindowsCheckBox.UseVisualStyleBackColor = true;
            this.StartWithWindowsCheckBox.CheckedChanged += new System.EventHandler(this.StartWithWindowsToggle);
            // 
            // DownloadNewsAtStartup
            // 
            this.DownloadNewsAtStartup.AutoSize = true;
            this.DownloadNewsAtStartup.Location = new System.Drawing.Point(6, 46);
            this.DownloadNewsAtStartup.Name = "DownloadNewsAtStartup";
            this.DownloadNewsAtStartup.Size = new System.Drawing.Size(347, 21);
            this.DownloadNewsAtStartup.TabIndex = 6;
            this.DownloadNewsAtStartup.Tag = "5";
            this.DownloadNewsAtStartup.Text = "Download news automatically when program starts";
            this.DownloadNewsAtStartup.UseVisualStyleBackColor = true;
            this.DownloadNewsAtStartup.CheckedChanged += new System.EventHandler(this.DownloadAtStartupToggle);
            // 
            // DisableBadSources
            // 
            this.DisableBadSources.AutoSize = true;
            this.DisableBadSources.Location = new System.Drawing.Point(6, 6);
            this.DisableBadSources.Name = "DisableBadSources";
            this.DisableBadSources.Size = new System.Drawing.Size(300, 21);
            this.DisableBadSources.TabIndex = 5;
            this.DisableBadSources.Tag = "4";
            this.DisableBadSources.Text = "Disable news sources with invalid RSS files";
            this.DisableBadSources.UseVisualStyleBackColor = true;
            this.DisableBadSources.CheckedChanged += new System.EventHandler(this.DisableNewsSourcesToggle);
            // 
            // NewsDownloadTab
            // 
            this.NewsDownloadTab.Controls.Add(this.TimeInterval);
            this.NewsDownloadTab.Controls.Add(this.NumericValue);
            this.NewsDownloadTab.Controls.Add(this.DownlInterval);
            this.NewsDownloadTab.Controls.Add(this.AutomaticalDownload);
            this.NewsDownloadTab.Location = new System.Drawing.Point(4, 25);
            this.NewsDownloadTab.Name = "NewsDownloadTab";
            this.NewsDownloadTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsDownloadTab.Size = new System.Drawing.Size(616, 252);
            this.NewsDownloadTab.TabIndex = 2;
            this.NewsDownloadTab.Text = "News download";
            this.NewsDownloadTab.UseVisualStyleBackColor = true;
            // 
            // TimeInterval
            // 
            this.TimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeInterval.Enabled = false;
            this.TimeInterval.FormattingEnabled = true;
            this.TimeInterval.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours"});
            this.TimeInterval.Location = new System.Drawing.Point(73, 64);
            this.TimeInterval.Name = "TimeInterval";
            this.TimeInterval.Size = new System.Drawing.Size(146, 24);
            this.TimeInterval.TabIndex = 14;
            this.TimeInterval.SelectedValueChanged += new System.EventHandler(this.UnitSelectionEngine);
            // 
            // NumericValue
            // 
            this.NumericValue.Enabled = false;
            this.NumericValue.Location = new System.Drawing.Point(7, 64);
            this.NumericValue.Name = "NumericValue";
            this.NumericValue.Size = new System.Drawing.Size(53, 22);
            this.NumericValue.TabIndex = 13;
            this.NumericValue.ValueChanged += new System.EventHandler(this.AdjustingValueEngine);
            // 
            // DownlInterval
            // 
            this.DownlInterval.AutoSize = true;
            this.DownlInterval.Enabled = false;
            this.DownlInterval.Location = new System.Drawing.Point(3, 44);
            this.DownlInterval.Name = "DownlInterval";
            this.DownlInterval.Size = new System.Drawing.Size(124, 17);
            this.DownlInterval.TabIndex = 12;
            this.DownlInterval.Text = "Download interval:";
            // 
            // AutomaticalDownload
            // 
            this.AutomaticalDownload.AutoSize = true;
            this.AutomaticalDownload.Location = new System.Drawing.Point(6, 6);
            this.AutomaticalDownload.Name = "AutomaticalDownload";
            this.AutomaticalDownload.Size = new System.Drawing.Size(315, 21);
            this.AutomaticalDownload.TabIndex = 11;
            this.AutomaticalDownload.Text = "Download news automatically at a set interval";
            this.AutomaticalDownload.UseVisualStyleBackColor = true;
            this.AutomaticalDownload.CheckedChanged += new System.EventHandler(this.ToggleIntervalEnabling);
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
            this.Controls.Add(this.ManageTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.ShowOptions);
            this.ManageTabs.ResumeLayout(false);
            this.StartupTab.ResumeLayout(false);
            this.StartupTab.PerformLayout();
            this.NewsSourcesTab.ResumeLayout(false);
            this.NewsSourcesTab.PerformLayout();
            this.AppStartGB.ResumeLayout(false);
            this.AppStartGB.PerformLayout();
            this.NewsDownloadTab.ResumeLayout(false);
            this.NewsDownloadTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AcceptChanges;
        private System.Windows.Forms.Button DiscardChanges;
        private System.Windows.Forms.TabControl ManageTabs;
        private System.Windows.Forms.TabPage StartupTab;
        private System.Windows.Forms.TabPage NewsSourcesTab;
        private System.Windows.Forms.GroupBox AppStartGB;
        private System.Windows.Forms.RadioButton StartMaximized;
        private System.Windows.Forms.RadioButton StartMinimized;
        private System.Windows.Forms.RadioButton StartNormal;
        private System.Windows.Forms.CheckBox MinimizeToTrayCheckBox;
        private System.Windows.Forms.CheckBox StartWithWindowsCheckBox;
        private System.Windows.Forms.CheckBox DownloadNewsAtStartup;
        private System.Windows.Forms.CheckBox DisableBadSources;
        private System.Windows.Forms.TabPage NewsDownloadTab;
        private System.Windows.Forms.ComboBox TimeInterval;
        private System.Windows.Forms.NumericUpDown NumericValue;
        private System.Windows.Forms.Label DownlInterval;
        private System.Windows.Forms.CheckBox AutomaticalDownload;
    }
}