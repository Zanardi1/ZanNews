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
            this.StartWithWindowsCheckBox.Text = "Start with Windows";
            this.StartWithWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeToTrayCheckBox
            // 
            this.MinimizeToTrayCheckBox.AutoSize = true;
            this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(34, 83);
            this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
            this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(128, 21);
            this.MinimizeToTrayCheckBox.TabIndex = 1;
            this.MinimizeToTrayCheckBox.Text = "Minimize to tray";
            this.MinimizeToTrayCheckBox.UseVisualStyleBackColor = true;
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
            this.AppStartGB.Text = "Application start options";
            // 
            // StartMaximized
            // 
            this.StartMaximized.AutoSize = true;
            this.StartMaximized.Location = new System.Drawing.Point(18, 113);
            this.StartMaximized.Name = "StartMaximized";
            this.StartMaximized.Size = new System.Drawing.Size(128, 21);
            this.StartMaximized.TabIndex = 4;
            this.StartMaximized.TabStop = true;
            this.StartMaximized.Text = "Start maximized";
            this.StartMaximized.UseVisualStyleBackColor = true;
            // 
            // StartMinimized
            // 
            this.StartMinimized.AutoSize = true;
            this.StartMinimized.Location = new System.Drawing.Point(18, 30);
            this.StartMinimized.Name = "StartMinimized";
            this.StartMinimized.Size = new System.Drawing.Size(125, 21);
            this.StartMinimized.TabIndex = 3;
            this.StartMinimized.TabStop = true;
            this.StartMinimized.Text = "Start minimized";
            this.StartMinimized.UseVisualStyleBackColor = true;
            // 
            // StartNormal
            // 
            this.StartNormal.AutoSize = true;
            this.StartNormal.Location = new System.Drawing.Point(18, 71);
            this.StartNormal.Name = "StartNormal";
            this.StartNormal.Size = new System.Drawing.Size(106, 21);
            this.StartNormal.TabIndex = 3;
            this.StartNormal.TabStop = true;
            this.StartNormal.Text = "Start normal";
            this.StartNormal.UseVisualStyleBackColor = true;
            // 
            // DisableBadSources
            // 
            this.DisableBadSources.AutoSize = true;
            this.DisableBadSources.Location = new System.Drawing.Point(34, 296);
            this.DisableBadSources.Name = "DisableBadSources";
            this.DisableBadSources.Size = new System.Drawing.Size(300, 21);
            this.DisableBadSources.TabIndex = 3;
            this.DisableBadSources.Text = "Disable news sources with invalid RSS files";
            this.DisableBadSources.UseVisualStyleBackColor = true;
            // 
            // OptionsWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisableBadSources);
            this.Controls.Add(this.AppStartGB);
            this.Controls.Add(this.MinimizeToTrayCheckBox);
            this.Controls.Add(this.StartWithWindowsCheckBox);
            this.Name = "OptionsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
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
    }
}