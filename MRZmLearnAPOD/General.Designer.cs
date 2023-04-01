
namespace MRZmLearnAPOD
{
    partial class General
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(General));
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.ShowTodaysImageCheckBox = new System.Windows.Forms.CheckBox();
            this.LimitRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.ImagesTodayTextBox = new System.Windows.Forms.TextBox();
            this.ImageCopyrightTextBox = new System.Windows.Forms.TextBox();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(0, 0);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 0;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(0, 174);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(164, 23);
            this.LaunchButton.TabIndex = 1;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.label);
            this.Settings.Controls.Add(this.LimitRangeCheckBox);
            this.Settings.Controls.Add(this.ShowTodaysImageCheckBox);
            this.Settings.Location = new System.Drawing.Point(0, 203);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(164, 106);
            this.Settings.TabIndex = 2;
            this.Settings.TabStop = false;
            this.Settings.Text = "Settings";
            // 
            // ShowTodaysImageCheckBox
            // 
            this.ShowTodaysImageCheckBox.AutoSize = true;
            this.ShowTodaysImageCheckBox.Location = new System.Drawing.Point(3, 16);
            this.ShowTodaysImageCheckBox.Name = "ShowTodaysImageCheckBox";
            this.ShowTodaysImageCheckBox.Size = new System.Drawing.Size(118, 17);
            this.ShowTodaysImageCheckBox.TabIndex = 0;
            this.ShowTodaysImageCheckBox.Text = "Show todays image";
            this.ShowTodaysImageCheckBox.UseVisualStyleBackColor = true;
            // 
            // LimitRangeCheckBox
            // 
            this.LimitRangeCheckBox.AutoSize = true;
            this.LimitRangeCheckBox.Location = new System.Drawing.Point(3, 39);
            this.LimitRangeCheckBox.Name = "LimitRangeCheckBox";
            this.LimitRangeCheckBox.Size = new System.Drawing.Size(77, 17);
            this.LimitRangeCheckBox.TabIndex = 1;
            this.LimitRangeCheckBox.Text = "Limit range";
            this.LimitRangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 59);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(134, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Images downloaded today:";
            // 
            // ImagesTodayTextBox
            // 
            this.ImagesTodayTextBox.BackColor = System.Drawing.Color.SeaShell;
            this.ImagesTodayTextBox.Location = new System.Drawing.Point(137, 259);
            this.ImagesTodayTextBox.Name = "ImagesTodayTextBox";
            this.ImagesTodayTextBox.ReadOnly = true;
            this.ImagesTodayTextBox.Size = new System.Drawing.Size(27, 20);
            this.ImagesTodayTextBox.TabIndex = 3;
            // 
            // ImageCopyrightTextBox
            // 
            this.ImageCopyrightTextBox.BackColor = System.Drawing.Color.SeaShell;
            this.ImageCopyrightTextBox.Location = new System.Drawing.Point(88, 379);
            this.ImageCopyrightTextBox.Name = "ImageCopyrightTextBox";
            this.ImageCopyrightTextBox.ReadOnly = true;
            this.ImageCopyrightTextBox.Size = new System.Drawing.Size(76, 20);
            this.ImageCopyrightTextBox.TabIndex = 5;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(6, 382);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(85, 13);
            this.labelCopyright.TabIndex = 4;
            this.labelCopyright.Text = "Image copyright:";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(6, 422);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 448);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(964, 193);
            this.textBoxDescription.TabIndex = 7;
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePictureBox.Location = new System.Drawing.Point(167, 0);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(797, 435);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePictureBox.TabIndex = 8;
            this.ImagePictureBox.TabStop = false;
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 641);
            this.Controls.Add(this.ImagePictureBox);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.ImageCopyrightTextBox);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.ImagesTodayTextBox);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.MonthCalendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(980, 680);
            this.Name = "General";
            this.Text = "MRZ APOD";
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.CheckBox LimitRangeCheckBox;
        private System.Windows.Forms.CheckBox ShowTodaysImageCheckBox;
        private System.Windows.Forms.TextBox ImagesTodayTextBox;
        private System.Windows.Forms.TextBox ImageCopyrightTextBox;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.PictureBox ImagePictureBox;
    }
}

