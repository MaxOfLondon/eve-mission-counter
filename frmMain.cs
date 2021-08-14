using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  public class frmMain : Form
  {
    private IContainer components;
    private DataGridView dataGridView1;
    private Button cmdInc;
    private Button cmdClose;
    private ComboBox lstFilter;
    private Label label1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem renameToolStripMenuItem;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem newToolStripMenuItem;
    private Button cmdSkinned;
    private StandingList standingList;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      this.dataGridView1 = new DataGridView();
      this.cmdInc = new Button();
      this.cmdClose = new Button();
      this.lstFilter = new ComboBox();
      this.label1 = new Label();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.tabPage2 = new TabPage();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.renameToolStripMenuItem = new ToolStripMenuItem();
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripSeparator();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.cmdSkinned = new Button();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.tabControl1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      gridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
      this.dataGridView1.AlternatingRowsDefaultCellStyle = gridViewCellStyle1;
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new Point(12, 72);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      gridViewCellStyle2.BackColor = SystemColors.Control;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.WindowText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
      this.dataGridView1.RowHeadersDefaultCellStyle = gridViewCellStyle2;
      this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.dataGridView1.RowsDefaultCellStyle = gridViewCellStyle3;
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
      this.dataGridView1.Size = new Size(520, 140);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
      this.cmdInc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdInc.Location = new Point(320, 218);
      this.cmdInc.Name = "cmdInc";
      this.cmdInc.Size = new Size(75, 23);
      this.cmdInc.TabIndex = 1;
      this.cmdInc.Text = "+ 1";
      this.cmdInc.UseVisualStyleBackColor = true;
      this.cmdInc.Click += new EventHandler(this.cmdInc_Click);
      this.cmdClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.cmdClose.Location = new Point(457, 218);
      this.cmdClose.Name = "cmdClose";
      this.cmdClose.Size = new Size(75, 23);
      this.cmdClose.TabIndex = 2;
      this.cmdClose.Text = "Close";
      this.cmdClose.UseVisualStyleBackColor = true;
      this.cmdClose.Click += new EventHandler(this.cmdClose_Click);
      this.lstFilter.DropDownStyle = ComboBoxStyle.DropDownList;
      this.lstFilter.FormattingEnabled = true;
      this.lstFilter.Location = new Point(60, 45);
      this.lstFilter.Name = "lstFilter";
      this.lstFilter.Size = new Size(468, 21);
      this.lstFilter.TabIndex = 3;
      this.lstFilter.SelectedIndexChanged += new EventHandler(this.lstFilter_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 48);
      this.label1.Name = "label1";
      this.label1.Size = new Size(42, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Faction";
      this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tabControl1.Appearance = TabAppearance.FlatButtons;
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Location = new Point(4, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(528, 27);
      this.tabControl1.TabIndex = 5;
      this.tabControl1.MouseClick += new MouseEventHandler(this.tabControl1_MouseClick);
      this.tabPage1.Location = new Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(520, 0);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "tabPage1";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage2.Location = new Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(520, 0);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "tabPage2";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.renameToolStripMenuItem,
        (ToolStripItem) this.deleteToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.newToolStripMenuItem
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(153, 98);
      this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
      this.renameToolStripMenuItem.Size = new Size(152, 22);
      this.renameToolStripMenuItem.Text = "Rename";
      this.renameToolStripMenuItem.Click += new EventHandler(this.renameToolStripMenuItem_Click);
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new Size(152, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(114, 6);
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new Size(152, 22);
      this.newToolStripMenuItem.Text = "New";
      this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.cmdSkinned.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.cmdSkinned.Location = new Point(15, 217);
      this.cmdSkinned.Name = "cmdSkinned";
      this.cmdSkinned.Size = new Size(75, 23);
      this.cmdSkinned.TabIndex = 6;
      this.cmdSkinned.Text = "Skin mode";
      this.cmdSkinned.UseVisualStyleBackColor = true;
      this.cmdSkinned.Click += new EventHandler(this.cmdSkinned_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(544, 243);
      this.Controls.Add((Control) this.cmdSkinned);
      this.Controls.Add((Control) this.lstFilter);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.tabControl1);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.cmdClose);
      this.Controls.Add((Control) this.cmdInc);
      this.Name = nameof (frmMain);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "EVE Mission Coounter";
      this.TopMost = true;
      this.Load += new EventHandler(this.frmMain_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public frmMain() => this.InitializeComponent();

    private void Populate(int selectedIndex = 0)
    {
      ArrayList factionList = this.standingList.GetFactionList();
      factionList.Insert(0, (object) "<all>");
      this.lstFilter.DataSource = (object) factionList;
      this.lstFilter.SelectedIndex = selectedIndex;
      this.dataGridView1.DataSource = (object) this.standingList.GetStandingList(selectedIndex > 0 ? this.lstFilter.Text : "");
      this.AutoSizeColumns();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      frmAccount frmAccount = new frmAccount();
      bool flag1 = false;
      bool flag2 = false;
      string str1 = "";
      this.tabControl1.TabPages.Clear();
      Directory.GetFiles(Application.StartupPath, "*.xml");
      string[] files = Directory.GetFiles(Application.StartupPath, "*.xml");
      Array.Sort<string>(files, (Comparison<string>) ((s1, s2) => -s1.CompareTo(s2)));
      foreach (string filePath in files)
      {
        StandingList standingList = new StandingList(filePath, true, frmAccount.GetXmlSource());
        if (standingList.ValidXsd)
        {
          flag1 = true;
          this.standingList = standingList;
          this.tabControl1.TabPages.Insert(0, this.standingList.Name);
        }
      }
      if (!flag1)
      {
        string str2 = Application.StartupPath + (object) Path.DirectorySeparatorChar + "Character 1.xml";
        using (StreamWriter streamWriter = new StreamWriter(str2))
        {
          try
          {
            streamWriter.Write(frmAccount.GetXmlSource());
            streamWriter.Close();
            Thread.Sleep(500);
            this.standingList = new StandingList(str2, true, frmAccount.GetXmlSource());
            this.tabControl1.TabPages.Insert(0, this.standingList.Name);
            flag1 = true;
          }
          catch (Exception ex)
          {
            str1 = str1 + "\n\r" + ex.Message;
            flag2 = true;
          }
        }
      }
      if (flag1)
      {
        try
        {
          this.tabControl1.SelectedIndex = 0;
          this.Populate();
        }
        catch (Exception ex)
        {
          str1 = str1 + "\n\r" + ex.Message;
          flag2 = true;
        }
      }
      if (!flag2)
        return;
      int num = (int) MessageBox.Show("An unexpected error occured. The program cannot continue. Please contact support quoting:" + str1, "Error", MessageBoxButtons.OK);
      this.Close();
    }

    private void lstFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.dataGridView1.DataSource = (object) this.standingList.GetStandingList(this.lstFilter.Text);
      this.AutoSizeColumns();
    }

    private void cmdClose_Click(object sender, EventArgs e) => this.Close();

    public void cmdInc_Click(object sender, EventArgs e)
    {
      try
      {
        int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
        int columnIndex = this.dataGridView1.SelectedCells[0].ColumnIndex;
        if (columnIndex <= 0)
          return;
        int num = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[columnIndex].Value) + 1;
        if (num > 16)
          num = 0;
        this.dataGridView1.CurrentRow.Cells[columnIndex].Value = (object) num;
        this.standingList.UpdateStanding(this.dataGridView1.CurrentRow.Cells[0].Value.ToString(), "level" + (object) columnIndex, num);
      }
      catch
      {
      }
    }

    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      DataGridViewCell currentCell = this.dataGridView1.CurrentCell;
      int num = Convert.ToInt32(currentCell.Value);
      if (num > 16)
      {
        num = 1;
        currentCell.Value = (object) num;
      }
      if (num < 0)
      {
        num = 0;
        currentCell.Value = (object) num;
      }
      this.standingList.UpdateStanding(this.dataGridView1.CurrentRow.Cells[0].Value.ToString(), "level" + (object) currentCell.ColumnIndex, num);
    }

    private void AutoSizeColumns()
    {
      for (int index = 0; index < this.dataGridView1.Columns.Count; ++index)
      {
        this.dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        int width = this.dataGridView1.Columns[index].Width;
        this.dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        this.dataGridView1.Columns[index].Width = width;
      }
    }

    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        for (int index = 0; index < this.tabControl1.TabPages.Count; ++index)
        {
          if (this.tabControl1.GetTabRect(index).Contains(new Point(e.X, e.Y)))
          {
            this.tabControl1.SelectedIndex = index;
            break;
          }
        }
        this.contextMenuStrip1.Show((Control) this.tabControl1, e.Location);
      }
      else
      {
        for (int index = 0; index < this.tabControl1.TabPages.Count; ++index)
        {
          if (this.tabControl1.GetTabRect(index).Contains(new Point(e.X, e.Y)))
          {
            this.standingList = new StandingList(Application.StartupPath + (object) Path.DirectorySeparatorChar + this.tabControl1.SelectedTab.Text + ".xml");
            try
            {
              this.Populate(this.lstFilter.SelectedIndex);
              break;
            }
            catch
            {
              break;
            }
          }
        }
      }
    }

    private void renameToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InputBoxValidation validation = (InputBoxValidation) (val =>
      {
        if (val == "")
          return "Value cannot be empty.";
        if (new Regex("^[a-zA-Z0-9_ @~\\(\\)\\[\\]\\$\\-\\.]+$").IsMatch(val))
        {
          if (!((IEnumerable<string>) Directory.GetFiles(Application.StartupPath, "*.xml")).Contains<string>(Application.StartupPath + (object) Path.DirectorySeparatorChar + val + ".xml"))
            return "";
        }
        return "Invalid name";
      });
      TabPage selectedTab = this.tabControl1.SelectedTab;
      string text = selectedTab.Text;
      string str = text;
      if (InputBox.Show("Rename character", "New name for " + str + " :", ref text, validation) != DialogResult.OK)
        return;
      selectedTab.Text = text;
      File.Copy(Application.StartupPath + (object) Path.DirectorySeparatorChar + str + ".xml", Application.StartupPath + (object) Path.DirectorySeparatorChar + text + ".xml");
      File.Delete(Application.StartupPath + (object) Path.DirectorySeparatorChar + str + ".xml");
      this.standingList = new StandingList(Application.StartupPath + (object) Path.DirectorySeparatorChar + text + ".xml");
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("All mission records for " + this.tabControl1.SelectedTab.Text + " will be deleted. Continue?", "Delete character", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      File.Delete(Application.StartupPath + (object) Path.DirectorySeparatorChar + this.tabControl1.SelectedTab.Text + ".xml");
      this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
      if (this.tabControl1.TabPages.Count != 0)
        return;
      this.frmMain_Load((object) null, EventArgs.Empty);
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InputBoxValidation validation = (InputBoxValidation) (val =>
      {
        if (val == "")
          return "Value cannot be empty.";
        if (new Regex("^[a-zA-Z0-9_ @~\\(\\)\\[\\]\\$\\-\\.]+$").IsMatch(val))
        {
          if (!((IEnumerable<string>) Directory.GetFiles(Application.StartupPath, "*.xml")).Contains<string>(Application.StartupPath + (object) Path.DirectorySeparatorChar + val + ".xml"))
            return "";
        }
        return "Invalid name";
      });
      string text = "";
      if (InputBox.Show("Create character", "New character name:", ref text, validation) != DialogResult.OK)
        return;
      using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + (object) Path.DirectorySeparatorChar + text + ".xml"))
      {
        frmAccount frmAccount = new frmAccount();
        streamWriter.Write(frmAccount.GetXmlSource());
      }
      this.tabControl1.TabPages.Add(new TabPage(text));
    }

    private void cmdSkinned_Click(object sender, EventArgs e)
    {
      frmSkinned frmSkinned = new frmSkinned();
      int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
      int columnIndex = this.dataGridView1.SelectedCells[0].ColumnIndex;
      if (columnIndex > 0)
      {
        frmSkinned.Show((IWin32Window) this);
        int num = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[columnIndex].Value) + 1;
        frmSkinned.Counter = num;
        this.Hide();
      }
      else
      {
        int num1 = (int) MessageBox.Show("Please select mission level to display.", "Information", MessageBoxButtons.OK);
      }
    }
  }
}
