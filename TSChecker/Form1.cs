using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common.AOD;

namespace TSChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupFormWindow();
            ingamelist_Clear();
            ingamelist_Populate();
        }

        #region formInit

        private PictureBox title = new PictureBox();
        private PictureBox closeBtn = new PictureBox();
        private PictureBox logo = new PictureBox();
        private Label titleLabel = new Label();

        private bool drag = false;
        private Point startPoint = new Point(0, 0);

        private bool showOffline;

        private Timer timer1 = new Timer();
        private int countdownTime;
        private bool autoRefresh;
        public void InitTimer()
        {
            if (autoRefresh)
            {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000;
                countdownTime = 60;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            timerLabel.Text = string.Format("Auto refresh in {0}...", countdownTime);
            if (countdownTime == 0)
            {
                timerLabel.Text = "Refreshing...";
                timer1.Stop();
                ingamelist_Populate();
            }
            countdownTime--;
        }

        private void KillTimer()
        {
            timerLabel.Text = "";
            timer1.Stop();
        }

        private void SetupFormWindow()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.title.Location = this.Location;
            this.title.Width = this.Width - 4;
            this.title.Height = 25;
            this.title.Location = new Point(this.Location.X + 2, this.Location.Y + 2);
            this.title.BackColor = Color.FromArgb(32, 32, 32);
            this.Controls.Add(this.title);

            this.logo.Image = new Bitmap(TSChecker.Properties.Resources.logo64);
            this.logo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logo.Width = 20;
            this.logo.Height = 20;
            this.logo.BackColor = Color.FromArgb(32, 32, 32);
            this.logo.Location = new Point(this.Location.X + 5, this.Location.Y + 6);
            this.Controls.Add(this.logo);
            this.logo.BringToFront();

            this.closeBtn.Image = new Bitmap(TSChecker.Properties.Resources.closebtn64);
            this.closeBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            this.closeBtn.BackColor = Color.FromArgb(32, 32, 32);
            this.closeBtn.Width = 20;
            this.closeBtn.Height = 20;
            this.closeBtn.Location = new Point(this.Location.X + this.Width - 28, this.Location.Y + 6);
            this.Controls.Add(this.closeBtn);
            this.closeBtn.BringToFront();

            this.titleLabel.Text = "Teamspeak Check Tool";
            this.titleLabel.BackColor = Color.FromArgb(32, 32, 32);
            this.titleLabel.ForeColor = Color.Silver;
            this.titleLabel.Font = new Font("Verdana", 9);
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new Point(this.Location.X + 30, this.Location.Y + 9);
            this.Controls.Add(titleLabel);
            this.titleLabel.BringToFront();

            this.closeBtn.MouseClick += new MouseEventHandler(Control_MouseClick);

            this.title.MouseDown += new MouseEventHandler(Title_MouseDown);
            this.title.MouseUp += new MouseEventHandler(Title_MouseUp);
            this.title.MouseMove += new MouseEventHandler(Title_MouseMove);

            this.titleLabel.MouseDown += new MouseEventHandler(Title_MouseDown);
            this.titleLabel.MouseUp += new MouseEventHandler(Title_MouseUp);
            this.titleLabel.MouseMove += new MouseEventHandler(Title_MouseMove);
            this.titleLabel.BringToFront();

            var imgList = new ImageList();
            imgList.Images.Add(TSChecker.Properties.Resources.offline);
            imgList.Images.Add(TSChecker.Properties.Resources.online);
            imgList.Images.Add(TSChecker.Properties.Resources.error);
            imgList.Images.Add(TSChecker.Properties.Resources.offline_roster);

            ingamelist.SmallImageList = imgList;
            ingamelist.View = View.Details;
            ingamelist.Scrollable = true;

            var dummyHeader = new ColumnHeader();
            dummyHeader.Text = "";
            dummyHeader.Name = "col1";
            dummyHeader.Width = ingamelist.Width - 25;
            ingamelist.Columns.Add(dummyHeader);
            ingamelist.HeaderStyle = ColumnHeaderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CustomBorder.Render(new Rectangle(0, -5, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1 + 5), e.Graphics);
        }

        #endregion

        private async void ingamelist_Populate()
        {
            var members = await XmlQuery.GetMembersWithStatus();
            ingamelist.Items.Clear();

            foreach (var errors in members.Item3)
                ingamelist.Items.Add(errors, 2);
            foreach (var offline in members.Item2)
                ingamelist.Items.Add(offline, 0);
            foreach (var online in members.Item1)
                ingamelist.Items.Add(online, 1);
            if (showOffline)
            {
                foreach (var roster_offline in members.Item4)
                    ingamelist.Items.Add(roster_offline, 3);
            }

            KillTimer();
            InitTimer();
        }

        private void ingamelist_Clear()
        {
            ingamelist.Items.Clear();
            ingamelist.Items.Add("Loading...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingamelist_Clear();
            ingamelist_Populate();
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(this.closeBtn))
            {
                this.Close();
                Application.Exit();
            }
        }

        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
            this.drag = true;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X, p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

        private void ingamelist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ingamelist.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void editMemberInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemEdit memberEditForm = new MemEdit(ingamelist.FocusedItem.Text);
            memberEditForm.ShowDialog();
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemEdit memberEditForm = new MemEdit(string.Empty);
            memberEditForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
        }

        private void showOfflineMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOfflineMembersToolStripMenuItem.Checked = !showOfflineMembersToolStripMenuItem.Checked;
            showOffline = showOfflineMembersToolStripMenuItem.Checked;
            this.ingamelist_Populate();
        }

        private void autoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = !autoRefreshToolStripMenuItem.Checked;
            autoRefresh = autoRefreshToolStripMenuItem.Checked;
            if (autoRefresh)
                InitTimer();
            else
                KillTimer();
        }

        private void exportMembersListToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveDialog.DefaultExt = "csv";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "AODUserInfo";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                {
                    writer.Write(Program.userInfo.ConvertToCSV());
                }
            }
        }

        private async void importMembersListCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "CSV Files (*.csv)|*.csv";
            openDialog.DefaultExt = "csv";
            openDialog.AddExtension = true;
            openDialog.FileName = "AODUserInfo";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                using (var reader = new System.IO.StreamReader(openDialog.FileName))
                {
                    var fileData = reader.ReadToEnd();
                    Program.userInfo = Program.userInfo.ParseCSV(fileData);
                    Common.CommonTools.SaveLocalFile(Program.userInfo);
                    await GoogleDriveTool.SaveUserInformationToDrive();
                }
            }
        }
    }
}
