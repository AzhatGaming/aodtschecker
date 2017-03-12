using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Common.AOD;

namespace TSChecker
{
    public partial class MemEdit : Form
    {
        private List<Common.Daybreak.Character> characters = new List<Common.Daybreak.Character>();
        private Member currentMember = new Member();
        public MemEdit(string userName)
        {
            InitializeComponent();
            SetupFormWindow();
            PopulateDropdownLists();
            FillInInfo(userName);
        }

        private PictureBox title = new PictureBox();
        private PictureBox closeBtn = new PictureBox();
        private PictureBox logo = new PictureBox();
        private Label titleLabel = new Label();

        private bool drag = false;
        private Point startPoint = new Point(0, 0);

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

            this.titleLabel.Text = "Edit Member Info";
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

            this.memberInfoBox.ForeColor = Color.Silver;

            var imgList = new ImageList();
            imgList.Images.Add(TSChecker.Properties.Resources.offline);
            imgList.Images.Add(TSChecker.Properties.Resources.online);
            imgList.Images.Add(TSChecker.Properties.Resources.error);

            foreach (DataGridViewRow row in this.charDataGridView.Rows)
            {
                try
                {
                    this.charDataGridView.Rows.Remove(row);
                }
                catch { }
            }
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender.Equals(this.closeBtn))
            {
                this.Close();
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

        private void PopulateDropdownLists()
        {
            this.rankDropdown.Items.AddRange(AODRank.GetRanks().ToArray());
            var divisions = TSChecker.Properties.Settings.Default.AOD_Divisions.Split(',');
            foreach (var div in divisions)
            {
                this.divisionDropdown.Items.Add(div);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CustomBorder.Render(new Rectangle(0, -5, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1 + 5), e.Graphics);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        private async void FillInInfo(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                currentMember = (from member in Program.userInfo.Members
                                 where member.ForumName == userName
                                 select member).FirstOrDefault();

                if (null != currentMember)
                {
                    foreach (Character character in currentMember.Characters)
                    {
                        var charObject = (await DBCensus_Grabber.GetCharacterData(character.CharacterId)).Character.FirstOrDefault();
                        characters.Add(charObject);
                        if (null != charObject)
                        {
                            this.charDataGridView.Rows.Add();
                            var row = charDataGridView.Rows[charDataGridView.Rows.GetLastRow(DataGridViewElementStates.Visible) - 1];
                            row.Cells[0].Value = TSChecker.Properties.Resources.terran_republic_logo_vector_by_westy543_d5xkdzh;
                            row.Cells[1].Value = charObject.Name.First;
                            row.Cells[2].Value = charObject.BattleRank.Value;
                            row.Cells[3].Value = string.Format("http://www.planetside-universe.com/character-{0}.php", charObject.CharacterId);
                            row.Cells[4].Value = "x";
                        }
                    }

                    this.nameTextBox.Text = currentMember.ForumName;
                    //this.nameTextBox.Enabled = false;
                    this.rankDropdown.SelectedText = currentMember.Rank;
                    //this.rankTextBox.Enabled = false;
                    this.divisionDropdown.SelectedText = currentMember.Division;
                    //this.divisionTextBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SerializeAndSaveXml();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void SerializeAndSaveXml()
        {
            ReplaceMemberElement();
            Common.CommonTools.SaveLocalFile(Program.userInfo);
            await GoogleDriveTool.SaveUserInformationToDrive();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReplaceMemberElement()
        {
            currentMember = new Common.AOD.Member();
            currentMember.Characters = new List<Character>();
            currentMember.ForumName = nameTextBox.Text;
            currentMember.Rank = rankDropdown.SelectedItem.ToString();
            currentMember.Division = divisionDropdown.SelectedItem.ToString();
            currentMember.Status = "Available";

            foreach (var character in characters)
            {
                var newCharacter = new Character();
                newCharacter.CharacterId = character.CharacterId;
                newCharacter.CharacterName = character.Name.First;
                if (character.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODRId))
                    newCharacter.Faction = "AODR";
                else if (character.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODCId))
                    newCharacter.Faction = "AODC";
                else if (character.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODSId))
                    newCharacter.Faction = "AODS";
                newCharacter.Rank = "Full Member";
                newCharacter.RankOrdinal = 4;
                newCharacter.MemberSince = character.Times.Creation;
                newCharacter.MemberSinceDate = character.Times.CreationDate;
                currentMember.Characters.Add(newCharacter);
            }

            bool replaced = false;
            for (int memberIdx = 0; memberIdx < Program.userInfo.Members.Count; memberIdx++)
            {
                if (Program.userInfo.Members[memberIdx].ForumName == currentMember.ForumName)
                {
                    Program.userInfo.Members[memberIdx] = currentMember;
                    replaced = true;
                }
            }
            if (!replaced)
            {
                Program.userInfo.Members.Add(currentMember);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ulong characterId;
            bool isNumeric = ulong.TryParse(addCharTextbox.Text, System.Globalization.NumberStyles.Number, null, out characterId);
            if (isNumeric)
            {
                var charObject = (await DBCensus_Grabber.GetCharacterData(characterId)).Character.FirstOrDefault();
                characters.Add(charObject);
                if (null != charObject)
                {
                    this.charDataGridView.Rows.Add();
                    var row = charDataGridView.Rows[charDataGridView.Rows.GetLastRow(DataGridViewElementStates.Visible) - 1];
                    if (charObject.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODRId))
                        row.Cells[0].Value = TSChecker.Properties.Resources.terran_republic_logo_vector_by_westy543_d5xkdzh;
                    else if (charObject.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODCId))
                        row.Cells[0].Value = TSChecker.Properties.Resources.new_conglomerate_logo_vector_by_westy543_d5xfoym;
                    else if (charObject.Outfit.OutfitId.ToString().Equals(TSChecker.Properties.Settings.Default.AODSId))
                        row.Cells[0].Value = TSChecker.Properties.Resources.vanu_sovereignty_logo_vector_by_westy543_d5xs2hl;                
                    row.Cells[1].Value = charObject.Name.First;
                    row.Cells[2].Value = charObject.BattleRank.Value;
                    row.Cells[3].Value = string.Format("http://www.planetside-universe.com/character-{0}.php", charObject.CharacterId);              
                    row.Cells[4].Value = "x";
                }
                else
                {
                    MessageBox.Show("Character not found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid character ID, must be numeric.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            addCharTextbox.Text = "";
        }

        private void addCharTextbox_Enter(object sender, EventArgs e)
        {
            addCharTextbox.Text = "";
        }

        private void charDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var url = charDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                System.Diagnostics.Process.Start(url);
            }
            else if (e.ColumnIndex == 4 && charDataGridView.Rows.Count > 1)
            {
                var remChar = charDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                foreach (var character in characters)
                {
                    if (character.Name.FirstLower == remChar.ToLower())
                        characters.Remove(character);
                }
                charDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
