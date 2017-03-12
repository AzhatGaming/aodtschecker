namespace TSChecker
{
    partial class MemEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemEdit));
            this.memberInfoBox = new System.Windows.Forms.GroupBox();
            this.divisionDropdown = new System.Windows.Forms.ComboBox();
            this.rankDropdown = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.divisionLabel = new System.Windows.Forms.Label();
            this.rankLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addCharTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.charDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.divImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.charNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psuLinkCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.memberInfoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // memberInfoBox
            // 
            this.memberInfoBox.BackColor = System.Drawing.Color.Black;
            this.memberInfoBox.Controls.Add(this.divisionDropdown);
            this.memberInfoBox.Controls.Add(this.rankDropdown);
            this.memberInfoBox.Controls.Add(this.nameTextBox);
            this.memberInfoBox.Controls.Add(this.divisionLabel);
            this.memberInfoBox.Controls.Add(this.rankLabel);
            this.memberInfoBox.Controls.Add(this.nameLabel);
            this.memberInfoBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberInfoBox.ForeColor = System.Drawing.Color.Silver;
            this.memberInfoBox.Location = new System.Drawing.Point(13, 33);
            this.memberInfoBox.Name = "memberInfoBox";
            this.memberInfoBox.Size = new System.Drawing.Size(331, 102);
            this.memberInfoBox.TabIndex = 1;
            this.memberInfoBox.TabStop = false;
            this.memberInfoBox.Text = "Member Info";
            // 
            // divisionDropdown
            // 
            this.divisionDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.divisionDropdown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divisionDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.divisionDropdown.FormattingEnabled = true;
            this.divisionDropdown.Location = new System.Drawing.Point(83, 46);
            this.divisionDropdown.Name = "divisionDropdown";
            this.divisionDropdown.Size = new System.Drawing.Size(173, 21);
            this.divisionDropdown.TabIndex = 8;
            // 
            // rankDropdown
            // 
            this.rankDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.rankDropdown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rankDropdown.FormattingEnabled = true;
            this.rankDropdown.Location = new System.Drawing.Point(83, 71);
            this.rankDropdown.Name = "rankDropdown";
            this.rankDropdown.Size = new System.Drawing.Size(173, 21);
            this.rankDropdown.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.nameTextBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameTextBox.Location = new System.Drawing.Point(83, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(173, 21);
            this.nameTextBox.TabIndex = 4;
            // 
            // divisionLabel
            // 
            this.divisionLabel.AutoSize = true;
            this.divisionLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divisionLabel.ForeColor = System.Drawing.Color.White;
            this.divisionLabel.Location = new System.Drawing.Point(20, 48);
            this.divisionLabel.Name = "divisionLabel";
            this.divisionLabel.Size = new System.Drawing.Size(57, 13);
            this.divisionLabel.TabIndex = 2;
            this.divisionLabel.Text = "Division:";
            // 
            // rankLabel
            // 
            this.rankLabel.AutoSize = true;
            this.rankLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankLabel.ForeColor = System.Drawing.Color.White;
            this.rankLabel.Location = new System.Drawing.Point(32, 75);
            this.rankLabel.Name = "rankLabel";
            this.rankLabel.Size = new System.Drawing.Size(41, 13);
            this.rankLabel.TabIndex = 1;
            this.rankLabel.Text = "Rank:";
            this.rankLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(32, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(269, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addCharTextbox
            // 
            this.addCharTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.addCharTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addCharTextbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCharTextbox.ForeColor = System.Drawing.Color.Silver;
            this.addCharTextbox.Location = new System.Drawing.Point(171, 141);
            this.addCharTextbox.Name = "addCharTextbox";
            this.addCharTextbox.Size = new System.Drawing.Size(173, 21);
            this.addCharTextbox.TabIndex = 8;
            this.addCharTextbox.Text = "Enter Character ID...";
            this.addCharTextbox.Enter += new System.EventHandler(this.addCharTextbox_Enter);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(145, 141);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(21, 21);
            this.button2.TabIndex = 9;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // charDataGridView
            // 
            this.charDataGridView.AllowUserToResizeColumns = false;
            this.charDataGridView.AllowUserToResizeRows = false;
            this.charDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.charDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.charDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.charDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.charDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.divImgCol,
            this.charNameCol,
            this.brCol,
            this.psuLinkCol,
            this.delCol});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.charDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.charDataGridView.EnableHeadersVisualStyles = false;
            this.charDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.charDataGridView.Location = new System.Drawing.Point(12, 168);
            this.charDataGridView.Name = "charDataGridView";
            this.charDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.charDataGridView.RowHeadersVisible = false;
            this.charDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.charDataGridView.Size = new System.Drawing.Size(334, 81);
            this.charDataGridView.TabIndex = 10;
            this.charDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.charDataGridView_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::TSChecker.Properties.Resources.terran_republic_logo_vector_by_westy543_d5xkdzh;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 22;
            // 
            // divImgCol
            // 
            this.divImgCol.HeaderText = "";
            this.divImgCol.Name = "divImgCol";
            this.divImgCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.divImgCol.Width = 22;
            // 
            // charNameCol
            // 
            this.charNameCol.HeaderText = "Name";
            this.charNameCol.Name = "charNameCol";
            this.charNameCol.ReadOnly = true;
            this.charNameCol.Width = 120;
            // 
            // brCol
            // 
            this.brCol.HeaderText = "BR";
            this.brCol.Name = "brCol";
            this.brCol.ReadOnly = true;
            this.brCol.Width = 30;
            // 
            // psuLinkCol
            // 
            this.psuLinkCol.ActiveLinkColor = System.Drawing.Color.White;
            this.psuLinkCol.HeaderText = "PSU Link";
            this.psuLinkCol.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.psuLinkCol.Name = "psuLinkCol";
            this.psuLinkCol.ReadOnly = true;
            this.psuLinkCol.Text = "PSU";
            this.psuLinkCol.VisitedLinkColor = System.Drawing.Color.Orange;
            this.psuLinkCol.Width = 110;
            // 
            // delCol
            // 
            this.delCol.HeaderText = "";
            this.delCol.Name = "delCol";
            this.delCol.ReadOnly = true;
            this.delCol.Text = "X";
            this.delCol.Width = 25;
            // 
            // MemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(358, 293);
            this.Controls.Add(this.charDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addCharTextbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.memberInfoBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemEdit";
            this.Text = "MemEdit";
            this.memberInfoBox.ResumeLayout(false);
            this.memberInfoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox memberInfoBox;
        private System.Windows.Forms.Label divisionLabel;
        private System.Windows.Forms.Label rankLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox rankDropdown;
        private System.Windows.Forms.TextBox addCharTextbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView charDataGridView;
        private System.Windows.Forms.ComboBox divisionDropdown;
        private System.Windows.Forms.DataGridViewImageColumn divImgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn charNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn brCol;
        private System.Windows.Forms.DataGridViewLinkColumn psuLinkCol;
        private System.Windows.Forms.DataGridViewButtonColumn delCol;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}