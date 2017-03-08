namespace TSChecker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.ingamelist = new System.Windows.Forms.ListView();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMemberInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showOfflineMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMembersListToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMembersListCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(158, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ingamelist
            // 
            this.ingamelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ingamelist.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingamelist.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ingamelist.Location = new System.Drawing.Point(12, 62);
            this.ingamelist.Name = "ingamelist";
            this.ingamelist.Size = new System.Drawing.Size(221, 296);
            this.ingamelist.TabIndex = 7;
            this.ingamelist.UseCompatibleStateImageBehavior = false;
            this.ingamelist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ingamelist_MouseClick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Gray;
            this.timerLabel.Location = new System.Drawing.Point(100, 391);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 14);
            this.timerLabel.TabIndex = 8;
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Members";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMemberInformationToolStripMenuItem,
            this.addMemberToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 48);
            // 
            // editMemberInformationToolStripMenuItem
            // 
            this.editMemberInformationToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.editMemberInformationToolStripMenuItem.Name = "editMemberInformationToolStripMenuItem";
            this.editMemberInformationToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.editMemberInformationToolStripMenuItem.Text = "Edit Member Information";
            this.editMemberInformationToolStripMenuItem.Click += new System.EventHandler(this.editMemberInformationToolStripMenuItem_Click);
            // 
            // addMemberToolStripMenuItem
            // 
            this.addMemberToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addMemberToolStripMenuItem.Name = "addMemberToolStripMenuItem";
            this.addMemberToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.addMemberToolStripMenuItem.Text = "Add Member";
            this.addMemberToolStripMenuItem.Click += new System.EventHandler(this.addMemberToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TSChecker.Properties.Resources.hamburger2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(209, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOfflineMembersToolStripMenuItem,
            this.autoRefreshToolStripMenuItem,
            this.exportMembersListToCSVToolStripMenuItem,
            this.importMembersListCSVToolStripMenuItem,
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(319, 114);
            // 
            // showOfflineMembersToolStripMenuItem
            // 
            this.showOfflineMembersToolStripMenuItem.Name = "showOfflineMembersToolStripMenuItem";
            this.showOfflineMembersToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.showOfflineMembersToolStripMenuItem.Text = "Show Offline Members";
            this.showOfflineMembersToolStripMenuItem.Click += new System.EventHandler(this.showOfflineMembersToolStripMenuItem_Click);
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.autoRefreshToolStripMenuItem.Text = "Auto-Refresh";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.autoRefreshToolStripMenuItem_Click);
            // 
            // exportMembersListToCSVToolStripMenuItem
            // 
            this.exportMembersListToCSVToolStripMenuItem.Name = "exportMembersListToCSVToolStripMenuItem";
            this.exportMembersListToCSVToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.exportMembersListToCSVToolStripMenuItem.Text = "Export Members List to CSV";
            this.exportMembersListToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportMembersListToCSVToolStripMenuItem_Click);
            // 
            // importMembersListCSVToolStripMenuItem
            // 
            this.importMembersListCSVToolStripMenuItem.Name = "importMembersListCSVToolStripMenuItem";
            this.importMembersListCSVToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.importMembersListCSVToolStripMenuItem.Text = "Import Members List CSV";
            this.importMembersListCSVToolStripMenuItem.Click += new System.EventHandler(this.importMembersListCSVToolStripMenuItem_Click);
            // 
            // exportCurrentOnlineMembersToCSVToolStripMenuItem
            // 
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem.Enabled = false;
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem.Name = "exportCurrentOnlineMembersToCSVToolStripMenuItem";
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.exportCurrentOnlineMembersToCSVToolStripMenuItem.Text = "Export Current Online Members to CSV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(245, 414);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.ingamelist);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AOD Teamspeak Checker";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ingamelist;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editMemberInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMemberToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showOfflineMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMembersListToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMembersListCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentOnlineMembersToCSVToolStripMenuItem;
    }
}

