using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EVE_Mission_Counter
{
  public class frmSkinned : Form
  {
    //private IContainer components;
    private GelButton gelButton1;
    private Label label1;
    private ArrayList slices = new ArrayList();
    private int m_count;
    private bool drag;
    private Point start_point = new Point(0, 0);

    protected override void Dispose(bool disposing)
    {
      //if (disposing && this.components != null)
      //  this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.gelButton1 = new GelButton();
      this.SuspendLayout();
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(20, 1);
      this.label1.Name = "label1";
      this.label1.Size = new Size(26, 14);
      this.label1.TabIndex = 1;
      this.label1.Text = "0";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.gelButton1.GradientBottom = Color.Gold;
      this.gelButton1.GradientTop = Color.Gray;
      this.gelButton1.Location = new Point(14, 14);
      this.gelButton1.Name = "gelButton1";
      this.gelButton1.Size = new Size(38, 38);
      this.gelButton1.TabIndex = 0;
      this.gelButton1.Text = " + 1";
      this.gelButton1.UseMnemonic = false;
      this.gelButton1.UseVisualStyleBackColor = true;
      this.gelButton1.Click += new EventHandler(this.gelButton1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(70, 70);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.gelButton1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmSkinned);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Eve Mission Counter";
      this.TopMost = true;
      this.Load += new EventHandler(this.frmSkinned_Load);
      this.Paint += new PaintEventHandler(this.frmSkinned_Paint);
      this.MouseClick += new MouseEventHandler(this.frmSkinned_MouseClick);
      this.MouseDown += new MouseEventHandler(this.frmSkinned_MouseDown);
      this.MouseMove += new MouseEventHandler(this.frmSkinned_MouseMove);
      this.MouseUp += new MouseEventHandler(this.frmSkinned_MouseUp);
      this.ResumeLayout(false);
    }

    public frmSkinned()
    {
      this.InitializeComponent();
      GraphicsPath path = new GraphicsPath();
      path.StartFigure();
      path.AddEllipse(0, 0, 64, 64);
      path.CloseAllFigures();
      this.Region = new Region(path);
      path.Dispose();
    }

    private void frmSkinned_MouseUp(object sender, MouseEventArgs e) => this.drag = false;

    private void frmSkinned_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.drag)
        return;
      Point screen = this.PointToScreen(new Point(e.X, e.Y));
      this.Location = new Point(screen.X - this.start_point.X, screen.Y - this.start_point.Y);
    }

    private void frmSkinned_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      this.drag = true;
      this.start_point = new Point(e.X, e.Y);
    }

    private void frmSkinned_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      this.Owner.Show();
      this.Close();
    }

    private void frmSkinned_Load(object sender, EventArgs e)
    {
      this.label1.MouseDown += new MouseEventHandler(this.frmSkinned_MouseDown);
      this.label1.MouseUp += new MouseEventHandler(this.frmSkinned_MouseUp);
      this.label1.MouseMove += new MouseEventHandler(this.frmSkinned_MouseMove);
      this.label1.MouseClick += new MouseEventHandler(this.frmSkinned_MouseClick);
      for (int index = 0; index < 16; ++index)
        this.slices.Add((object) new Slice(new Point(58, 58), 60, 42, (float) (index * 20 + 290), 20f, 8f, Color.Goldenrod, Color.DimGray, Color.DimGray));
    }

    private void gelButton1_Click(object sender, EventArgs e)
    {
      ++this.m_count;
      if (this.m_count > 16)
        this.m_count = 0;
      this.label1.Text = this.m_count.ToString();
      this.DrawSlices();
      ((frmMain) this.Owner).cmdInc_Click((object) null, EventArgs.Empty);
    }

    public int Counter
    {
      get => this.m_count;
      set
      {
        this.m_count = value - 1;
        this.label1.Text = this.m_count.ToString();
        this.DrawSlices();
      }
    }

    private void DrawSlices()
    {
      for (int index = 0; index < this.slices.Count; ++index)
      {
        if (index < this.m_count)
          ((Slice) this.slices[index]).SetFillColors(Color.Yellow, Color.Orange);
        else
          ((Slice) this.slices[index]).SetFillColors(Color.DimGray, Color.DimGray);
      }
      this.Invalidate();
    }

    private void frmSkinned_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.FillEllipse(Brushes.Black, 0, 0, 64, 64);
      for (int index = 0; index < this.slices.Count; ++index)
        ((Slice) this.slices[index]).Draw(e.Graphics);
    }
  }
}
