namespace WorkshopUtils.UI
{
    partial class GMAParserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.txtFn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.txtAddonVersion = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtAddonName = new System.Windows.Forms.Label();
            this.txtTimestamp = new System.Windows.Forms.Label();
            this.txtFormatVersion = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAuthorName = new System.Windows.Forms.Label();
            this.txtAuthorSteamID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFn
            // 
            this.txtFn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFn.Location = new System.Drawing.Point(13, 13);
            this.txtFn.Name = "txtFn";
            this.txtFn.ReadOnly = true;
            this.txtFn.Size = new System.Drawing.Size(467, 20);
            this.txtFn.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(486, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtAddonVersion);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtAddonName);
            this.groupBox1.Controls.Add(this.txtTimestamp);
            this.groupBox1.Controls.Add(this.txtFormatVersion);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Addon Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbFiles);
            this.groupBox3.Location = new System.Drawing.Point(259, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 273);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Files";
            // 
            // lbFiles
            // 
            this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(3, 16);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(227, 254);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.DoubleClick += new System.EventHandler(this.LbFiles_DoubleClick);
            // 
            // txtAddonVersion
            // 
            this.txtAddonVersion.AutoSize = true;
            this.txtAddonVersion.Location = new System.Drawing.Point(93, 100);
            this.txtAddonVersion.Name = "txtAddonVersion";
            this.txtAddonVersion.Size = new System.Drawing.Size(79, 13);
            this.txtAddonVersion.TabIndex = 9;
            this.txtAddonVersion.Text = "-- Nothing yet --";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(93, 55);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(79, 13);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "-- Nothing yet --";
            // 
            // txtAddonName
            // 
            this.txtAddonName.AutoSize = true;
            this.txtAddonName.Location = new System.Drawing.Point(93, 42);
            this.txtAddonName.Name = "txtAddonName";
            this.txtAddonName.Size = new System.Drawing.Size(79, 13);
            this.txtAddonName.TabIndex = 7;
            this.txtAddonName.Text = "-- Nothing yet --";
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.AutoSize = true;
            this.txtTimestamp.Location = new System.Drawing.Point(93, 29);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(79, 13);
            this.txtTimestamp.TabIndex = 6;
            this.txtTimestamp.Text = "-- Nothing yet --";
            // 
            // txtFormatVersion
            // 
            this.txtFormatVersion.AutoSize = true;
            this.txtFormatVersion.Location = new System.Drawing.Point(93, 16);
            this.txtFormatVersion.Name = "txtFormatVersion";
            this.txtFormatVersion.Size = new System.Drawing.Size(79, 13);
            this.txtFormatVersion.TabIndex = 4;
            this.txtFormatVersion.Text = "-- Nothing yet --";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAuthorName);
            this.groupBox2.Controls.Add(this.txtAuthorSteamID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(10, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 60);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Author";
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.AutoSize = true;
            this.txtAuthorName.Location = new System.Drawing.Point(79, 20);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new System.Drawing.Size(79, 13);
            this.txtAuthorName.TabIndex = 3;
            this.txtAuthorName.Text = "-- Nothing yet --";
            // 
            // txtAuthorSteamID
            // 
            this.txtAuthorSteamID.AutoSize = true;
            this.txtAuthorSteamID.Location = new System.Drawing.Point(79, 37);
            this.txtAuthorSteamID.Name = "txtAuthorSteamID";
            this.txtAuthorSteamID.Size = new System.Drawing.Size(79, 13);
            this.txtAuthorSteamID.TabIndex = 2;
            this.txtAuthorSteamID.Text = "-- Nothing yet --";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "SteamID64:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Timestamp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format Version:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GMAParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 347);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFn);
            this.MinimumSize = new System.Drawing.Size(539, 386);
            this.Name = "GMAParserForm";
            this.ShowIcon = false;
            this.Text = "GMA Parser Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtAuthorName;
        private System.Windows.Forms.Label txtAuthorSteamID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtAddonVersion;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtAddonName;
        private System.Windows.Forms.Label txtTimestamp;
        private System.Windows.Forms.Label txtFormatVersion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button button2;
    }
}